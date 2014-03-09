using SystemDot.Configuration;

namespace SystemDot.Mobile.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static BuilderConfiguration UseAndroidMobile(this BuilderConfiguration config)
        {
            config.UseMobile();
            return config;
        }
    }
}