using Cirrious.MvvmCross.FieldBinding;

namespace Rapidware.Financier.Finance.Mvvm.Rates
{
    using System;

    public class RateNotifyChange : NotifyChange<Rate>
    {
        public RateNotifyChange() : base(Rate.Zero())
        {
        }

        public RateNotifyChange(Action<Rate> onChanged)
            : base(Rate.Zero(), onChanged)
        {
        }

        public void Zero()
        {
            Value = Rate.Zero();
        }

        public void Complete()
        {
            Value = Value.Complete();
        }

        public void Uncomplete()
        {
            Value = Value.Uncomplete();
        }

        public void Invalidate()
        {
            Value = Value.Invalidate();
        }

        //ncrunch: no coverage start
        public override string ToString()
        {
            return Value.ToString();
        }
    }    
}