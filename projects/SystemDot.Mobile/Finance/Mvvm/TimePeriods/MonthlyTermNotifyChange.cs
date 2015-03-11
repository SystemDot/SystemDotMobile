using Cirrious.MvvmCross.FieldBinding;

namespace Rapidware.Financier.Finance.Mvvm.TimePeriods
{
    using System;

    public class MonthlyTermNotifyChange : NotifyChange<MonthlyTerm>
    {
        public MonthlyTermNotifyChange() : base(MonthlyTerm.Zero())
        {
        }

        public MonthlyTermNotifyChange(Action<MonthlyTerm> onChanged)
            : base(MonthlyTerm.Zero(), onChanged)
        {
        }

        public void Zero()
        {
            Value = MonthlyTerm.Zero();
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