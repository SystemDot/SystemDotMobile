using Cirrious.MvvmCross.ViewModels;

namespace SystemDot.Mobile.Mvvm.Navigation
{
    public class MvxViewModelNavigator : MvxNavigatingObject, IViewModelNavigator
    {
        public void ShowViewModel<TViewModel, TViewArgument>(TViewArgument args) where TViewModel : ViewModel<TViewModel>, IInitialiseView<TViewArgument>
        {
            base.ShowViewModel<TViewModel>(args);
        }

        public void ShowViewModel<TViewModel>() where TViewModel : ViewModel<TViewModel>
        {
            base.ShowViewModel<TViewModel>();
        }
    }
}