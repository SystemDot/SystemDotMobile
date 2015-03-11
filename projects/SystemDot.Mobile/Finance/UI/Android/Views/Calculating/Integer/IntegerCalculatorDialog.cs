using System;
using Android.Content;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Integer
{
    public class IntegerCalculatorDialog : CalculatorDialog
    {
        readonly Action<int> onValueSet;

        public IntegerCalculatorDialog(
            Context context, 
            Action<int> onValueSet,
            int startValue)
            : base(context, () => { }, new IntegerCalculator(startValue))
        {
            this.onValueSet = onValueSet;
        }

        protected override void OnValueSet(string value)
        {
            onValueSet(int.Parse(value));
        }
    }
}