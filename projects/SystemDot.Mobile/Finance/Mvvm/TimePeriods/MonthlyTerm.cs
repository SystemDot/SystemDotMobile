using SystemDot.Core;

namespace Rapidware.Financier.Finance.Mvvm.TimePeriods
{
    public class MonthlyTerm : Equatable<MonthlyTerm>, INumber
    {
        public static implicit operator int(MonthlyTerm @from)
        {
            return @from.value;
        }

        public static implicit operator MonthlyTerm(int @from)
        {
            return new MonthlyTerm(@from);
        }

        readonly int value;

        public bool HasValue { get; private set; }

        public string ZeroString { get; private set; }

        public InputStatus Status { get; private set; }

        MonthlyTerm(int value, InputStatus status) : this(value)
        {
            Status = status;
        }

        public MonthlyTerm(int value) : this()
        {
            HasValue = true;
            this.value = value;
        }

        MonthlyTerm()
        {
            ZeroString = "0 Months";
            Status = InputStatus.Incomplete;
        }

        public static MonthlyTerm Zero()
        {
            return new MonthlyTerm();
        }

        public MonthlyTerm Complete()
        {
            return new MonthlyTerm(value, InputStatus.Complete);
        }

        public MonthlyTerm Uncomplete()
        {
            return new MonthlyTerm(value, InputStatus.Incomplete);
        }

        public MonthlyTerm Invalidate()
        {
            return new MonthlyTerm(value, InputStatus.Invalid);
        }

        public override bool Equals(MonthlyTerm other)
        {
            return value == other.value;
        }

        //ncrunch: no coverage start
        public override string ToString()
        {
            return this.value == 1 
                ? "1 Month" 
                : string.Format("{0} Months", value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}