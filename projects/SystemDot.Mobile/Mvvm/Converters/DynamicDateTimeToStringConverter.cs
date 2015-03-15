namespace SystemDot.Mobile.Mvvm.Converters
{
    using System;
    using System.Globalization;
    using Cirrious.CrossCore.Converters;

    public class DynamicDateTimeToStringConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.IsToday())
            {
                return value.ToString("HH:mm");
            }

            if (value.IsThisYear())
            {
                return value.ToString("dd MMM");
            }

            return value.ToString("dd MMM YY");
        }
    }
}