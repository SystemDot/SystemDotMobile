using System;
using System.Linq.Expressions;
using SystemDot.Mobile.Mvvm;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Throttling
{
    public interface IThrottler<TObserved> where TObserved : ViewModel<TObserved>
    {
        void ThrottleActionOnPropertyChange<TProperty>(
            TObserved model,
            Func<TObserved, INotifyChange<TProperty>> property, 
            Action throttleAction, 
            TimeSpan throttleTime);

        void ThrottleActionOnMainThreadOnPropertyChange<TProperty>(
            TObserved model,
            Func<TObserved, INotifyChange<TProperty>> property,
            Action throttleAction,
            TimeSpan throttleTime);
    }
}
