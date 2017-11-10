using LookAtApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LookAtApi.Core
{
    public abstract class VisibleObjectBase : IVisibleObject
    {
        #region private
        IVisibleObject _parent = null;
        #endregion

        public VisibleObjectBase(IVisibleObject parent = null)
        {
            _parent = parent;
        }

        #region IVisibleObject
        public IVisibleObject Parent => _parent;
        public abstract object Value { get; }
        #endregion
    }
}
