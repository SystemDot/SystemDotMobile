using SystemDot.Configuration;
using SystemDot.Domain.Configuration;

namespace SystemDot.Mobile.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static BuilderConfiguration UseMobile(this BuilderConfiguration config)
        {
            config.UseDomain();
            return config;
        }
    }
}