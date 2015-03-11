namespace Rapidware.Financier.Finance.Mvvm
{
    using SystemDot.Mobile.Mvvm;

    public interface IViewModelNavigator
    {
        void ShowViewModel<TViewModel, TViewArgument>(TViewArgument args)
            where TViewModel : ViewModel<TViewModel>, IInitialiseView<TViewArgument>;

        void ShowViewModel<TViewModel>()
            where TViewModel : ViewModel<TViewModel>;
    }
}