using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab3
{
    class BezierCurve
    {
        public List<MyPoint> BezierCurvePoints;
        public MyPoint StartPoint;
        public MyPoint MiddlePoint;
        public MyPoint EndPoint;
        public bool PointChanged;

        public BezierCurve(MyPoint _start, MyPoint _mid, MyPoint _end)
        {
            StartPoint = _start;
            MiddlePoint = _mid;
            EndPoint = _end;
            PointChanged = false;
            BezierCurvePoints = CalculatePoints();
        }

        public BezierCurve(float _sx, float _sy, float _mx, float _my, float _ex, float _ey)
        {

            MyPoint start = new MyPoint(_sx, _sy);
            MyPoint mid = new MyPoint(_mx, _my);
            MyPoint end = new MyPoint(_ex, _ey);

            StartPoint = start;
            MiddlePoint = mid;
            EndPoint = end;
            PointChanged = false;
            BezierCurvePoints = CalculatePoints();
        }

        public void Validate()
        {
            BezierCurvePoints = CalculatePoints();
        }

        private List<MyPoint> CalculatePoints()
        {
            List<MyPoint> pointsToReturn = new List<MyPoint>();
            for(float t = 0; t <= 1; t += (float)0.01)
            {
                MyPoint newPoint = new MyPoint
                {
                    X = (float)(Math.Pow((1 - t), 2) * StartPoint.X + 2 * (1 - t) * t * MiddlePoint.X + Math.Pow(t, 2) * EndPoint.X),
                    Y = (float)(Math.Pow((1 - t), 2) * StartPoint.Y + 2 * (1 - t) * t * MiddlePoint.Y + Math.Pow(t, 2) * EndPoint.Y)
                };
                if (t == 0) newPoint.NewStart = true;
                pointsToReturn.Add(newPoint);
            }

            return pointsToReturn;
        }

    }
}
