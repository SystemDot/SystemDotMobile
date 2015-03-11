using System;
using Android.App;
using Android.Content;
using Android.Widget;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating
{
    public abstract class CalculatorDialog : Dialog
    {
        readonly Calculator calculator;
        readonly Action onCancelled;

        protected CalculatorDialog(
            Context context, 
            Action onCancelled, 
            Calculator calculator) : base(context)
        {
            this.onCancelled = onCancelled;

            this.calculator = calculator;
            this.calculator.SetOutputAction(SetTitle);

            InflateView();
            HookupCalculatorButtons();
            SetOnCancel();
        }

        void HookupCalculatorButtons()
        {
            HookupNumericButton(Resource.Id.calculator_one);
            HookupNumericButton(Resource.Id.calculator_two);
            HookupNumericButton(Resource.Id.calculator_three);
            HookupNumericButton(Resource.Id.calculator_four);
            HookupNumericButton(Resource.Id.calculator_five);
            HookupNumericButton(Resource.Id.calculator_six);
            HookupNumericButton(Resource.Id.calculator_seven);
            HookupNumericButton(Resource.Id.calculator_eight);
            HookupNumericButton(Resource.Id.calculator_nine);
            HookupNumericButton(Resource.Id.calculator_zero);
            HookupButton(Resource.Id.calculator_period, calculator.AddPeriod);
            HookupButton(Resource.Id.calculator_plus, calculator.Add);
            HookupButton(Resource.Id.calculator_minus, calculator.Subtract);
            HookupButton(Resource.Id.calculator_times, calculator.Multiply);
            HookupButton(Resource.Id.calculator_divide, calculator.Divide);
            HookupButton(Resource.Id.calculator_equals, calculator.Calculate);
            HookupButton(Resource.Id.calculator_clear, calculator.Clear);
            HookupButton(Resource.Id.calculator_all_clear, calculator.AllClear);
            HookupButton(Resource.Id.calculator_set, Set);
            HookupButton(Resource.Id.calculator_cancel, Cancel);
        }

        void HookupNumericButton(int id)
        {
            var button = FindViewById<Button>(id);
            button.Click+= (sender, args) => calculator.AddNumber(int.Parse(button.Text));
        }

        void HookupButton(int id, Action action)
        {
            var button = FindViewById<Button>(id);
            button.Click += (sender, args) => action();
        }

        void InflateView()
        {
           SetContentView(Resource.Layout.calculator);
        }

        void SetOnCancel()
        {
            CancelEvent += (sender, args) => OnCancel();
        }

        void Set()
        {
            calculator.Calculate();
            OnValueSet(calculator.ToString());
            Dismiss();
        }

        protected abstract void OnValueSet(string value);

        void OnCancel()
        {
            onCancelled();
        }
    }
}