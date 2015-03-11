using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Whole;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Integer
{
    public class IntegerCalculator : Calculator
    {
        public IntegerCalculator(int startValue) 
            : base(startValue)
        {
        }

        protected override NumericPart GetNumberPartToAdd(int numberPart)
        {
            return new WholeNumericPart(numberPart);
        }

        protected override bool CanAddPeriod()
        {
            return false;
        }
    }
}