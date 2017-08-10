
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilterExtensions
{
    public class FilterExtensions
    {
        public static void Main()
        {
            var extension = Console.ReadLine();

            string[] fileInDir = Directory.GetFiles("../../../" +
                "Exercises-Resource/01. Filter-Extensions/input");

            var filesAsList = new List<string>();

            foreach (var file in fileInDir)
            {
                filesAsList.Add(file.Replace("../../../Exercises-Resource/01. Filter-Extensions/input\\", ""));                
            }


            foreach (var file in filesAsList)
            {
                var fileExtension = file.Split('.').Reverse().ToArray()[0];
                
                if (extension == fileExtension)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, file));
                }
            }
                        
        }
    }
}
