using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Segments
{
    public class TapContentView : ContentView
    {
        public static readonly BindableProperty TapCommandProperty = 
            BindableProperty.Create<TapContentView, ICommand>(
                p => p.TapCommand, default(ICommand));

        public static readonly BindableProperty TapCommandParameterProperty = 
            BindableProperty.Create<TapContentView, object>(
                p => p.TapCommandParameter, default(object));

        public static readonly BindableProperty NumberOfTapsRequiredProperty =
            BindableProperty.Create<TapContentView, int>(p => p.NumberOfTapsRequired, 1);

        public event EventHandler<TapEventArgs> Tapped;

        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }

        public object TapCommandParameter
        {
            get { return (object)GetValue(TapCommandParameterProperty); }
            set { SetValue(TapCommandParameterProperty, value); }
        }

        public int NumberOfTapsRequired
        {
            get { return (int)GetValue(NumberOfTapsRequiredProperty); }
            set { SetValue(NumberOfTapsRequiredProperty, value); }
        }

        public void OnTapped(float x = 0, float y = 0)
        {
            if (TapCommand != null)
            {
                TapCommand.Execute(TapCommandParameter);
            }
            else
            {
                RaiseTapEvent(x, y);
            }
        }

        private void RaiseTapEvent(float x, float y)
        {
            var tapped = Tapped;
            if (tapped != null)
            {
                tapped(this, new TapEventArgs(x, y));
            }
        }
    }
}