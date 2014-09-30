using System.Collections.Generic;
using SystemDot.Core.Collections;

namespace SystemDot.Mobile.Mvvm.Validation
{
    public abstract class ValidationPresenter<TViewModel> 
        where TViewModel : ViewModel<TViewModel>
    {
        readonly ValidatableViewModel<TViewModel> viewModel;

        protected ValidationPresenter(ValidatableViewModel<TViewModel> viewModel)
        {
            this.viewModel = viewModel;
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
            viewModel.ValidationMessage.Value = messsage;
        }
    }
}