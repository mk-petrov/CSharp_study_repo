
namespace ExamPreparation_ProgramingFundamentals
{
    using System;
    using System.Globalization;

    public class SinoTheWalker
    {
        public static void Main()
        {
            var timeFormat = @"hh\:mm\:ss";
            var leavingTime = TimeSpan.ParseExact(Console.ReadLine(), timeFormat, CultureInfo.InvariantCulture);

            var stepsNeeded = decimal.Parse(Console.ReadLine());
            var secondsPerStep = decimal.Parse(Console.ReadLine());

            var secondsInADay = 60 * 60 * 24;

            // to protect it if it's > int.MaxValue
            var totalSecondsNeeded = (int)(stepsNeeded * secondsPerStep % secondsInADay);

            var arrivalTime = leavingTime.Add(new TimeSpan(0, 0, totalSecondsNeeded));

            //ToString in needed, because will print and days if is later than 23:59:59
            Console.WriteLine("Time Arrival: {0}", arrivalTime.ToString(timeFormat));
            

            //SECOND SOLUTION

            //var timeFormatTwo = "HH:mm:ss";
            //var leavingTimeTwo = DateTime
            //    .ParseExact(Console.ReadLine(), timeFormatTwo, CultureInfo.InvariantCulture);

            //var stepsNeededTwo = decimal.Parse(Console.ReadLine());
            //var secPerStep = decimal.Parse(Console.ReadLine());

            //var neededSeconds = (double)(stepsNeededTwo * secPerStep % secondsInADay);

            //var arrivalTimeTwo = leavingTimeTwo.AddSeconds(neededSeconds);

        }
    }
}
