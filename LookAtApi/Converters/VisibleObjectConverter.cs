using System;
using System.ComponentModel;
using System.Globalization;

namespace LookAtApi.Converters
{
    public class VisibleObjectConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
