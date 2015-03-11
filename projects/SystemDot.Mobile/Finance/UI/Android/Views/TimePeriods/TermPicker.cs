using Android.Content;
using Android.Util;
using Rapidware.Financier.UI.Android.Views.Calculating;
using Rapidware.Financier.UI.Android.Views.Calculating.Integer;
using Rapidware.Financier.UI.Android.Views.Numbers;

namespace Rapidware.Financier.UI.Android.Views.Terms
{
    public class TermPicker : NumberPicker<Repayments.Repayments>
    {
        public TermPicker(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        protected override CalculatorDialog CreateDialog()
        {
            return new IntegerCalculatorDialog(Context, output => Number = output, Number);
        }
    }
}