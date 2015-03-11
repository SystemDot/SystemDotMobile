using SystemDot.Bootstrapping;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Bootstrap
{
    public static class BootstrapBuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration UseMobile(this BootstrapBuilderConfiguration config)
        {
            return config.RegisterBuildAction(c => c.RegisterInstance<IThrottleFactory, ThrottleFactory>());
        }
    }
}