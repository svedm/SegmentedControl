using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using System;
using Segments;
using Segments.Droid;

[assembly: ExportRenderer(typeof(TapContentView), typeof(BaseViewRenderer<TapContentView, TapContentViewNative>))]

namespace Segments.Droid
{
    public class TapContentViewNative : LinearLayout, INativeView<TapContentView>, Android.Views.View.IOnTouchListener, Android.Views.View.IOnClickListener
    {
        private const int DELAY_BETWEEN_TAPS = 400;
        private float lastTapX;
        private float lastTapY;
        private int tapCount;
        private bool isTimerSet;

        public TapContentViewNative(Context context)
            : base(context)
        {
            Initialize();
        }

        public TapContentViewNative(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize();
        }

        public TapContentViewNative(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            Initialize();
        }

        public TapContentView FormsView
        { 
            get; 
            set; 
        }

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                lastTapX = GetDpFromPx(e.GetX());
                lastTapY = GetDpFromPx(e.GetY());
            }
            return false;
        }

        public void OnClick(Android.Views.View v)
        {
            if (FormsView != null && FormsView.NumberOfTapsRequired > 0)
            {
                if (FormsView.NumberOfTapsRequired == 1)
                {
                    FormsView.OnTapped(lastTapX, lastTapY);
                }
                else
                {
                    TapGestuer();
                }
            }
        }

        private float GetDpFromPx(float value)
        {            
            return value / (float)Context.Resources.DisplayMetrics.Density;
        }

        private void Initialize()
        {
            SetOnTouchListener(this);
            SetOnClickListener(this);
        }

        private void TapGestuer()
        {
            if (++tapCount >= FormsView.NumberOfTapsRequired)
            {
                tapCount = 0;
                FormsView.OnTapped(lastTapX, lastTapY);
            }

            if (!isTimerSet)
            {
                isTimerSet = true;
                Device.StartTimer(TimeSpan.FromMilliseconds(DELAY_BETWEEN_TAPS * (FormsView.NumberOfTapsRequired - 1)), () =>
                    {
                        isTimerSet = false;
                        tapCount = 0;
                        return false;
                    });
            }
        }
    }
}

