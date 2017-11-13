using System;
using LookAtApi.Interfaces;

namespace LookAtApi.Core
{
    public class Uint16VisibleObject : VisibleObjectBase
    {
        #region private
        UInt16 _val = 0;
        #endregion

        public Uint16VisibleObject(UInt16 val, IVisibleObject parent = null, ITransformation transformation = null)
            : base (parent, transformation)
        {
            _val = val;
        }

        #region IVisibleObject
        public override object Value => _val;
        #endregion
    }
}
