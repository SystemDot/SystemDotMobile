using System;
using SystemDot.Core;
using SystemDot.Ioc;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.IoC;

namespace SystemDot.Mobile.Ioc
{
    public class MvxIocContainer : MvxSingleton<IMvxIoCProvider>, IMvxIoCProvider
    {
        readonly CallbackDictionary callbacks;

        public static IIocContainer GetInnerContainer()
        {
            return Instance.As<MvxIocContainer>().innerContainer;
        }

        readonly IocContainer innerContainer;

        public MvxIocContainer()
        {
            innerContainer = new IocContainer();
            callbacks = new CallbackDictionary();
        }

        public bool CanResolve<T>() where T : class
        {
            return innerContainer.ComponentExists<T>();
        }

        public bool CanResolve(Type type)
        {
            return innerContainer.ComponentExists(type);
        }

        public T Resolve<T>() where T : class
        {
            return innerContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return innerContainer.Resolve(type);
        }

        public T Create<T>() where T : class
        {
            return innerContainer.Create<T>();
        }

        public object Create(Type type)
        {
            return innerContainer.Create(type);
        }

        public T GetSingleton<T>() where T : class
        {
            return innerContainer.Resolve<T>();
        }

        public object GetSingleton(Type type)
        {
            return innerContainer.Resolve(type);
        }

        public bool TryResolve<T>(out T resolved) where T : class
        {
            resolved = null;

            if (CanResolve<T>()) resolved = Resolve<T>();

            return (resolved != null);
        }

        public bool TryResolve(Type type, out object resolved)
        {
            resolved = null;

            if (CanResolve(type)) resolved = Resolve(type);

            return (resolved != null);
        }

        public void RegisterType<TFrom, TTo>() where TFrom : class where TTo : class, TFrom
        {
            innerContainer.RegisterInstance<TFrom, TTo>();
            callbacks.CallBack<TFrom>();
        }

        public void RegisterType(Type tFrom, Type tTo)
        {
            innerContainer.RegisterInstance(tFrom, tTo);
            callbacks.CallBack(tFrom);
        }

        public void RegisterSingleton<TInterface>(TInterface theObject) where TInterface : class
        {
            innerContainer.RegisterInstance<TInterface>(() => theObject);
            callbacks.CallBack<TInterface>();
        }

        public void RegisterSingleton(Type tInterface, object theObject)
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton<TInterface>(Func<TInterface> theConstructor) where TInterface : class
        {
            innerContainer.RegisterInstance<TInterface>(theConstructor);
            callbacks.CallBack<TInterface>();
        }

        public void RegisterSingleton(Type tInterface, Func<object> theConstructor)
        {
            throw new NotImplementedException();
        }

        public T IoCConstruct<T>() where T : class
        {
            return innerContainer.Create<T>();
        }

        public object IoCConstruct(Type type)
        {
            return innerContainer.Create(type);
        }

        public void CallbackWhenRegistered<T>(Action action)
        {
            callbacks.Register<T>(action);
        }

        public void CallbackWhenRegistered(Type type, Action action)
        {
            callbacks.Register(type, action);
        }
    }
}