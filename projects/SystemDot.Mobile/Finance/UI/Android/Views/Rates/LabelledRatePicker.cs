using Android.Content;
using Android.Util;
using Rapidware.Financier.Finance.Mvvm.Rates;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Decimal;
using Rapidware.Financier.Finance.UI.Android.Views.Numbers;

namespace Rapidware.Financier.Finance.UI.Android.Views.Rates
{
    public class LabelledRatePicker : LabelledNumberPicker<Rate>
    {
        public LabelledRatePicker(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        protected override CalculatorDialog CreateDialog()
        {
            return new DecimalCalculatorDialog(Context, output => Number = output, Number);
        }
    }
}