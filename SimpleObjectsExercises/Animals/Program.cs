
namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            while ( !line.Equals("I’m your Huckleberry"))
            {
                var input = line.Split(' ').ToArray();

                switch (input[0])
                {
                    case "Dog":
                        //class Dog

                        break;

                    case "Cat":


                        break;

                    case "Snake":


                        break;

                    case "talk":
                        // call method from the class

                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}
