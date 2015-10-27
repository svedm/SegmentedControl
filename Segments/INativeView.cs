using Xamarin.Forms;

namespace Segments
{
    public interface INativeView<TView> where TView : View
    {
        TView FormsView { get; set; }
    }
}

