using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Graphics;
using Android.Views;
using Segments;
using Segments.Droid;
using Android.Graphics.Drawables;

//[assembly:ExportRenderer(typeof(SegmentedControl), typeof(SegmentedControlRenderer))]
//namespace Segments.Droid
//{
//    public class SegmentedControlRenderer : ViewRenderer<SegmentedControl, RadioGroup>
//    {
//
//        protected override void OnElementChanged(ElementChangedEventArgs<SegmentedControl> e)
//        {
//            base.OnElementChanged(e);
//
//
//            var g = new RadioGroup(Context);
//            g.Orientation = Orientation.Horizontal;
//           // g.LayoutParameters = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
//            g.CheckedChange += (sender, eventArgs) =>
//            {
//                var rg = (RadioGroup)sender;
//                if (rg.CheckedRadioButtonId != -1)
//                {
//                    var id = rg.CheckedRadioButtonId;
//                    var radioButton = rg.FindViewById(id);
//                    var radioId = rg.IndexOfChild(radioButton);
//                    var btn = (RadioButton)rg.GetChildAt(radioId);
//                    var selection = (String)btn.Text;
//                    e.NewElement.SelectedValue = selection;
//                }
//            };
//
//            for (var i = 0; i < e.NewElement.Children.Count; i++)
//            {
//                var o = e.NewElement.Children[i];
//                var v = new SegmentedControlButton(Context);
//                v.LayoutParameters = new LinearLayout.LayoutParams(200, 60,1);
//                v.SetBackgroundResource(Resource.Drawable.segmented_control_background);
//                v.Text = o.Text;
//                if (i == 0)
//                    v.SetBackgroundResource(Resource.Drawable.segmented_control_first_background);
//                else if (i == e.NewElement.Children.Count - 1)
//                    v.SetBackgroundResource(Resource.Drawable.segmented_control_last_background);
//                g.AddView(v);
//            }
//
//            SetNativeControl(g);
//        }
//    }
//
//    public class SegmentedControlButton : RadioButton
//    {
//        private static readonly StateListDrawable stateListDrawable = new StateListDrawable();
//        private int lineHeightSelected;
//        private int lineHeightUnselected;
//        private Paint linePaint;
//
//        public SegmentedControlButton(Context context)
//            : base(context)
//        {
//            Initialize();
//        }
//
//        private void Initialize()
//        {          
//            linePaint = new Paint();
//            linePaint.Color = Android.Graphics.Color.Red;
//            lineHeightUnselected = 0;
//            lineHeightSelected = 0;
//            SetButtonDrawable(stateListDrawable);
//        }
//
////        protected override void OnDraw(Canvas canvas)
////        {
////            base.OnDraw(canvas);
////
////            if (linePaint.Color != 0 && (lineHeightSelected > 0 || lineHeightUnselected > 0))
////            {
////                var lineHeight = Checked ? lineHeightSelected : lineHeightUnselected;
////
////                if (lineHeight > 0)
////                {
////                    var rect = new Rect(0, Height - lineHeight, Width, Height);
////                    canvas.DrawRect(rect, linePaint);
////                }
////            }
////        }
//    }
//}