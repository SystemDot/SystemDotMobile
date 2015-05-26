namespace SystemDot.Mobile
{
    using System;
    using SystemDot.Mobile.Mvvm.Validation;
    using Cirrious.MvvmCross.FieldBinding;

    public abstract class ActionBarActivityWithValidation<TViewModel> : ActionBarActivity<TViewModel>
        where TViewModel : ValidatableViewModel<TViewModel>
    {
        protected ActionBarActivityWithValidation(int layoutId, int menuLayoutId, int waitProgressStyle)
            : base(layoutId, menuLayoutId, waitProgressStyle)
        {
        }

        protected ActionBarActivityWithValidation(int layoutId, int menuLayoutId, int waitProgressStyle, Func<TViewModel, INotifyChange> menuInvalidatorAction)
            : base(layoutId, menuLayoutId, waitProgressStyle, menuInvalidatorAction)
        {
        }

        protected override void AfterContentSetup()
        {
            TypedViewModel.ValidationMessage.Changed += ValidationMessage_Changed;
        }

        void ValidationMessage_Changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TypedViewModel.ValidationMessage.Value))
            {
                return;
            }
            TypedViewModel.Alert(TypedViewModel.ValidationMessage.Value);
        }
    }
}