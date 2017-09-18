
namespace FishStatistics
{
    using System;
    using System.Text.RegularExpressions;

    public class FishStatistics
    {
        public static void Main()
        {
            string pattern = @"(>*)<(\(+).>";
            var line = Console.ReadLine();

            var regex = new Regex(pattern);

            var fishes = regex.Matches(line);

            if (fishes.Count == 0)
            {
                Console.WriteLine("No fish found.");
            }

            for (int i = 0; i < fishes.Count; i++)
            {            
                var currentFish = fishes[i].ToString();
                var tail = fishes[i].Groups[1].Length * 2;
                var body = fishes[i].Groups[2].Length * 2;
                var fishEye = currentFish.Substring(currentFish.Length - 2, 1);
                var fishStatus = string.Empty;
                var tailType = string.Empty;
                var bodyType = string.Empty;

                #region Fish Status logic

                if (fishEye == "'")
                {
                    fishStatus = "Awake";
                }
                else if (fishEye == "-")
                {
                    fishStatus = "Asleep";
                }
                else if (fishEye == "x")
                {
                    fishStatus = "Dead";
                }

                #endregion
                
                #region Tail logic

                if (tail == 0)
                {
                    tailType = "None";
                }
                else if (tail == 2)
                {
                    tailType = "Short (" + tail + " cm)";
                }
                else if (tail > 10)
                {
                    tailType = "Long (" + tail + " cm)";
                }
                else if (tail > 2)
                {
                    tailType = "Medium (" + tail + " cm)";
                }

                #endregion

                #region Body Logic
                                
                if (tail > 20)
                {
                    bodyType = "Long (" + body + " cm)";
                }
                else if (tail > 10)
                {
                    bodyType = "Medium (" + body + " cm)";
                }
                else if (tail <= 10)
                {
                    bodyType = "Short (" + body + " cm)";
                }

                #endregion


                Console.WriteLine("Fish {0}: {1}", i + 1, currentFish);
                Console.WriteLine("  Tail type: {0}", tailType);
                Console.WriteLine("  Body type: {0}", bodyType);
                Console.WriteLine("  Status: " + fishStatus);
                Console.WriteLine();

            }

        }
    }
}
