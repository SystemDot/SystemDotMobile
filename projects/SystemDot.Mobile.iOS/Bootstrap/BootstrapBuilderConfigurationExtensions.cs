using SystemDot.Bootstrapping;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Bootstrap
{
    using SystemDot.Mobile.Alerts;

    public static class BootstrapBuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration UseMobile(this BootstrapBuilderConfiguration config)
        {
            return config
                .RegisterBuildAction(c => c.RegisterInstance<IThrottleFactory, ThrottleFactory>())
                .RegisterBuildAction(c => c.RegisterInstance<AlertUserHandler, AlertUserHandler>())
                .RegisterBuildAction(c => c.RegisterInstance<IAlerter, Alerter>())
                .RegisterBuildAction(c => c.RegisterInstance<IEmailViewNavigator, EmailViewNavigator>());
        }
    }
}