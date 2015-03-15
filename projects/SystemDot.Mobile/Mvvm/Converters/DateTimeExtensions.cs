namespace SystemDot.Mobile.Mvvm.Converters
{
    using System;

    public static class DateTimeExtensions
    {
        public static bool IsToday(this DateTime toCheck)
        {
            return toCheck.Date == DateTime.Now.Date;
        }

        public static bool IsThisYear(this DateTime toCheck)
        {
            return toCheck.Year == DateTime.Now.Year;
        }
    }
}