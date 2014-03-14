using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace SystemDot.Mobile.Mvvm
{
    public class NumericToStringConverter<T> : MvxValueConverter<T, string>
    {
        protected override string Convert(T value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }  
    }
}