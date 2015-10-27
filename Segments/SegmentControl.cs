using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Segments
{
    /// <summary>
    /// Class SegmentControl.
    /// </summary>
    public class SegmentControl : BorderView
    {
        /// <summary>
        /// The layout
        /// </summary>
        private readonly StackLayout _layout;

        /// <summary>
        /// The tint color
        /// </summary>
        private Color _tintColor = Color.Black;

        /// <summary>
        /// Gets or sets the color of the tint.
        /// </summary>
        /// <value>The color of the tint.</value>
        public Color TintColor
        {
            get { return _tintColor; }
            set
            {
                _tintColor = value;

                if (_layout == null)
                {
                    return;
                }

                _layout.BackgroundColor = _tintColor;

                for (var iBtn = 0; iBtn < _layout.Children.Count; iBtn++)
                {
                    SetSelectedState(iBtn, iBtn == _selectedSegment, true);
                }
            }
        }

        /// <summary>
        /// The selected segment
        /// </summary>
        private int _selectedSegment;

        /// <summary>
        /// Gets or sets the selected segment.
        /// </summary>
        /// <value>The selected segment.</value>
        public int SelectedSegment
        {
            get
            {
                return _selectedSegment;
            }
            set
            {
                //reset the original selected segment
                if (value == _selectedSegment)
                {
                    return;
                }

                SetSelectedState(_selectedSegment, false);
                _selectedSegment = value;

                if (value < 0 || value >= _layout.Children.Count)
                {
                    return;
                }

                SetSelectedState(_selectedSegment, true);
            }
        }

        /// <summary>
        /// Occurs when [selected segment changed].
        /// </summary>
        public event EventHandler<int> SelectedSegmentChanged;

        /// <summary>
        /// The clicked command
        /// </summary>
        private readonly Command _clickedCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentControl"/> class.
        /// </summary>
        public SegmentControl()
        {
            _layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(1),
                Spacing = 1
            };

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Start;
            Padding = new Thickness(0, 0);
            Content = _layout;

            _selectedSegment = 0;
            _clickedCommand = new Command(SetSelectedSegment);
        }

        /// <summary>
        /// Adds the segment.
        /// </summary>
        /// <param name="segmentText">The segment text.</param>
        public void AddSegment(params Label[] labels)
        {
            if (labels == null)
            {
                throw new ArgumentException("labels cannot be empty");
            }

            var verticalStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,     
            };

            foreach (var label in labels)
            {
                verticalStack.Children.Add(label);
            }

            var tapView = new TapContentView
            {
                Content = verticalStack,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            
            _layout.BackgroundColor = TintColor;
            _layout.Children.Add(tapView);

            SetSelectedState(_layout.Children.Count - 1, _layout.Children.Count - 1 == _selectedSegment);
        }

        /// <summary>
        /// Sets the selected segment.
        /// </summary>
        /// <param name="o">The o.</param>
        private void SetSelectedSegment(object o)
        {
            var selectedIndex = (int)o;

            SelectedSegment = selectedIndex;

            if (SelectedSegmentChanged != null)
            {
                SelectedSegmentChanged(this, selectedIndex);
            }
        }

        /// <summary>
        /// Sets the segment text.
        /// </summary>
        /// <param name="iSegment">The i segment.</param>
        /// <param name="segmentText">The segment text.</param>
        /// <exception cref="System.IndexOutOfRangeException">SetSegmentText: Attempted to change segment text for a segment doesn't exist.</exception>
        public void SetSegmentText(int iSegment, string segmentText)
        {
            if (iSegment >= _layout.Children.Count || iSegment < 0)
            {
                throw new IndexOutOfRangeException("SetSegmentText: Attempted to change segment text for a segment doesn't exist.");
            }

            ((Button)_layout.Children[iSegment]).Text = segmentText;
        }

        /// <summary>
        /// Sets the state of the selected.
        /// </summary>
        /// <param name="indexer">The indexer.</param>
        /// <param name="isSelected">if set to <c>true</c> [is selected].</param>
        /// <param name="setBorderColor">if set to <c>true</c> [set border color].</param>
        private void SetSelectedState(int indexer, bool isSelected, bool setBorderColor = false)
        {
            if (_layout.Children.Count <= indexer)
            {
                return; //Out of bounds
            }

            var tapView = (TapContentView)_layout.Children[indexer];

            // TODO: TextColor needs to be a bound property
            if (isSelected)
            {
                tapView.BackgroundColor = TintColor;
                foreach (Label label in ((StackLayout)tapView.Content).Children)
                {
                    label.TextColor = Color.White;
                }
            }
            else
            {
                tapView.BackgroundColor = Color.White;
                foreach (Label label in ((StackLayout)tapView.Content).Children)
                {
                    label.TextColor = TintColor;
                }
            }

            if (setBorderColor)
            {
                //button.BorderColor = TintColor;
            }
        }
    }
}