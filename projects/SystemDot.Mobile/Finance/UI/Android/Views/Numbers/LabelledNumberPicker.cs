using System;
using SystemDot.Mobile.Typefacing;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Rapidware.Financier.Finance.Mvvm;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating;

namespace Rapidware.Financier.Finance.UI.Android.Views.Numbers
{
    public abstract class LabelledNumberPicker<T> : LinearLayout 
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
                OnNumberChanged();
            }
        }

        public string FieldName
        {
            get
            {
                return GetField().Text;
            }
            set
            {
                GetField().Text = value;
            }
        }

        public event EventHandler ButtonClick
        {
            add
            {
                GetButton().Click += value;
                ShowButton();
            }
            remove
            {
                GetButton().Click += value;
                HideButton();
            }
        }

        public event EventHandler NumberChanged;

        protected LabelledNumberPicker(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InflateView(context);
            SetPropertiesFromAttributes(context, attrs);
            SetupClick();
        }

        void InflateView(Context context)
        {
            LayoutInflater inflater = LayoutInflater.From(context);
            inflater.Inflate(Resource.Layout.labelled_number_picker, this);
        }

        void SetPropertiesFromAttributes(Context context, IAttributeSet attrs)
        {
            FieldName = context.GetFieldNameFromAttributeValue(attrs);
        }

        void SetupClick()
        {
            SetClickable();
            SetClick();
        }

        void SetClickable()
        {
            Clickable = true;
            GetIncompletePicker().Clickable = true;
            GetCompletePicker().Clickable = true;
            GetInvalidPicker().Clickable = true;
            GetField().Clickable = true;
        }

        void SetClick()
        {
            GetIncompletePicker().Click += OnControlClick;
            GetCompletePicker().Click += OnControlClick;
            GetInvalidPicker().Click += OnControlClick;
            GetField().Click += OnControlClick;
            Click += OnClick;
        }

        void OnControlClick(object sender, EventArgs eventArgs)
        {
            CallOnClick();
        }

        void OnClick(object sender, EventArgs eventArgs)
        {
            CalculatorDialog dialog = CreateDialog();
            dialog.Show();
        }

        protected abstract CalculatorDialog CreateDialog();

        void OnNumberChanged()
        {
            SetPickerVisibility(Number);
            SetPickerText(Number);
            if (NumberChanged == null) return;
            NumberChanged(this, new EventArgs());
        }

        void SetPickerVisibility(INumber toSet)
        {
            GetIncompletePicker().Visibility = Number.Status == InputStatus.Incomplete 
                ? ViewStates.Visible
                : ViewStates.Invisible;

            GetCompletePicker().Visibility = Number.Status == InputStatus.Complete 
                ? ViewStates.Visible 
                : ViewStates.Invisible;

            GetInvalidPicker().Visibility = Number.Status == InputStatus.Invalid 
                ? ViewStates.Visible 
                : ViewStates.Invisible; 
        }

        void SetPickerText(INumber toSet)
        {
            GetPicker().Text = !toSet.HasValue
                ? toSet.ZeroString
                : toSet.ToString();
        }

        TextView GetPicker()
        {
            if(Number.Status == InputStatus.Incomplete) return GetIncompletePicker();
            if(Number.Status == InputStatus.Complete) return GetCompletePicker();
            return GetInvalidPicker();
        }

        TypefacedTextView GetCompletePicker()
        {
            return FindViewById<TypefacedTextView>(Resource.Id.solver_number_complete_picker_value);
        }

        TypefacedTextView GetIncompletePicker()
        {
            return FindViewById<TypefacedTextView>(Resource.Id.solver_number_incomplete_picker_value);
        }

        TypefacedTextView GetInvalidPicker()
        {
            return FindViewById<TypefacedTextView>(Resource.Id.solver_number_invalid_picker_value);
        }

        TextView GetField()
        {
            return FindViewById<TypefacedTextView>(Resource.Id.solver_number_picker_field);
        }

        void HideButton()
        {
            GetButton().Visibility = ViewStates.Invisible;
        }

        void ShowButton()
        {
            GetButton().Visibility = ViewStates.Visible;
        }

        ImageButton GetButton()
        {
            return FindViewById<ImageButton>(Resource.Id.solver_number_picker_button);
        }
    }
}