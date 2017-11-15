using System;
using System.ComponentModel;
using System.Collections.Generic;
using LookAtApi.Interfaces;

namespace LookAt
{
    public class VisibleObjectCollectionDescriptor : PropertyDescriptor
    {
        IList<IVisibleObject> _list;
        int _index;

        internal VisibleObjectCollectionDescriptor(IList<IVisibleObject> list, int index)
            : base(index.ToString(), null)
        {
            _list = list;
            _index = index;
        }

        #region PropertyDescriptor
        public override string DisplayName
        {
            get { return _list[_index].Transformation.Name; }
        }

        public override string Description
        {
            get { return IntGetDescription(_list[_index]); }
        }

        public override Type ComponentType
        {
            get { return _list[_index].GetType(); }
        }

        public override Type PropertyType
        {
            get { return _list.GetType(); }
        }

        public override void SetValue(object component, object value)
        {
            throw new NotImplementedException("SetValue");
        }

        public override object GetValue(object component)
        {
            return _list[_index].Value;
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override bool IsBrowsable
        {
            get { return true; }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
        #endregion

        #region private 
        private string IntGetDescription(IVisibleObject obj)
        {
            if (obj == null) return null;
            string tmp = IntGetDescription(obj.Parent);
            if (string.IsNullOrWhiteSpace(tmp)) return obj.Transformation == null ? null : obj.Transformation.Name;
            return tmp + @"\" + obj.Transformation.Name;
        }
        #endregion
    }
}
