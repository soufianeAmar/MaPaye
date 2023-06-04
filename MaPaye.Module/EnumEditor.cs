using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.XtraEditors.Controls;
using DevExpress.ExpressApp.Utils;

namespace MaPaye.Module
{
    [PropertyEditor(typeof(Enum), true)]
    public class EnumEditor : DXPropertyEditor
    {
        public EnumEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model)
        {

        }

        protected override object CreateControlCore()
        {
            Type enumType = GetUnderlyingType();
            RadioGroup result = new RadioGroup { BackColor = Color.Transparent, AutoSizeInLayoutControl = true };//, MaximumSize = new Size(320, 180) };
            EnumDescriptor ed = new EnumDescriptor(enumType);
            foreach (object item in Enum.GetValues(enumType))
            {
                result.Properties.Items.Add(new RadioGroupItem(item, ed.GetCaption(item)));
            }
            result.EditValueChanged += result_EditValueChanged;
            return result;
        }

        private void result_EditValueChanged(object sender, EventArgs e)
        {
            if (AllowEdit)
                WriteValue();
        }

        protected override void ReadValueCore()
        {
            (Control as RadioGroup).SelectedIndex = (int)PropertyValue;
        }

        protected override object GetControlValueCore()
        {
            return (Control as RadioGroup).SelectedIndex;
        }
        protected override void WriteValueCore()
        {
            PropertyValue = ControlValue;
        }
    }
}
