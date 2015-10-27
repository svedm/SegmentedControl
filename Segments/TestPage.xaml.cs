using Xamarin.Forms;

namespace Segments
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            segmentControl.AddSegment(new Label { Text="Green" }, new Label { Text="test", FontSize=10 });
            segmentControl.AddSegment(new Label { Text="Yellow" });
            segmentControl.AddSegment(new Label { Text="Yellow" });
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

