using SystemDot.Ioc;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterMobile(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<ThrottleFactory>();
        }
    }
}