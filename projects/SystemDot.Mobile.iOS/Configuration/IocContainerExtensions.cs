using SystemDot.Ioc;

namespace SystemDot.Mobile.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterMobile(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<IDummyForRegistration>();
        }

        interface IDummyForRegistration
        { 
        }
    }
}