using System;

namespace Segments
{
    public class TapEventArgs : EventArgs
    {
        public TapEventArgs(float x, float y) : base()
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }

        public float Y { get; set; }
    }
}