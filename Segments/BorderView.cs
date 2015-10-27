using Xamarin.Forms;

namespace Segments
{
    public class BorderView:ContentView
    {     
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create<BorderView, int>(p => p.BorderWidth, 0);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create<BorderView, int>(p => p.CornerRadius, 0);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create<BorderView, Color>(p => p.BorderColor, Color.White);
        
        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }
       
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
}