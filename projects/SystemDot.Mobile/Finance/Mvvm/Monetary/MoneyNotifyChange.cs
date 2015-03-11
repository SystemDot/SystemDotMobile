using Cirrious.MvvmCross.FieldBinding;

namespace Rapidware.Financier.Finance.Mvvm.Monetary
{
    using System;

    public class MoneyNotifyChange : NotifyChange<Money>
    {

        public MoneyNotifyChange()
            : base(Money.Zero())
        {
        }

        public MoneyNotifyChange(Action<Money> onChanged)
            : base(Money.Zero(), onChanged)
        {
        }

        public void FromDecimal(decimal value)
        {
            Value = new Money(value);
        }

        public void Zero()
        {
            Value = Money.Zero();
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