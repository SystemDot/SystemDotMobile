using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Util;

namespace SystemDot.Mobile.Typefacing
{
    public static class ContextExtensions
    {
        public static Typeface GetTypefaceFromAttributeValue(this Context context, IAttributeSet attrs)
        {
            return Typeface.CreateFromAsset(
                context.Assets,
                context.GetFontNameFromTypefaceAttribute(
                    attrs,
                    Resource.Styleable.TypefacedControl,
                    Resource.Styleable.TypefacedControl_typeface));
        }

        static string GetFontNameFromTypefaceAttribute(this Context context, IAttributeSet attrs, int[] controlAttr,
            int attr)
        {
            TypedArray styledAttrs = context.ObtainStyledAttributes(attrs, controlAttr);
            string fontName = styledAttrs.GetString(attr);
            styledAttrs.Recycle();

            return AddPathToFontName(fontName);
        }

        static string AddPathToFontName(string fontName)
        {
            return "fonts/" + fontName;
        }
    }
}