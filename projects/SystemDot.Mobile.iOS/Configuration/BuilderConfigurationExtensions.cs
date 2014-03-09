using SystemDot.Configuration;

namespace SystemDot.Mobile.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static BuilderConfiguration UseiOSMobile(this BuilderConfiguration config)
        {
            config.UseMobile();
            return config;
        }
    }
}