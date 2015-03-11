using Android.Content;
using Android.Util;
using Rapidware.Financier.Finance.Mvvm.TimePeriods;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Integer;
using Rapidware.Financier.Finance.UI.Android.Views.Numbers;

namespace Rapidware.Financier.Finance.UI.Android.Views.TimePeriods
{
    public class LabelledMonthlyTermPicker : LabelledNumberPicker<MonthlyTerm>
    {
        public LabelledMonthlyTermPicker(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        protected override CalculatorDialog CreateDialog()
        {
            return new IntegerCalculatorDialog(Context, output => Number = output, Number);
        }
    }
}