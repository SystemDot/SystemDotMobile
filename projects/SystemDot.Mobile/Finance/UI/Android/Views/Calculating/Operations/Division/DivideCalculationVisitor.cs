using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Division
{
    public class DivideCalculationVisitor : OperationCalculationVisitor<DividePart>
    {
        protected override bool IsInError(FullNumberPart toProcess)
        {
            return toProcess.Number == 0;
        }

        protected override FullNumberPart Calculate(FullNumberPart leftSide, FullNumberPart toProcess)
        {
            return leftSide / toProcess.Number;
        }
    }
}