using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symmetric_numbers
{
    public class symmetric_Nums
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var symmetricNumbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                var currentNumberAsString = i.ToString();
                var currentNumLength = currentNumberAsString.Length;
                if (currentNumLength > 1)
                {
                    for (int j = 0; j < currentNumLength / 2 ; j++)
                    {
                        if (currentNumberAsString[j] == currentNumberAsString[currentNumLength - j - 1])
                        {
                            symmetricNumbers.Add(i);
                        }
                    }
                }
                else
                {
                    symmetricNumbers.Add(i);
                }

            }
            Console.WriteLine(String.Join(", ", symmetricNumbers));
        }
    }
}
