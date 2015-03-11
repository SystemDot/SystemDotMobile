using SystemDot.Core;

namespace Rapidware.Financier.Finance.Mvvm.Rates
{
    public class Rate : Equatable<Rate>, INumber
    {
        public static implicit operator decimal(Rate @from)
        {
            return @from.value;
        }

        public static implicit operator Rate(decimal @from)
        {
            return new Rate(@from);
        }

        readonly decimal value;

        public bool HasValue { get; private set; }

        public string ZeroString { get; private set; }

        public InputStatus Status { get; private set; }

        Rate(decimal value, InputStatus status)
            : this(value)
        {
            Status = status;
        }

        public Rate(decimal value) : this()
        {
            HasValue = true;
            this.value = value;
        }

        Rate()
        {
            ZeroString = "0%"; 
            Status = InputStatus.Incomplete;
        }

        public static Rate Zero()
        {
            return new Rate();
        }

        public Rate Complete()
        {
            return new Rate(value, InputStatus.Complete);
        }

        public Rate Uncomplete()
        {
            return new Rate(value, InputStatus.Incomplete);
        }

        public Rate Invalidate()
        {
            return new Rate(value, InputStatus.Invalid);
        }

        public override bool Equals(Rate other)
        {
            return other.value == value;
        }

        //ncrunch: no coverage start
        public override string ToString()
        {
            return string.Format("{0}%", value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}