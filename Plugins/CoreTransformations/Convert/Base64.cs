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
                if (obj.Value is string)
                {
                    return new ByteArrayVisibleObject(System.Convert.FromBase64String(obj.Value.ToString()), obj, this);
                }
                if (obj.Value is byte[])
                {
                    return new StringVisibleObject(System.Convert.ToBase64String(obj.Value as byte[]), obj, this);
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
