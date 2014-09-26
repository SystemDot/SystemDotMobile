using SystemDot.Configuration;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static BuilderConfiguration UseMobile(this BuilderConfiguration config)
        {
            return config.RegisterBuildAction(c => c.RegisterInstance<IThrottleFactory, ThrottleFactory>());
        }
    } 
}