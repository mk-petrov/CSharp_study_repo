
namespace ArraySecondExerecise
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            //Every method represents a small problem. 

            //PhoneBook();
            //ResizableArray();
        }

        private static void ResizableArray()
        {
            string[] arr1 = new string [4];
            var resultString = string.Empty;
            var inputLineCommand = Console.ReadLine().Split(' ').ToArray();

            while (inputLineCommand[0] != "end")
            {
                inputLineCommand = Console.ReadLine().Split(' ').ToArray();

                if (inputLineCommand[0].Equals("push"))
                {
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        arr1[i] = inputLineCommand[1];
                        resultString += arr1[i];
                    }
                    
                }
                else if (inputLineCommand[0].Equals("removeAt"))
                {
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        if (inputLineCommand[1].Equals(arr1[i]) )
                        {
                            arr1[i] = string.Empty;
                            resultString += arr1[i].Trim();
                        }
                    }
                }
                else if (inputLineCommand[0].Equals("pop"))
                {
                    arr1[arr1.Length] = string.Empty;
                    resultString += arr1[arr1.Length].Trim();
                }
                else if (inputLineCommand[0].Equals("clear"))
                {
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        arr1[i] = string.Empty;
                    }
                    Console.WriteLine("empty array");
                }
                else
                {
                    Console.WriteLine("invalid command !");
                }
                Console.WriteLine(resultString);
            }
           


        }

        private static void PhoneBook()
        {
            var phoneNumber = Console.ReadLine().Split(' ');
            var ownerName = Console.ReadLine().Split(' ');
            string inputLine = Console.ReadLine();

            while (inputLine != "done")
            {
                SearchNumber(phoneNumber, ownerName, inputLine);
                inputLine = Console.ReadLine();
            }
        }

        private static void SearchNumber(string[] phoneNumber, string[] ownerName, string inputLine)
        {
            for (int i = 0; i < ownerName.Length; i++)
            {
                if (ownerName[i].Equals(inputLine))
                {
                    Console.WriteLine($"{ownerName[i]} -> {phoneNumber[i]}");
                }
            }
        }
    }
}