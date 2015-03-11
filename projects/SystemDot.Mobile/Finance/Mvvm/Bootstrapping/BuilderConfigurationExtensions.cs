using SystemDot.Bootstrapping;

namespace Rapidware.Financier.Finance.Mvvm.Bootstrapping
{
    public static class BuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration ConfigureFinanceMvvm(this BootstrapBuilderConfiguration config)
        {
            return config.RegisterBuildAction(c => c.RegisterInstance<IViewModelNavigator, MvxViewModelNavigator>());
        }
    }
}