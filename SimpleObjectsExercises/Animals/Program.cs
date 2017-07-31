
namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var cats = new Dictionary<string, Cat>();
            var dogs = new Dictionary<string, Dog>();
            var snakes = new Dictionary<string, Snake>();

            var line = Console.ReadLine();

            while ( !line.Equals("I'm your Huckleberry"))
            {
                var input = line.Split(' ').ToArray();
                var command = input[0];
                var name = input[1];
                                               

                switch (command)
                {                  
                    case "Dog":

                        var age = int.Parse(input[2]);
                        var parameter = int.Parse(input[3]);

                        var currentDog = new Dog()
                        {
                            Name = name,
                            Age = age,
                            NumberOfLegs = parameter
                        };

                        dogs[currentDog.Name] = currentDog;

                        break;

                    case "Cat":
                        age = int.Parse(input[2]);
                        parameter = int.Parse(input[3]);

                        var currentCat = new Cat()
                        {
                            Name = name,
                            Age = age,
                            IntelligenceQuotient = parameter
                        };

                        cats[currentCat.Name] = currentCat;

                        break;

                    case "Snake":

                        age = int.Parse(input[2]);
                        parameter = int.Parse(input[3]);

                        var currentSnake = new Snake()
                        {
                            Name = name,
                            Age = age,
                            CrueltyCoefficient = parameter
                        };

                        snakes[currentSnake.Name] = currentSnake;

                        break;

                    case "talk":

                        if (cats.ContainsKey(name))
                        {
                            Console.WriteLine(cats[name].ProduceSound());
                        }
                        else if (dogs.ContainsKey(name))
                        {
                            Console.WriteLine(dogs[name].ProduceSound());
                        }
                        else if (snakes.ContainsKey(name))
                        {
                            Console.WriteLine(snakes[name].ProduceSound());
                        }
                        else
                        {
                            Console.WriteLine("No animal with that name");
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

                line = Console.ReadLine();
            }

            foreach (var kvp in dogs)
            {
                Console.WriteLine($"Dog: {kvp.Key}, Age: {kvp.Value.Age}," +
                    $" Number Of Legs: {kvp.Value.NumberOfLegs}");
            }

            foreach (var kvp in cats)
            {
                Console.WriteLine($"Cat: {kvp.Key}, Age: {kvp.Value.Age}," +
                    $" IQ: {kvp.Value.IntelligenceQuotient}");
            }

            foreach (var kvp in snakes)
            {
                Console.WriteLine($"Snake: {kvp.Key}, Age: {kvp.Value.Age}," +
                    $" Cruelty: {kvp.Value.CrueltyCoefficient}");
            }
        }
    }
}
