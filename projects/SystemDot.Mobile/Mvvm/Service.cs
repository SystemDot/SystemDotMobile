namespace SystemDot.Mobile.Mvvm
{
    using System;
    using System.Collections.Generic;
    using SystemDot.Messaging.Handling.Actions;
    using SystemDot.Messaging.Simple;

    public abstract class Service
    {
        readonly List<IActionSubscriptionToken> tokens;

        readonly Dispatcher dispatcher;

        protected Service(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        protected void Alert(string message)
        {
            dispatcher.SendAlert(message);
        }

        protected void When<T>(Action<T> whenAction)
        {
            tokens.Add(dispatcher.RegisterHandler(whenAction));
        }
    }
}