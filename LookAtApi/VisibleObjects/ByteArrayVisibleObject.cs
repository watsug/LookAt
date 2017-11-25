using LookAtApi.Converters;
using LookAtApi.Interfaces;
using System.ComponentModel;

namespace LookAtApi.VisibleObjects
{
    [TypeConverter(typeof(VisibleObjectConverter))]
    public class ByteArrayVisibleObject : VisibleObjectBase
    {
        #region private
        byte[] _val = null;
        #endregion

        public ByteArrayVisibleObject(byte[] arr, IVisibleObject parent = null, ITransformation transformation = null)
            : base (parent, transformation)
        {
            _val = arr;
        }

        #region IVisibleObject
        public override object Value => _val;
        #endregion
    }
}
