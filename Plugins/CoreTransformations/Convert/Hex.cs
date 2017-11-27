using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;
using System;
using System.Collections.Generic;
using System.Composition;

namespace CoreTransformations.Convert
{
    [Export(typeof(ITransformation))]
    public class Hex : ITransformation
    {
        private const string Characters = "0123456789abcdef";

        #region ITransformation
        public string Name => "Hex";

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            try
            {
                if (obj.Value is string tmp && tmp.Length > 0)
                {
                    tmp = tmp.ToLower();
                    if (tmp.Length % 2 != 0) return null;

                    List<byte> buff = new List<byte>();
                    for (int i = 0; i < tmp.Length; i += 2)
                    {
                        int c1 = Characters.IndexOf(tmp[i]);
                        int c2 = Characters.IndexOf(tmp[i+1]);
                        if (c1 < 0 || c2 < 0) return null;
                        int v = (c1 << 4) + c2;
                        buff.Add(System.Convert.ToByte(v));
                    }

                    return new ByteArrayVisibleObject(buff.ToArray(), obj, this);
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