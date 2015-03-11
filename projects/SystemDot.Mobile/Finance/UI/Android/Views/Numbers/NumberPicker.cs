using System;
using SystemDot.Mobile.Typefacing;
using Android.Content;
using Android.Util;
using Rapidware.Financier.Finance.Mvvm;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating;

namespace Rapidware.Financier.Finance.UI.Android.Views.Numbers
{
    public abstract class NumberPicker<T> : TypefacedTextView 
        where T : INumber
    {
        T number;

        public T Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                SetText(Number);
                OnNumberChanged();
            }
        }

        public event EventHandler NumberChanged;

        protected NumberPicker(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialise(); 
        }

        void SetText(INumber toSet)
        {
            Text = !toSet.HasValue
                ? toSet.ZeroString
                : toSet.ToString();
        }

        void Initialise()
        {
            Click += OnClick;
        }

        void OnClick(object sender, EventArgs eventArgs)
        {
            CalculatorDialog dialog = CreateDialog();
            dialog.Show();
        }

        protected abstract CalculatorDialog CreateDialog();

        void OnNumberChanged()
        {
            if (NumberChanged == null) return;
            NumberChanged(this, EventArgs.Empty);
        }
    }
}