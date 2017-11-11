using System;
using System.Composition;
using LookAtApi.Core;
using LookAtApi.Interfaces;

namespace CoreTransformations.BaseX
{
    [Export(typeof(ITransformation))]
    public class FromBase64 : ITransformation
    {
        #region ITransformation
        public string Name => "From Base64";

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            try
            {
                return new ByteArrayVisibleObject(Convert.FromBase64String(obj.Value.ToString()), obj);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
