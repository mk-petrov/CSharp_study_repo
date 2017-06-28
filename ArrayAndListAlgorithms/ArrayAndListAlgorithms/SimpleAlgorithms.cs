
namespace ArrayAndListAlgorithms
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    

    public class Program
    {
        public static void Main()
        {
            //Every method represents a small problem. 

            //ArrayContainsElement();
            //SmallestElementInArray();
            //ReverseArrayInPlace();
            //SortingArray();
            //InsertionSort();
            //BubbleSort();
            //LargestNElements();
            //ShootListElement();
            //AverageCharacterDelimiter();
            //SortArrayOfStrings();
            //ArrayHistogram();
            //DecodeRadioFrequencies();
            //Batteries();

            

            Console.WriteLine();
        }

        private static void Batteries()
        {
            var capacitiesOfBatteries = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var usagePerHour = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var stressTestHours = int.Parse(Console.ReadLine());

            var testResulst = new List<int>();

            for (int i = 0; i < capacitiesOfBatteries.Length; i++)
            {
                double drainedEnergy, restOfEnergy, percentage, lastHours;
                int numOftestedBattery;
                BatteryDiagnostic(capacitiesOfBatteries, usagePerHour, stressTestHours, i, out drainedEnergy, out numOftestedBattery, out restOfEnergy, out percentage, out lastHours);

                if (capacitiesOfBatteries[i] % usagePerHour[i] > 0)
                {
                    lastHours++;
                }

                if (drainedEnergy > capacitiesOfBatteries[i])
                {
                    Console.WriteLine($"Battery {numOftestedBattery}: dead (lasted {(int)lastHours} hours)");
                }
                else
                {
                    Console.WriteLine($"Battery {numOftestedBattery}: {restOfEnergy} mAh ({percentage:F2})%");
                }
            }


        }

        private static void BatteryDiagnostic(double[] capacitiesOfBatteries, double[] usagePerHour, int stressTestHours, int i, out double drainedEnergy, out int numOftestedBattery, out double restOfEnergy, out double percentage, out double lastHours)
        {
            drainedEnergy = stressTestHours * usagePerHour[i];
            numOftestedBattery = i + 1;
            restOfEnergy = capacitiesOfBatteries[i] - drainedEnergy;
            percentage = (restOfEnergy / capacitiesOfBatteries[i]) * 100;
            lastHours = (int)capacitiesOfBatteries[i] / usagePerHour[i];
        }

        private static void DecodeRadioFrequencies()
        {
            var inputedNumbers = Console.ReadLine().Split(' ', '.').Select(int.Parse).ToArray();
            var decodedStringFirst = new List<string>();
            var decodedStringSecond = new List<string>();

            for (int i = 0; i < inputedNumbers.Length; i++)
            {
                var currentChar = ((char)inputedNumbers[i]).ToString();

                if (inputedNumbers[i] == 0)
                {
                    continue;
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        decodedStringFirst.Add(currentChar);                        
                    }                    
                    else
                    {                        
                        decodedStringSecond.Insert(0, currentChar);                        
                    }

                }
            }
                        
            Console.WriteLine(string.Join("", decodedStringFirst) + string.Join("", decodedStringSecond));

        }

        private static void ArrayHistogram()
        {
            var inputedStrings = Console.ReadLine().Split(' ').ToArray();
            var occurences = new List<int>();
            var noRepeatedStrings = new List<string>();

            var counter = 1;

            for (int i = 0; i < inputedStrings.Length; i++)
            {
                var current = inputedStrings[i];

                for (int j = 1; j < inputedStrings.Length; j++)
                {
                    if (inputedStrings[j] == current)
                    {
                        counter++;
                        
                    }
                    else
                    {
                        continue;
                    }
                }

                
                if (!noRepeatedStrings.Contains(current))
                {
                    occurences.Add(counter);
                    noRepeatedStrings.Add(current);                    
                }
                
                counter = 0;
            }

            for (int i = 0; i < occurences.Count - 1; i++)
            {
                var j = i + 1;

                while (j > 0)
                {
                    if (occurences[j - 1] < occurences[j])
                    {
                        var temp1 = occurences[j];
                        occurences[j] = occurences[j - 1];
                        occurences[j - 1] = temp1;

                        var temp2 = noRepeatedStrings[j];
                        noRepeatedStrings[j] = noRepeatedStrings[j - 1];
                        noRepeatedStrings[j - 1] = temp2;
                    }

                    j--;
                }
            }

            for (int i = 0; i < noRepeatedStrings.Count; i++)
            {
                double percentOfOccur = (occurences[i] / (double)inputedStrings.Length) * 100;

                Console.WriteLine($" {noRepeatedStrings[i]} -> {occurences[i]} times ({percentOfOccur:F2} %)");
            }

        }

        private static void SortArrayOfStrings()
        {
            var stringsInput = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < stringsInput.Length - 1; i++)
            {
                var j = i + 1;

                while (j > 0)
                {
                    var result = stringsInput[j].CompareTo(stringsInput[j - 1]);

                    if (result == 0 || result == 1)
                    {
                        break;
                    }
                                        
                    else if (result == -1)
                    {
                        var temp = stringsInput[j - 1];
                        stringsInput[j - 1] = stringsInput[j];
                        stringsInput[j] = temp;
                    }

                    j--;
                }
            }
            Console.WriteLine(string.Join(" ", stringsInput));

        }

        private static void AverageCharacterDelimiter()
        {
            var input = Console.ReadLine().Split().ToArray();
            var inputAsDigits = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var character in input[i])
                {
                    inputAsDigits.Add((int)character);
                }
            }
            var average = (int)inputAsDigits.Average();    // take int from double: 97.8 -> 97

            var delimiterChar = ((char)average).ToString().ToUpper();


            Console.WriteLine(string.Join(delimiterChar, input));
            
        }

        private static void ShootListElement()
        {
            var numbers = new List<int>();
            var inputLine = Console.ReadLine();

            var average = 0d;
                                        

            while (!inputLine.Equals("stop"))
            {
                

                if (inputLine.Equals("bang"))
                {
                    var temp = 0;

                    
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        temp = numbers[i];

                        
                        if (numbers[i] <= average)
                        {
                            
                            numbers.Remove(numbers[i]);
                            Console.WriteLine("shot {0}", temp);

                            for (int j = 0; j < numbers.Count; j++)
                            {
                                numbers[j]--;
                            }

                            break;
                        }
                        
                    }

                    if (numbers.Count == 0)
                    {
                        if (temp == 0)
                        {
                            break;
                        }
                        Console.WriteLine("nobody left to shoot! last one was {0}", temp);
                    }

                }
                else
                {
                    numbers.Insert(0, int.Parse(inputLine));
                }
                if (numbers.Count > 0)
                {
                    average = numbers.Average();
                }

                inputLine = Console.ReadLine();
            }

            

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(average);
        }

        private static void LargestNElements()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var wantedNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                var j = i + 1;

                while (j > 0)
                {
                    if (numbers[j] < numbers[j - 1])
                    {
                        var temp = numbers[j];
                        numbers[j] = numbers[j - 1];
                        numbers[j- 1] = temp;
                    }

                    j--;
                }
            }

            for (int i = numbers.Length - 1; i > wantedNumbers; i--)
            {
                Console.Write(numbers[i] + " ");
            }

            //Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort()
        {
            var inputedNumbers = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            bool swapped = false;

            do
            {
                swapped = false;

                for (int i = 0; i < inputedNumbers.Length - 1; i++)
                {
                    var current = inputedNumbers[i];
                    var next = inputedNumbers[i + 1];

                    if (current > next)
                    {
                        inputedNumbers[i + 1] = current;
                        inputedNumbers[i] = next;

                        swapped = true;
                    }
                }

            } while (swapped);

            Console.WriteLine(string.Join(" ", inputedNumbers));
        }

        private static void InsertionSort()
        {
            var inputedNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < inputedNumbers.Length - 1; i++)
            {
                var j = i + 1;

                while (j > 0)
                {
                    if (inputedNumbers[j] < inputedNumbers[j - 1])
                    {
                        var temp = inputedNumbers[j];
                        inputedNumbers[j] = inputedNumbers[j - 1];
                        inputedNumbers[j - 1] = temp;

                    }

                    j--;
                }

            }

            Console.WriteLine(string.Join(" ", inputedNumbers));            
        }

        private static void SortingArray()
        {
            var inputedNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < inputedNumbers.Length - 1; i++)
            {
                while (inputedNumbers[i] > inputedNumbers[i + 1])
                {
                    var temp = inputedNumbers[i + 1];
                    inputedNumbers[i + 1] = inputedNumbers[i];
                    inputedNumbers[i] = temp;
                    i = 0;
                }


            }

            Console.WriteLine(string.Join(" ", inputedNumbers));
        }

        private static void ReverseArrayInPlace()
        {
            var inputedNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < inputedNumbers.Length / 2; i++)
            {
                var temp = inputedNumbers[i];
                inputedNumbers[i] = inputedNumbers[inputedNumbers.Length - 1 - i];
                inputedNumbers[inputedNumbers.Length - 1 - i] = temp;
            }

            Console.WriteLine(string.Join(" ", inputedNumbers));
        }

        private static void SmallestElementInArray()
        {
            var inputedNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var smallestElement = int.MaxValue;

            foreach (var number in inputedNumbers)
            {
                if (number < smallestElement)
                {
                    smallestElement = number;
                }
            }

            Console.WriteLine(smallestElement);

        }

        private static void ArrayContainsElement()
        {
            var inputedNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var wantedInteger = int.Parse(Console.ReadLine());

            bool isWantedInteger = false;

            for (int i = 0; i < inputedNumbers.Length; i++)
            {
                if (inputedNumbers[i] == wantedInteger)
                {
                    isWantedInteger = true;
                    break;
                }
            }

            if (isWantedInteger)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            //Array.contains(inputedNumbers, wantedInteger);
        }
    }
}