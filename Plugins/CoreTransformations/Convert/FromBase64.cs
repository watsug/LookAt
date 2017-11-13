using System;
using System.Composition;
using LookAtApi.Core;
using LookAtApi.Interfaces;

namespace CoreTransformations.Convert
{
    [Export(typeof(ITransformation))]
    public class FromBase64 : ITransformation
    {
        #region ITransformation
        public string Name => "Base64Decode";

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            try
            {
                return new ByteArrayVisibleObject(System.Convert.FromBase64String(obj.Value.ToString()), obj, this);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
