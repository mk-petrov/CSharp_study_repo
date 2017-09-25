using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayRotation
{
    public class Array_Rotation
    {
        public static void Main()
        {
            var arrayLenght = int.Parse(Console.ReadLine());
            decimal numberOfRotation = decimal.Parse(Console.ReadLine()); // decimal if input is like: 14578914521
            var arrayOfNumbers = new int[arrayLenght];
            var rotatedArray = new int[arrayLenght];

            //fill the array with numbers
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = i + 1;
            }
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                var rotateTo = (i + (int)numberOfRotation) % arrayOfNumbers.Length;
                var currentNum = arrayOfNumbers[i];
                rotatedArray[rotateTo] = currentNum;
            }

            Console.WriteLine("Original array:");
            Console.WriteLine(string.Join("|", arrayOfNumbers));
            Console.WriteLine("Rotated array:");
            Console.WriteLine(string.Join("|", rotatedArray));
        }
    }
}
