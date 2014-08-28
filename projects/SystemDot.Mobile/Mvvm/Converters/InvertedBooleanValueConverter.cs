using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace SystemDot.Mobile.Mvvm.Converters
{
    public class InvertedBooleanValueConverter : MvxValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return !value;
        }
    }
}
