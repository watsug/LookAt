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
        ITransformation _transformation = null;
        #endregion

        public VisibleObjectBase(IVisibleObject parent = null, ITransformation transformation = null)
        {
            _parent = parent;
            _transformation = transformation;
        }

        #region IVisibleObject
        public IVisibleObject Parent => _parent;
        public ITransformation Transformation => _transformation;
        public abstract object Value { get; }
        #endregion
    }
}
