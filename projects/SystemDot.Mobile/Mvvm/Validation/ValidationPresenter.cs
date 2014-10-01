using System.Collections.Generic;
using SystemDot.Core.Collections;

namespace SystemDot.Mobile.Mvvm.Validation
{
    public abstract class ValidationPresenter<TViewModel> 
        where TViewModel : ValidatableViewModel<TViewModel>
    {
        readonly ViewModelLocator viewModelLocator;

        protected ValidationPresenter(ViewModelLocator viewModelLocator)
        {
            this.viewModelLocator = viewModelLocator;
        }

        public void Present(string message)
        {
            Present(new List<int>(), new List<string> {message});
        }

        public void Present(IEnumerable<int> fields, IEnumerable<string> messages)
        {
            fields.ForEach(f => ExclusiveRunLock.Run(() => MakeFieldInvalid(f)));
            messages.ForEach(DisplayValidationMessage);
        }

        protected abstract void MakeFieldInvalid(int field);

        void DisplayValidationMessage(string messsage)
        {
            GetViewModel().ValidationMessage.Value = messsage;
        }

        TViewModel GetViewModel()
        {
            return viewModelLocator.Locate<TViewModel>();
        }
    }
}