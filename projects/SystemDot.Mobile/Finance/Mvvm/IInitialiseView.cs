namespace Rapidware.Financier.Finance.Mvvm
{
    public interface IInitialiseView<in TViewArgument>
    {
        void Init(TViewArgument args);
    }
}