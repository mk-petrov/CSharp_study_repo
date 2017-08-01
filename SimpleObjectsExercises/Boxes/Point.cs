using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxes
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static double CalculateDistance(Point point1, Point point2)
        {
            var distanceX = Math.Pow((point2.X - point1.X), 2);
            var distanceY = Math.Pow((point2.Y - point1.Y), 2);

            var distance = Math.Sqrt(distanceX + distanceY);

            return distance;
        }
    }
}
