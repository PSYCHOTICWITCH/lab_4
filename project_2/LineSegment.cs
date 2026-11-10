using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_project_2
{
    internal class LineSegment
    {
        private double _x;
        private double _y;

        public LineSegment(double x, double y)
        {
            if (x > y)
            {
                _x = y;
                _y = x;
            }
            else
            {
                _x = x;
                _y = y;
            }
        }

        public override string ToString()
        {
            if (_x == _y)
            {
                return $"Точка: координата - {_x}";
            }
            return $"Отрезок: начало - {_x}, конец - {_y}";
        }

        public static bool IsIntersect(LineSegment segment1, LineSegment segment2)
        {
            return (segment2._x <= segment1._x && segment1._x <= segment2._y)
                || (segment1._x <= segment2._x && segment2._x <= segment1._y);
        }

        public static double operator !(LineSegment L)
        {
            return L._y - L._x;
        } 

        public static LineSegment operator ++(LineSegment L)
        {
            L._x--;
            L._y++;
            return L;
        }

        public static explicit operator double(LineSegment L) 
        { 
            return L._y;
        }

        public static implicit operator int(LineSegment L) 
        { 
            return (int)L._x;
        }

        public static LineSegment operator -(LineSegment L, int N)
        {
            LineSegment result = new LineSegment(L._x - N, L._y);
            return result;
        }
        public static LineSegment operator -(int N, LineSegment L)
        {
            LineSegment result = new LineSegment(L._x, L._y - N);
            return result;
        }

        public static bool operator <(LineSegment L1, LineSegment L2)
        {
            return IsIntersect(L1, L2);
        }

        public static bool operator >(LineSegment L1, LineSegment L2)
        {
            return IsIntersect(L1, L2);
        }
    }
}
