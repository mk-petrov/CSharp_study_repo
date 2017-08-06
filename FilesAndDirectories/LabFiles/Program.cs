
namespace LabFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            //ReadFileAndWriteFile();
            //LineNumbers();


        }

        private static void LineNumbers()
        {
            try
            {
                string[] fileContent = File.ReadAllLines("../../Resources/02. Line Numbers/Input.txt");

                var content = new List<string>();

                for (int i = 0; i < fileContent.Length; i++)
                {
                    content.Add($"{i + 1}. {fileContent[i]}");
                }

                File.WriteAllLines("02.output.txt", content);
 

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(" *** File doesn't exists. ***");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(" *** Directory doesn't exists. ***");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(" *** Index was outside the bounds of the array. ***");
            }
        }

        private static void ReadFileAndWriteFile()
        {
            
            try
            {
                string[] fileContent = File.ReadAllLines("../../Resources/01. Odd Lines/Input.txt");

                var oddLines = new List<string>();

                for (int i = 1; i < fileContent.Length; i += 2)
                {
                    oddLines.Add(fileContent[i]);
                }
                    
                File.WriteAllLines("01.output.txt", oddLines);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File doesn't exists");                
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory doesn't exists");
            }

        }
    }
}
