using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Segments
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();

            var segment = new SegmentControl
            {
                TintColor = Color.Green
            };

            segment.AddSegment(new Label { Text="Green" }, new Label { Text="test", FontSize=10 });
            segment.AddSegment(new Label { Text="Yellow" });
            segment.AddSegment(new Label { Text="Yellow" });

            segment.SelectedSegmentChanged += (sender, segmentIndex) =>
            {
                switch (segmentIndex)
                {
                    case 0:
                        segment.TintColor = Color.Green;
                        break;
                    case 1:
                        segment.TintColor = Color.Yellow;
                        break;
                    case 2:
                        segment.TintColor = Color.Red;
                        break;
                }
            };

            this.layout.Children.Add(segment);
        }
    }
}

