using Xamarin.Forms;

namespace Segments
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            segmentControl.AddSegment("Green");
            segmentControl.AddSegment("Yellow");
            segmentControl.AddSegment("Red");
        }

        private void OnSelectedSegmentChanged(object sender, int segmentIndex)
        {
            switch (segmentIndex)
            {
                case 0:
                    segmentControl.TintColor = Color.Green;
                    break;
                case 1:
                    segmentControl.TintColor = Color.Yellow;
                    break;
                case 2:
                    segmentControl.TintColor = Color.Red;
                    break;
            }
        }
    }
}

