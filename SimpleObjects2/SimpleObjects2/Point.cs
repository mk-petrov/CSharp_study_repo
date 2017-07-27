
namespace SimpleObjects2
{
    public class Point
    {
        public double CoordinateX { get; set; }

        public double CoordinateY { get; set; }

        public string PrintCoordinates()
        {
            return $"({CoordinateX}, {CoordinateY})";
        }
    }
}
