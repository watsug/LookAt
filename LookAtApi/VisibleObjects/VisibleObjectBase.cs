using System.ComponentModel;
using LookAtApi.Converters;
using LookAtApi.Interfaces;

namespace LookAtApi.VisibleObjects
{
    [TypeConverter(typeof(VisibleObjectConverter))]
    public abstract class VisibleObjectBase : IVisibleObject
    {
        protected VisibleObjectBase(IVisibleObject parent = null, ITransformation transformation = null, bool final = false)
        {
            Parent = parent;
            Transformation = transformation;
            Final = final;
        }

        #region IVisibleObject
        [Category("Information")]
        public IVisibleObject Parent { get; } = null;

        [Category("Information")]
        public ITransformation Transformation { get; } = null;

        [Category("Value")]
        public abstract object Value { get; }

        public bool Final { get; } = false;
        #endregion
    }
}
