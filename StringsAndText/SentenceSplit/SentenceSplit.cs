
namespace SentenceSplit
{
    using System;
    using System.Text;

    public class SentenceSplit
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var delimiter = Console.ReadLine();

            var partsOfInput = input.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("[{0}]",string.Join(", ", partsOfInput));            
        }
    }
}
