using System;
using System.ComponentModel;
using LookAtApi.Converters;
using LookAtApi.Interfaces;

namespace LookAtApi.VisibleObjects
{
    [TypeConverter(typeof(VisibleObjectConverter))]
    public class VisibleObject : VisibleObjectBase
    {
        #region private
        object _val = 0;
        #endregion

        public VisibleObject(object val, IVisibleObject parent = null, ITransformation transformation = null)
            : base(parent, transformation)
        {
            _val = val;
        }

        #region IVisibleObject
        public override object Value => _val;
        #endregion
    }
}