
namespace FilesAndDirectories
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            //PrintDirectoriesAndFilesInIt();
                        
        }

        private static void PrintDirectoriesAndFilesInIt()
        {
            string[] subDirectoryNames = Directory.GetDirectories("Test");

            foreach (var subDirectory in subDirectoryNames)
            {
                Console.WriteLine("{0}", subDirectory.Replace("Test\\", ""));

                string[] fileNames = Directory.GetFiles(subDirectory);

                foreach (var file in fileNames)
                {
                    Console.WriteLine("*** {0}",
                        file.Split('\\')[file.Split('\\').Length - 1]);
                }
            }
        }
    }
}
