using System;
using System.ComponentModel;
using LookAtApi.Converters;
using LookAtApi.Interfaces;

namespace LookAtApi.VisibleObjects
{
    [TypeConverter(typeof(VisibleObjectConverter))]
    public class Uint32VisibleObject : VisibleObjectBase
    {
        #region private
        UInt32 _val = 0;
        #endregion

        public Uint32VisibleObject(UInt32 val, IVisibleObject parent = null, ITransformation transformation = null)
            : base(parent, transformation)
        {
            _val = val;
        }

        #region IVisibleObject
        public override object Value => _val;
        #endregion
    }
}