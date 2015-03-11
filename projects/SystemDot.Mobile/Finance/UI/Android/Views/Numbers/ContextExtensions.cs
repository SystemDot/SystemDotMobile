using Android.Content;
using Android.Content.Res;
using Android.Util;

namespace Rapidware.Financier.Finance.UI.Android.Views.Numbers
{
    public static class ContextExtensions
    {
        public static string GetFieldNameFromAttributeValue(this Context context, IAttributeSet attrs)
        {
            return context.GetStringValueFromAttribute(
                attrs,
                Resource.Styleable.LabelledNumberPicker,
                Resource.Styleable.LabelledNumberPicker_fieldName);
        }

        static string GetStringValueFromAttribute(this Context context, IAttributeSet attrs, int[] controlAttr, int attr)
        {
            TypedArray styledAttrs = context.ObtainStyledAttributes(attrs, controlAttr);
            string value = styledAttrs.GetString(attr);
            styledAttrs.Recycle();

            return value;
        }
    }
}