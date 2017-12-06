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
        private readonly uint _val = 0;
        #endregion

        public Uint32VisibleObject(UInt32 val, IVisibleObject parent = null, ITransformation transformation = null, bool final = false)
            : base(parent, transformation, final)
        {
            _val = val;
        }

        #region IVisibleObject
        [DisplayName("Unsigned integer")]
        public override object Value => _val;
        #endregion
    }
}