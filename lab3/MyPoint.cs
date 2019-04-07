using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class MyPoint
    {
        public float X;
        public float Y;
        public bool NewStart = false;

        public MyPoint()
        {

        }

        public MyPoint(PointF _point, bool _ns=false)
        {
            X = _point.X;
            Y = _point.Y;
            NewStart = _ns;
        }

        public MyPoint(float _x, float _y, bool _ns=false)
        {
            X = _x;
            Y = _y;
            NewStart = _ns;
        }

        public PointF GetPoint()
        {
            return new PointF(X, Y);
        }

        public void SetPoint(float _x, float _y)
        {
            X = _x;
            Y = _y;
        }

        public bool IsNewStart()
        {
            return NewStart;
        }

        public void SetNewStart()
        {
            NewStart = true;
        }


    }
}
