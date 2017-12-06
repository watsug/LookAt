using LookAtApi.Converters;
using LookAtApi.Interfaces;
using System.ComponentModel;

namespace LookAtApi.VisibleObjects
{
    [TypeConverter(typeof(VisibleObjectConverter))]
    public class StringVisibleObject : VisibleObjectBase
    {
        #region private
        string _val = "";
        #endregion

        public StringVisibleObject(string str, IVisibleObject parent = null, ITransformation transformation = null, bool final = false)
            : base (parent, transformation, final)
        {
            _val = str;
        }

        #region IVisibleObject
        [DisplayName("Text")]
        public override object Value => _val;
        #endregion
    }
}
