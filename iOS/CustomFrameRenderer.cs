using Segments;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Segments.iOS;
using UIKit;

[assembly:ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]

namespace Segments.iOS
{
    public class CustomFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {            
            base.OnElementChanged(e);
            NativeView.Layer.MasksToBounds = true;
            NativeView.Layer.CornerRadius = 5;
            NativeView.Layer.BorderColor = UIColor.Gray.CGColor;
            NativeView.Layer.BorderWidth = 1;
        }
    }  
}