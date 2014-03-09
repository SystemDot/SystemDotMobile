using SystemDot.Configuration;
using SystemDot.Ioc;
using SystemDot.Mobile.Mvvm;

namespace SystemDot.Mobile.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(c => c.RegisterFromAssemblyOf<ViewModelContext>());
        }
    }
}