using Android.Content;
using Android.Util;
using Android.Widget;

namespace SystemDot.Mobile.Typefacing
{
    public class TypefacedToggleButton : ToggleButton
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public TypefacedToggleButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            if (IsInEditMode) return;

            Typeface = context.GetTypefaceFromAttributeValue(attrs);
        }
    }
}