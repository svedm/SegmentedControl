
using UIKit;
using Xamarin.Forms;
using Segments;
using Segments.iOS;

[assembly: ExportRenderer(typeof(TapContentView), typeof(BaseViewRenderer<TapContentView, TapContentViewNative>))]

namespace Segments.iOS
{
    public class TapContentViewNative : UIView, INativeView<TapContentView>
    {
        private UITapGestureRecognizer tapGestureRecognizer;
        private TapContentView formsView;

        public TapContentViewNative()
        {
            Initialize();
        }

        public TapContentView FormsView
        {
            get
            {
                return formsView;
            }
            set
            {
                formsView = value;
                tapGestureRecognizer.NumberOfTapsRequired = (System.nuint)formsView.NumberOfTapsRequired;
            }
        }
        private void Initialize()
        {
            tapGestureRecognizer = new UITapGestureRecognizer(TapGestureRecognizerAction);
            AddGestureRecognizer(tapGestureRecognizer);
        }

        private void TapGestureRecognizerAction()
        {
            if (FormsView != null && tapGestureRecognizer != null)
            {
                var location = tapGestureRecognizer.LocationOfTouch(0, this);
                FormsView.OnTapped((float)location.X, (float)location.Y);
            }
        }
    }
}

