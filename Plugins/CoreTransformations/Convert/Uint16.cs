using System;
using System.Composition;
using System.Globalization;
using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;

namespace CoreTransformations.Convert
{
    [Export(typeof(ITransformation))]
    public class Uint16 : ITransformation
    {
        public string Name => "UInt16";

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            try
            {
                if (obj.Value is string)
                {
                    return new Uint16VisibleObject(ushort.Parse(obj.Value as string, NumberStyles.HexNumber, null), obj, this);
                }
                else if (obj.Value is byte[])
                {
                    byte[] tmp = obj.Value as byte[];
                    if (tmp.Length != 2) return null;
                    ushort val = System.Convert.ToUInt16((tmp[0] << 8) + tmp[1]);
                    return new Uint16VisibleObject(val, obj, this);
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
