namespace SystemDot.Mobile.Mvvm.Notification
{
    using System;
    using Cirrious.MvvmCross.FieldBinding;

    public class StringNotifyChange : NotifyChange<string>
    {
        public StringNotifyChange(Action<string> onChanged)
            : base(string.Empty, onChanged)
        {
        }
    }
}