
namespace ObjectsAndSimpleClasses
{
    using System;

    public class Cat
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Color { get; set; }

        public bool IsEaten = false;

        public string SayHi()
        {
            return $"Hi there my name is {Name} and i am {Age} years old";
        } 
        public static void Sleep()
        {
            Console.WriteLine("I'm sleeping :)");
        }
    }
}
