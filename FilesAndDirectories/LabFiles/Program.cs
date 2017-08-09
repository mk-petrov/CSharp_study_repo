
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
            //WordCount();
            MergeFiles();

        }

        private static void MergeFiles()
        {
            try
            {
                string[] fileOne = File.ReadAllLines("../../Resources/04. Merge Files/FileOne.txt");

                string[] fileTwo = File.ReadAllLines("../../Resources/04. Merge Files/FileTwo.txt");

                string[] result = fileOne.Concat(fileTwo).OrderBy(x => x).ToArray();

                File.AppendAllLines("04.Output.txt", result);
                
            }            
            catch (FileNotFoundException)
            {
                Console.WriteLine(" *** File doesn't exists. ***");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(" *** Directory doesn't exists. ***");
            }


        }

        public static void WordCount()
        {
            try
            {
                var words = File.ReadAllText("../../Resources/03. Word Count/words.txt")
                    .ToLower()
                    .Split(' ')
                    .ToArray();

                var content = File.ReadAllText("../../Resources/03. Word Count/text.txt")
                    .ToLower()
                    .Split(new[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var result = new Dictionary<string, int>();
                    

                for (int i = 0; i < words.Length; i++)
                {
                    var currentWord = words[i];
                    var counter = 0;

                    for (int j = 0; j < content.Length; j++)
                    {
                        if (currentWord == content[j])
                        {
                            counter++;
                        }
                    }

                    result[currentWord] = counter;

                    //if (! content.Contains(currentWord))
                    //{
                    //    result[currentWord] = 0;
                    //}
                }

                foreach (var kvp in result.OrderByDescending(x => x.Value))
                {
                    var line = kvp.Key + " - " + kvp.Value;
                    File.AppendAllText("03.Output.txt", line + Environment.NewLine);
                }


            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(" *** File doesn't exists. ***");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(" *** Directory doesn't exists. ***");
            }


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
