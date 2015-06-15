namespace SystemDot.Mobile.Typefacing
{
    using Android.Content;
    using Android.Util;
    using Android.Widget;

    public class TypefacedEditText : EditText
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public TypefacedEditText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            if (IsInEditMode) return;

            Typeface = context.GetTypefaceFromAttributeValue(attrs);
        }
    }
}