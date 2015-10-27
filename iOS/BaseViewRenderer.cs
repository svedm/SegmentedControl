using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Segments.iOS
{
    public class BaseViewRenderer<TView, TNativeView> : ViewRenderer<TView, TNativeView>
        where TView : View where TNativeView : UIKit.UIView, INativeView<TView>
    {
        private readonly ViewPropertiesHelper propertiesHelper;

        public BaseViewRenderer()
        {
            propertiesHelper = new ViewPropertiesHelper(typeof(TView), typeof(TNativeView));
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null && Element != null)
            {
                InitializeNativeViewControl(Element);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            propertiesHelper.SetPropertyValue(e.PropertyName, Control, Element);
        }

        private void InitializeNativeViewControl(TView element)
        {
            var constructor = typeof(TNativeView).GetConstructor(new Type[]{ });
            var nativeView = constructor.Invoke(new object[]{ }) as TNativeView;
            nativeView.FormsView = element;
            SetNativeControl(nativeView);
            propertiesHelper.SetAllPropertyValues(Control, Element);
        }
    }
}

