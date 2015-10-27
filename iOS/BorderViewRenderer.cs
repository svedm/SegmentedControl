using Segments;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Segments.iOS;
using UIKit;

[assembly:ExportRenderer(typeof(BorderView), typeof(BorderViewRenderer))]

namespace Segments.iOS
{
    public class BorderViewRenderer : ViewRenderer
    {
       protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            NativeView.Layer.MasksToBounds = true;
            NativeView.Layer.CornerRadius = 5;
            NativeView.Layer.BorderColor = UIColor.Gray.CGColor;
            NativeView.Layer.BorderWidth = 1;
        }
    }  
}