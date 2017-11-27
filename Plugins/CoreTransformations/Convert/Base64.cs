using System;
using System.Composition;
using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;

namespace CoreTransformations.Convert
{
    [Export(typeof(ITransformation))]
    public class Base64 : ITransformation
    {
        #region ITransformation
        public string Name => "Base64";

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            try
            {
                string tmpStr = obj.Value as string;
                if (!string.IsNullOrEmpty(tmpStr))
                {
                    return new ByteArrayVisibleObject(System.Convert.FromBase64String(tmpStr), obj, this);
                }
                if (obj.Value is byte[] tmpBt && tmpBt.Length > 0)
                {
                    return new StringVisibleObject(System.Convert.ToBase64String(tmpBt), obj, this);
                }
            }
            catch (Exception)
            {
                // INFO: intentionally left blank
            }
            return null;
        }
        #endregion
    }
}
