using System;
using System.Composition;
using System.Globalization;
using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;

namespace CoreTransformations.Convert
{
    [Export(typeof(ITransformation))]
    public class Uint32 : ITransformation
    {
        public string Name => "UInt32";

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            try
            {
                if (obj.Value is string)
                {
                    return new Uint32VisibleObject(uint.Parse(obj.Value as string, NumberStyles.HexNumber, null), obj, this);
                }
                else if (obj.Value is byte[])
                {
                    byte[] tmp = obj.Value as byte[];
                    if (tmp.Length != 4) return null;
                    uint val = System.Convert.ToUInt32((tmp[0] << 24) + (tmp[1] << 16) + (tmp[2] << 8) + tmp[3]);
                    return new Uint32VisibleObject(val, obj, this);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}