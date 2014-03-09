using SystemDot.Configuration;
using SystemDot.Ioc;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(c => c.RegisterFromAssemblyOf<ThrottleFactory>());
        }
    } 
}