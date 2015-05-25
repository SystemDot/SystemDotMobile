using SystemDot.Bootstrapping;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Bootstrap
{
    using SystemDot.Mobile.Alerts;
    using SystemDot.Mobile.Mvvm.Parallelism;

    public static class BootstrapBuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration UseMobile<TAsyncContextExceptionHandler>(this BootstrapBuilderConfiguration config) 
            where TAsyncContextExceptionHandler : class, IAsyncContextExceptionHandler
        {
            return config
                .RegisterBuildAction(c => c.RegisterInstance<IAsyncContextExceptionHandler, TAsyncContextExceptionHandler>())
                .RegisterBuildAction(c => c.RegisterInstance<IThrottleFactory, ThrottleFactory>())
                .RegisterBuildAction(c => c.RegisterInstance<AlertUserHandler, AlertUserHandler>())
                .RegisterBuildAction(c => c.RegisterInstance<IAlerter, Alerter>())
                .RegisterBuildAction(c => c.RegisterInstance<IEmailViewNavigator, EmailViewNavigator>());
        }
    }
}