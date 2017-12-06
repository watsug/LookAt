using System;
using System.Text;
using System.Composition;
using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;

namespace CoreTransformations.Convert
{
    [Export(typeof(ITransformation))]
    public class Binary : ITransformation
    {
        public string Name => "Binary";

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            try
            {
                byte[] buff;
                switch (obj.Value)
                {
                    case ushort tmp1:
                        buff = new byte[]{ (byte)((tmp1 >> 8) & 0x00ff), (byte)(tmp1 & 0x00ff) };
                        break;
                    case uint tmp2:
                        buff = new byte[] { (byte)((tmp2 >> 24) & 0x00ff), (byte)((tmp2 >> 16) & 0x00ff), (byte)((tmp2 >> 8) & 0x00ff), (byte)(tmp2 & 0x00ff) };
                        break;
                    default:
                        return null;
                }

                return new StringVisibleObject(RenderBinaryString(buff), obj, this, true);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string RenderBinaryString(byte[] buff)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in buff)
            {
                if (sb.Length > 0) sb.Append(" ");
                RenderBinaryString(sb, b);
            }
            return sb.ToString();
        }

        private void RenderBinaryString(StringBuilder sb, byte bt)
        {
            for (int i = 8; i > 0; i--)
            {
                sb.Append(0x00 != (bt & 0x80) ? "1" : "0");
                bt = (byte)((bt << 1) & 0xff);
            }
        }
    }
}