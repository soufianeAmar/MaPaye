using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Security;
using System.Security;

namespace TP.Shell.XAF.Module.Win.Permissions
{
    public enum MultiEditPermissionAccessModifier
    {
        Deny,
        Allow
    }

    [NonPersistent]
    public class MultiEditPermission : PermissionBase
    {
        private static bool _alwaysGranted;
        private MultiEditPermissionAccessModifier _Modifier;

        public MultiEditPermission()
        {
        }

        public MultiEditPermission(MultiEditPermissionAccessModifier modifier)
            : this()
        {
            _Modifier = modifier;
        }

        public override IPermission Copy()
        {
            return new MultiEditPermission(_Modifier);
        }

        public MultiEditPermissionAccessModifier Modifier
        {
            get { return _Modifier; }
            set { _Modifier = value; }
        }

        public override IPermission Intersect(IPermission target)
        {
            var myPermission = target as MultiEditPermission;
            if (myPermission == null)
            {
                throw new ArgumentException(
                    string.Format("Incorrect permission is passed: '{0}' instead of '{1}'",
                                  target.GetType(), GetType()));
            }
            if (_alwaysGranted)
                return new MultiEditPermission(MultiEditPermissionAccessModifier.Allow);
            return myPermission._Modifier == _Modifier ? new MultiEditPermission(_Modifier) : null;
        }

        public override IPermission Union(IPermission target)
        {
            return Intersect(target);
        }

        public override void FromXml(SecurityElement e)
        {

            _Modifier =
                (MultiEditPermissionAccessModifier)
                Enum.Parse(typeof (MultiEditPermissionAccessModifier), e.Attributes["modifier"].ToString());
        }

        public override SecurityElement ToXml()
        {
            var result = base.ToXml();
            result.AddAttribute("modifier", _Modifier.ToString());
            return result;
        }

        public override bool IsSubsetOf(IPermission target)
        {
            return Intersect(target) != null;
        }

        public static bool AlwaysGranted
        {
            get { return _alwaysGranted; }
            set { _alwaysGranted = value; }
        }


    }

}
