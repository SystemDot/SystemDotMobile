using SystemDot.Configuration;
using SystemDot.Mobile.Mvvm;

namespace SystemDot.Mobile.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(c => c.RegisterInstance<ViewModelContext, ViewModelContext>());
            builder.RegisterBuildAction(c => c.RegisterInstance<ViewModelLocator, ViewModelLocator>());
        }
    }
}