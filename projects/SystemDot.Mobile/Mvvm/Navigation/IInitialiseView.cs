namespace SystemDot.Mobile.Mvvm.Navigation
{
    public interface IInitialiseView<in TViewArgument>
    {
        void Init(TViewArgument args);
    }
}