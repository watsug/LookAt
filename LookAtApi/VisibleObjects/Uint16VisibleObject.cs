using System;
using LookAtApi.Interfaces;
using System.ComponentModel;
using LookAtApi.Converters;

namespace LookAtApi.VisibleObjects
{
    [TypeConverter(typeof(VisibleObjectConverter))]
    public class Uint16VisibleObject : VisibleObjectBase
    {
        #region private
        private readonly ushort _val = 0;
        #endregion

        public Uint16VisibleObject(ushort val, IVisibleObject parent = null, ITransformation transformation = null, bool final = false)
            : base (parent, transformation, final)
        {
            _val = val;
        }

        #region IVisibleObject
        [DisplayName("Unsigned word")]
        public override object Value => _val;
        #endregion
    }
}
