
namespace SimpleObjectsExercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Exercises
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var exercisesData = new List<Exercise>();

            while (line != "go go go")
            {               
                var currentExercise = Exercise.Parse(line);

                exercisesData.Add(currentExercise);

                line = Console.ReadLine();
            }
                        
            Console.WriteLine();

            foreach (var item in exercisesData)
            {
                var counter = 1;
                Console.WriteLine($"Exercises: {item.Topic}");
                Console.WriteLine($"Problems for exercises and homework" +
                    $" for the \"{item.CourseName}\" course @ SoftUni.");
                Console.WriteLine($"Check your solutions here: {item.JudgeContestLink}.");

                for (int i = 0; i < item.cases.Count; i++)
                {
                    Console.WriteLine($"{counter}. {item.cases[i]}");
                    counter++;
                }

                //for (int i = 0; i < item.Problems.Count; i++)
                //{
                //    Console.WriteLine($"{counter}. {item.Problems[i]}");
                //    counter++;
                //}
            }
            
        }
    }
}
