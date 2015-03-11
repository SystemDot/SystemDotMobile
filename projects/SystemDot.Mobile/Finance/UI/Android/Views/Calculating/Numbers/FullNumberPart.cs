using SystemDot.Core;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Whole;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Addition;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Division;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Multiplication;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Subtraction;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers
{
    public class FullNumberPart : CalculationPart
    {
        public static implicit operator decimal(FullNumberPart @from)
        {
            return @from.Number;
        }

        public static implicit operator FullNumberPart(decimal @from)
        {
            if(@from == 0) return new EmptyFullNumberPart();
            if(@from.HasPrecision()) return new IntegerFullNumberPart(@from);
            return new DecimalFullNumberPart(@from);
        }

        public decimal Number { get; protected set; }

        protected FullNumberPart()
        {
            AllowToBeReplacedBy<WholeNumericPart>();
            AllowToBeFollowedBy<AddPart>();
            AllowToBeFollowedBy<SubtractPart>();
            AllowToBeFollowedBy<DividePart>();
            AllowToBeFollowedBy<MultiplyPart>();
        }
    }
}