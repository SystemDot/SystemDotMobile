namespace SystemDot.Mobile
{
    using SystemDot.Messaging.Simple;
    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.ViewModels;

    public abstract class SystemDotMvxApplication : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.Resolve<Dispatcher>().Send(new AppStarted());
        }
    }
}