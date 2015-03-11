using System;
using Android.Content;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Decimal
{
    public class DecimalCalculatorDialog : CalculatorDialog
    {
        readonly Action<decimal> onValueSet;

        public DecimalCalculatorDialog(
            Context context,
            Action<decimal> onValueSet,
            decimal startValue)
            : base(context, () => { }, new DecimalCalculator(startValue))
        {
            this.onValueSet = onValueSet;
        }

        protected override void OnValueSet(string value)
        {
            onValueSet(decimal.Parse(value));
        }
    }
}