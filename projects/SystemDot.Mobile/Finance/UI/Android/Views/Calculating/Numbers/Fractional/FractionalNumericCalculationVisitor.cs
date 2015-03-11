namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Fractional
{
    public class FractionalNumericCalculationVisitor : NumericCalculationVisitor<FractionalNumericPart>
    {
        const decimal StartPrecision = 0.1M;

        decimal precision;

        public FractionalNumericCalculationVisitor()
        {
            precision = StartPrecision;
        }

        protected override void Reset()
        {
            base.Reset();
            precision = StartPrecision;
        }

        protected override FullNumberPart ProcessNumericCharacter(FullNumberPart currentNumber, FractionalNumericPart toProcess)
        {
            decimal fractional = toProcess.GetNumber() * precision;
            precision /= 10;
            return currentNumber + fractional;
        }
    }
}