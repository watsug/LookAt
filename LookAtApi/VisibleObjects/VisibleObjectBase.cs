using System.ComponentModel;
using LookAtApi.Converters;
using LookAtApi.Interfaces;

namespace LookAtApi.VisibleObjects
{
    [TypeConverter(typeof(VisibleObjectConverter))]
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
        [Category("Information")]
        public IVisibleObject Parent => _parent;

        [Category("Information")]
        public ITransformation Transformation => _transformation;

        [Category("Value")]
        public abstract object Value { get; }
        #endregion
    }
}
