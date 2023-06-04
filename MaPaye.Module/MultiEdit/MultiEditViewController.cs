using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Validation;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraEditors;
//using TP.Shell.XAF.Module.Asset;
using TP.Shell.XAF.Module.Win.Forms;
using ListView = DevExpress.ExpressApp.ListView;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Win;

namespace TP.Shell.XAF.Module.Win.Controllers
{

    public partial class MultiEditViewController : LongOperationController
    {
        public MultiEditViewController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void MultiEditViewController_Activated(object sender, EventArgs e)
        {
            MultiEditAction.Active.SetItemValue("Permission",
                                                SecuritySystem.IsGranted(new Permissions.MultiEditPermission
                                                                             (Permissions.MultiEditPermissionAccessModifier.Allow)) && !View.ObjectTypeInfo.Type.IsAbstract);
            Frame.GetController<PersistenceValidationController>().Active.SetItemValue("LicenseCode_ListView", false);

        }

        private void MultiEditViewController_Deactivating(object sender, EventArgs e)
        {
            Frame.GetController<PersistenceValidationController>().Active.SetItemValue("LicenseCode_ListView", true);
        }

        private UnitOfWork tempUOW;
        private object _NewObj;
        protected SimpleActionExecuteEventArgs _EAgrs;
        private List<string> _ChangedProps = new List<string>();

        private void MultiEditAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            _EAgrs = e;
            tempUOW = new UnitOfWork(((XPObjectSpace)View.ObjectSpace).Session.DataLayer);
            tempUOW.BeginTransaction();

            //Get object from master view
            if (!(View != null && (View is ListView))) return;
            var callingView = (ListView)View;
            var objectType = callingView.ObjectTypeInfo.Type;

            //new Object space and object
            _NewObj = ReflectionHelper.CreateObject(objectType, tempUOW);

            #region collect & set identical properties

            var t = View.ObjectTypeInfo.Type;

            //Select all persistent properties (nonpersistent PX)
            var props = tempUOW.GetClassInfo(t).PersistentProperties.OfType<XPMemberInfo>()
                .Where(p => p.StorageType != typeof(Byte[]) && p.MemberType != typeof(XPCollection));

            //group data for each property. where distinct count ==1, add these properties to list
            var a = (from prop in props
                     let propInfo = prop
                     let values = View.SelectedObjects.OfType<IXPSimpleObject>().
                                       Select(p => propInfo.GetValue(p)).Distinct()
                     where values.Count() == 1 && values.FirstOrDefault() != null
                     select prop).ToList();

            //take care of simple properties, such as String, Int, ect
            foreach (var memberInfo in a.Where(p => p.ReferenceType == null))
            {
                var ob = View.SelectedObjects.OfType<IXPSimpleObject>().FirstOrDefault();
                (_NewObj as IXPSimpleObject)
                    .ClassInfo.PersistentProperties
                    .OfType<XPMemberInfo>()
                    .Where(p => p.Name == memberInfo.Name)
                    .FirstOrDefault()
                    .SetValue(_NewObj, memberInfo.GetValue(ob));

            }

            //almost the same, just for referenced properties
            foreach (var memberInfo in a.Where(p => p.ReferenceType != null))
            {
                //any object from selected objects
                var ob = View.SelectedObjects.OfType<IXPSimpleObject>().FirstOrDefault();
                //value of selected property
                var val = memberInfo.GetValue(ob) as XPBaseObject;
                ((IXPSimpleObject)_NewObj)
                    .ClassInfo.PersistentProperties
                    .OfType<XPMemberInfo>()
                    .Where(p => p.Name == memberInfo.Name)
                    .FirstOrDefault()
                    .SetValue(_NewObj, val != null ? tempUOW.GetObjectByKey(memberInfo.MemberType, tempUOW.GetKeyValue(val)) : null);

            }
            #endregion

            ((XPBaseObject)_NewObj).Changed += NewObjChanged;
             
            //Show view with da object
            //var v = Application.CreateDetailView(new XPObjectSpace(tempUOW, XafTypesInfo.Instance), _NewObj);
            XPObjectSpace objectspace = new XPObjectSpace(XafTypesInfo.Instance, XpoTypesInfoHelper.GetXpoTypeInfoSource(),
                            new CreateUnitOfWorkHandler(delegate()
                        {
                            return tempUOW;
                        }));

            var v = Application.CreateDetailView(objectspace, _NewObj); 

            e.ShowViewParameters.CreatedView = v;
            e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            e.ShowViewParameters.Context = TemplateContext.PopupWindow;
            e.ShowViewParameters.CreateAllControllers = true;


            var dc = Application.CreateController<DialogController>();

            dc.Accepting += DcAccepting;
            dc.Cancelling += DcCancelling;
            dc.SaveOnAccept = false;

            e.ShowViewParameters.Controllers.Add(dc);

        }

        void NewObjChanged(object sender, ObjectChangeEventArgs e)
        {
            if (e.PropertyName != null && !_ChangedProps.Contains(e.PropertyName) && e.PropertyName != "Modified" && e.PropertyName != "User")
                _ChangedProps.Add(e.PropertyName);
        }

        void DcCancelling(object sender, EventArgs e)
        {
            if (tempUOW.InTransaction)
                tempUOW.RollbackTransaction();
        }

        protected override void DoWorkCore(LongOperation longOperation)
        {
            var session = CreateUpdatingSession();

            var changedMembers = session.GetClassInfo(_NewObj).Members
                .Where(p => ChangedProps.Contains(p.Name));

            if (changedMembers.Count() == 0)
            {
                XtraMessageBox.Show("Nothing changed.");
                longOperation.CancelAsync();
                return;
            }

            const string delimeter = ": ";
            var k = 0;

            #region Confirmation dialog
            var message =
                    string.Format("Folowing fields for selected objects will be udated: {0}{0}{1}",
                                  Environment.NewLine,
                                  changedMembers.Select(p =>
                                      new String((
                                          "  " +
                                          ++k +
                                          ".  " +
                                          p.Name +
                                          delimeter +
                                          p.GetValue(_NewObj) +
                                          Environment.NewLine)
                                      .ToCharArray()))
                                      .Aggregate((i, j) => i + j)
                        );

            var dialogResult = XtraMessageBox.Show(
                message,
                "Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (dialogResult != DialogResult.OK)
            {
                longOperation.CancelAsync();
                return;
            }
            #endregion

            try
            {
                #region Updater Loop
                foreach (var objt in _EAgrs.SelectedObjects)
                {
                    if (_NewObj == null) continue;
                    var ob = session.GetObjectByKey(objt.GetType(), session.GetKeyValue(objt)) as XPBaseObject;
                    if (ob == null)
                        continue;
                    var j = 1;
                    foreach (var cMember in changedMembers)
                    {
                        var member = cMember;

                        if (member.ReferenceType == null)
                        {
                            ob.ClassInfo.Members
                                .Where(p => p.Name == member.Name).FirstOrDefault()
                                .SetValue(ob, cMember.GetValue(_NewObj));
                        }
                        else
                        {
                            object v = null;

                            if (cMember.GetValue(_NewObj) != null)
                            {

                                v = session
                                    .GetObjectByKey(cMember.ReferenceType,
                                                    session.GetKeyValue(cMember.GetValue(_NewObj)));
                            }

                            ob.ClassInfo.Members
                                .Where(p => p.Name == member.Name).FirstOrDefault()
                                .SetValue(ob, v);


                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    ob.Save();
                    j++;

                    if (longOperation.Status == LongOperationStatus.InProgress)
                    {
                        longOperation.RaiseProgressChanged(
                            (j * 100) / _EAgrs.SelectedObjects.Count,
                            string.Format(ProgressMessageTemplate, j, _EAgrs.SelectedObjects.Count));
                    }
                    if (longOperation.Status == LongOperationStatus.Cancelling)
                        return;
                }
                #endregion
            }
            catch (LongOperationTerminateException)
            {
                longOperation.CancelAsync();
                return;
            }
            finally
            {
                CommitUpdatingSession(session);
            }

        }

        protected const string ProgressCaption = "Updating selected objects...";
        protected const string ProgressMessageTemplate = "Updating object {0} of {1}";

        protected override IProgressControl CreateProgressControl()
        {
            return new ProgressControll(ProgressCaption, View.SelectedObjects.Count, ProgressMessageTemplate);
        }

        private ViewController _Dctrl;

        private void DcAccepting(object sender, DialogControllerAcceptingEventArgs e)
        {
            _Dctrl = ((DialogController)sender).Frame.GetController<ViewController>();
            //if (_Dctrl != null) _Dctrl.SuppressConfirmation = true;

            StartLongOperation(_ChangedProps);
            if (tempUOW.InTransaction)
                tempUOW.RollbackTransaction();

        }

        protected override void OnOperationCompleted()
        {
            _ChangedProps.Clear();
            if (tempUOW.InTransaction)
                tempUOW.RollbackTransaction();

            base.OnOperationCompleted();

            //if (_Dctrl != null) _Dctrl.SuppressConfirmation = false;
        }

    }
}