using System.Globalization;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Addition;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Division;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Multiplication;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Subtraction;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers
{
    public abstract class NumericPart : CalculationPart
    {
        readonly int number;

        protected NumericPart(int number)
        {
            this.number = number;

            AllowToBeFollowedBy<AddPart>();
            AllowToBeFollowedBy<MultiplyPart>();
            AllowToBeFollowedBy<SubtractPart>();
            AllowToBeFollowedBy<DividePart>();
        }

        public decimal GetNumber()
        {
            return number;
        }

        public override string ToString()
        {
            return number.ToString(CultureInfo.InvariantCulture);
        }
    }
}