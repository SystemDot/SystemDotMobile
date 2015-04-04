namespace SystemDot.Mobile.Mvvm.Notification
{
    using System;
    using Cirrious.MvvmCross.FieldBinding;

    public class GuidNotifyChange : NotifyChange<Guid>
    {
        public GuidNotifyChange(Action<Guid> valueChanged)
            : base(Guid.Empty, valueChanged)
        {
        }
    }
}