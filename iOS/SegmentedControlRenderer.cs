using System;
using Segments;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Segments.iOS;
using UIKit;

[assembly:ExportRenderer(typeof(SegmentedControl), typeof(SegmentedControlRenderer))]

namespace Segments.iOS
{
    public class SegmentedControlRenderer : ViewRenderer<SegmentedControl, UISegmentedControl>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<SegmentedControl> e)
        {
            base.OnElementChanged(e);

            var segmentedControl = new UISegmentedControl();
            segmentedControl.TintColor = UIColor.White;

            for (var i = 0; i < e.NewElement.Children.Count; i++)
            {
                segmentedControl.InsertSegment(e.NewElement.Children[i].Text, i, false);
            }

            segmentedControl.ValueChanged += (sender, eventArgs) =>
            {
                e.NewElement.SelectedValue = segmentedControl.TitleAt(segmentedControl.SelectedSegment);
            };

            segmentedControl.InsertSegment(new UIImage("activeDot.png"), 0, false);
            SetNativeControl(segmentedControl);
        }
    }  
}