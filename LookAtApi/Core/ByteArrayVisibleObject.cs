﻿using LookAtApi.Interfaces;

namespace LookAtApi.Core
{
    public class ByteArrayVisibleObject : VisibleObjectBase
    {
        #region private
        byte[] _val = null;
        #endregion

        public ByteArrayVisibleObject(byte[] arr, IVisibleObject parent = null) : base (parent)
        {
            _val = arr;
        }

        #region IVisibleObject
        public override object Value => _val;
        #endregion
    }
}