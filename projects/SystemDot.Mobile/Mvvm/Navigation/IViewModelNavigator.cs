namespace SystemDot.Mobile.Mvvm.Navigation
{
    public interface IViewModelNavigator
    {
        void ShowViewModel<TViewModel, TViewArgument>(TViewArgument args)
            where TViewModel : ViewModel<TViewModel>, IInitialiseView<TViewArgument>;

        void ShowViewModel<TViewModel>()
            where TViewModel : ViewModel<TViewModel>;
    }
}