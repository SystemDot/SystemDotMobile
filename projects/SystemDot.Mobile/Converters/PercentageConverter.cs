using System;
using System.Globalization;
using SystemDot.Core;
using Cirrious.CrossCore.Converters;

namespace SystemDot.Mobile.Converters
{
    public class PercentageConverter : MvxValueConverter<decimal, string>
    {
        protected override string Convert(decimal value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Concat(value.RoundTo(2), " %");
        }
    }
}
