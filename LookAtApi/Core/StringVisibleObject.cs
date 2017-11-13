using LookAtApi.Interfaces;

namespace LookAtApi.Core
{
    public class StringVisibleObject : VisibleObjectBase
    {
        #region private
        string _val = "";
        #endregion

        public StringVisibleObject(string str, IVisibleObject parent = null, ITransformation transformation = null)
            : base (parent, transformation)
        {
            _val = str;
        }

        #region IVisibleObject
        public override object Value => _val;
        #endregion
    }
}
