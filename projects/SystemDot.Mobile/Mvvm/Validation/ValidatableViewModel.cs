namespace SystemDot.Mobile.Mvvm.Validation
{
    using SystemDot.Mobile.Mvvm.Notification;

    public interface ValidatableViewModel
    {
        StringNotifyChange GetValidationMessage();
    }
}