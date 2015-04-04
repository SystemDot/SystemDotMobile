using System;
using SystemDot.Mobile.Mvvm.Validation;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile
{
    using SystemDot.Mobile.Mvvm;

    public abstract class ActionBarActivityWithValidation<TViewModel> : ActionBarActivity<TViewModel>
        where TViewModel : ViewModel<TViewModel>, ValidatableViewModel
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
            TypedViewModel.GetValidationMessage().Changed += ValidationMessage_Changed;
        }

        void ValidationMessage_Changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TypedViewModel.GetValidationMessage().Value)) return;
            TypedViewModel.Alert(TypedViewModel.GetValidationMessage().Value);
        }
    }
}