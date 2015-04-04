using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm.Notification
{
    using System;

    public class BooleanNotifyChange : NotifyChange<bool>
    {
        public BooleanNotifyChange(Action<bool> onChanged)
            : base(false, onChanged)
        {
        }
        
        public BooleanNotifyChange() : base(false)
        {
        }
    }
}