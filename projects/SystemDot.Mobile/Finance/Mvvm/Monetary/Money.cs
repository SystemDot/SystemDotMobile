using System;
using System.Globalization;
using SystemDot.Core;

namespace Rapidware.Financier.Finance.Mvvm.Monetary
{
    public class Money : Equatable<Money>, INumber
    {
        public static implicit operator decimal(Money @from)
        {
            return @from.value;
        }

        public static implicit operator Money(decimal @from)
        {
            return new Money(@from);
        }

        public static implicit operator Money(string @from)
        {
            if (String.IsNullOrEmpty(@from)) return Zero();

            return decimal.Parse(@from, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
        }

        readonly decimal value;

        public bool HasValue { get; private set; }

        public string ZeroString { get; private set; }

        public InputStatus Status { get; private set; }

        public Money(decimal value) : this()
        {
            HasValue = true;
            this.value = value;
        }

        public Money(decimal value, InputStatus status)
            : this(value)
        {
            Status = status;
        }

        Money()
        {
            ZeroString = "£0.00";
            Status = InputStatus.Incomplete;
        }

        public static Money Zero()
        {
            return new Money();
        }

        public Money Complete()
        {
            return new Money(value, InputStatus.Complete);
        }

        public Money Uncomplete()
        {
            return new Money(value, InputStatus.Incomplete);
        }

        public Money Invalidate()
        {
            return new Money(value, InputStatus.Invalid);
        }

        public override bool Equals(Money other)
        {
            return value == other.value;
        }

        //ncrunch: no coverage start
        public override string ToString()
        {
            return HasValue ? value.ToString("C") : string.Empty;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}