
namespace Boxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rectangulares = new List<Rectangular>();
            var line = Console.ReadLine();

            while ( !line.Equals("end"))
            {
                var rectangular = ParseInputToRectangular(line);

                rectangulares.Add(rectangular);

                line = Console.ReadLine();
            }

            foreach (var rectangular in rectangulares)
            {
                Console.WriteLine();
                Console.WriteLine($"Box: {rectangular.Width}, {rectangular.Height}");
                Console.WriteLine($"Perimeter: " +
                    $"{Rectangular.CalculatePerimeter(rectangular.Width, rectangular.Height)}");
                Console.WriteLine($"Area:" +
                    $" {Rectangular.CalculateArea(rectangular.Width, rectangular.Height)}");
            }

        }

        public static Rectangular ParseInputToRectangular(string line)
        {
            var input = line
                .Split(new char[] { ' ', '|', ':' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var upperLeft = new Point
            {
                X = input[0],
                Y = input[1]
            };

            var upperRight = new Point
            {
                X = input[2],
                Y = input[3]
            };

            var bottomLeft = new Point
            {
                X = input[4],
                Y = input[5]
            };

            var bottomRight = new Point
            {
                X = input[6],
                Y = input[7]
            };

            var rectangular = new Rectangular
            {
                UpperLeft = upperLeft,
                UpperRight = upperRight,
                BottomLeft = bottomLeft,
                BottomRight = bottomRight
            };

            return rectangular;
        }
    }
}
