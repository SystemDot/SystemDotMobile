using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Fractional;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Period;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Whole;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Decimal
{
    public class DecimalCalculator : Calculator
    {
        public DecimalCalculator(decimal startValue) 
            : base(startValue)
        {
        }

        protected override NumericPart GetNumberPartToAdd(int numberPart)
        {
            if (IsCurrentlyFractional()) return new FractionalNumericPart(numberPart);
            return new WholeNumericPart(numberPart);
        }

        protected override bool CanAddPeriod()
        {
            return true;
        }

        bool IsCurrentlyFractional()
        {
            return Sequence.IsLastPart<PeriodPart>()
                || Sequence.IsLastPart<FractionalNumericPart>();
        }
    }
}