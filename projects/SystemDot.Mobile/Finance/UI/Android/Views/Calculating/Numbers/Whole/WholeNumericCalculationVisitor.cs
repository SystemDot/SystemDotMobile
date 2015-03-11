namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Whole
{
    public class WholeNumericCalculationVisitor : NumericCalculationVisitor<WholeNumericPart>
    {
        protected override FullNumberPart ProcessNumericCharacter(FullNumberPart currentNumber, WholeNumericPart toProcess)
        {
            return (currentNumber * 10) + toProcess.GetNumber();
        }
    }
}