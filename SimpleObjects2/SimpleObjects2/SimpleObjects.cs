
namespace SimpleObjects2
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SimpleObjects
    {
        public static void Main()
        {
            //Every method represents a small problem

            //ReadPoints();
            //ClosestTwoPoints();
            //GuessWords();
            //DistanceBetweenPoints();

        }

        public static Point ReadPoints()
        {
            var pointParts = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            return new Point
            {
                CoordinateX = pointParts[0],
                CoordinateY = pointParts[1]                
            };
        }

        public static void ClosestTwoPoints()
        {
            var n = int.Parse(Console.ReadLine());
            var points = new Point[n];
            var minDistance = double.MaxValue;

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var x = line[0];
                var y = line[1];
                points[i] = new Point() { CoordinateX = x, CoordinateY = y };
            }

            Point firstPointResult = null;
            Point secondPointResult = null;


            for (int first = 0; first < points.Length; first++)
            {
                for (int second = first + 1; second < points.Length; second++)
                {
                    var currentPoint = points[first];
                    var nextPoint = points[second];

                    var distance = EuclideanDistance(currentPoint, nextPoint);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        firstPointResult = currentPoint;
                        secondPointResult = nextPoint;
                    }
                }
            }

            
            Console.WriteLine();
            Console.WriteLine("{0:f3}", minDistance);
            Console.WriteLine($"({firstPointResult.CoordinateX}, {firstPointResult.CoordinateY})");
            Console.WriteLine(secondPointResult.PrintCoordinates());

        }

        private static void GuessWords()
        {
            var rnd = new Random();
            

            var userWords = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            ShuffleWords(rnd, userWords);

            var line = Console.ReadLine();
            //var isReady = false;

            while (line != "end")   //|| isReady
            {
                var inputWord = line.ToLower().Trim();

                
                if (!userWords.Contains(inputWord))
                {
                    Console.WriteLine("There is no such a word");
                }

                if (inputWord.Equals(userWords[0]))
                {
                    Console.WriteLine("You have luck!");
                    userWords.Remove(inputWord);

                    if (userWords.Count == 0)
                    {
                        //isReady = true;

                        Console.WriteLine("Game over :)");
                        break;
                    }
                }

                ShuffleWords(rnd, userWords);

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", userWords));
        }

        private static void ShuffleWords(Random rnd, List<string> userWords)
        {
            for (int i = 0; i < userWords.Count; i++)
            {
                var index = rnd.Next(0, userWords.Count);

                var temp = userWords[i];
                userWords[i] = userWords[index];
                userWords[index] = temp;
            }
        }

        public static void DistanceBetweenPoints()
        {
            var point1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var p1 = new Point();
            p1.CoordinateX = point1[0];
            p1.CoordinateY = point1[1];

            var point2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var p2 = new Point();
            p2.CoordinateX = point2[0];
            p2.CoordinateY = point2[1];

            double distance = EuclideanDistance(p1, p2);

            Console.WriteLine("{0:f3}", distance);
        }

        public static double EuclideanDistance(Point p1, Point p2)
        {
            var coordinateX = Math.Pow(p2.CoordinateX - p1.CoordinateX, 2);
            var coordinateY = Math.Pow(p2.CoordinateY - p1.CoordinateY, 2);

            var distance = Math.Sqrt(coordinateX + coordinateY);
            return distance;
        }
    }
}
