using System;
using System.Collections.Generic;
using System.Linq;


namespace _03_Files
{
    public class Files
    {
        public static void Main()
        {
            //input like:
            //4
            //Windows\Temp\win.exe; 5423
            //Games\Wow\wow.exe; 1024
            //Games\Wow\patcher.cs; 65212
            //Games\Pirates\Start\keygen.exe; 1024
            //exe in Games

            //output like:
            //keygen.exe - 1024 KB
            //wow.exe - 1024 KB

            int n = int.Parse(Console.ReadLine());

            var filesByRoot = new Dictionary<string, Dictionary<string, long>>(); //root -> name:size
            var filesExtension = new Dictionary<string, string>();  //name:extension

            for (int i = 0; i < n; i++)
            {
                string[] inputParams = Console.ReadLine().Split('\\');
                string root = inputParams[0];
                string[] fileParams = inputParams[inputParams.Length - 1]
                    .Split(';');

                string fileNameWithExtension = fileParams[0];
                long fileSize = long.Parse(fileParams[1]);

                string fileName = fileNameWithExtension;
                string fileExtension = fileNameWithExtension.Split('.').Last();


                if (!filesByRoot.ContainsKey(root))
                {
                    filesByRoot[root] = new Dictionary<string, long>();
                }

                filesByRoot[root][fileName] = fileSize;
                filesExtension[fileName] = fileExtension;
                
            }

            string[] queryParams = Console.ReadLine()
                .Split();
            string queryExtension = queryParams[0];
            string queryRoot = queryParams[2];

            var resultFiles = new Dictionary<string, long>();

            foreach (var file in filesByRoot[queryRoot])
            {
                if (filesExtension[file.Key] == queryExtension)
                {
                    resultFiles.Add(file.Key, file.Value);
                }
            }

            if (resultFiles.Count > 0)
            {
                foreach (var file in resultFiles
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{file.Key} - {file.Value} KB");
                }
            }
            else
            {
                Console.WriteLine("No files found!");
            }

            //QUERY 
        }
    }
}
