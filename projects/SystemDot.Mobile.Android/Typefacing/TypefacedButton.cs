using Android.Content;
using Android.Util;
using Android.Widget;

namespace SystemDot.Mobile.Typefacing
{
    public class TypefacedButton : Button
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public TypefacedButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            if (IsInEditMode) return;

            Typeface = context.GetTypefaceFromAttributeValue(attrs);
        }
    }
}