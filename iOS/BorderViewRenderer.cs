using Segments;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Segments.iOS;

[assembly:ExportRenderer(typeof(BorderView), typeof(BorderViewRenderer))]

namespace Segments.iOS
{
    public class BorderViewRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (Element != null)
            { 
                CreateBorder(Element as BorderView);
            }
        }

        private void CreateBorder(BorderView element)
        {
            NativeView.Layer.MasksToBounds = true;
            NativeView.Layer.CornerRadius = element.CornerRadius;
            NativeView.Layer.BorderColor = element.BorderColor.ToCGColor();
            NativeView.Layer.BorderWidth = element.BorderWidth;
        }
    }
}