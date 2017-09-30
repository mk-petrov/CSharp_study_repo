using System;
using System.Collections.Generic;
using System.Linq;


namespace _03_Files
{
    public class Files
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var filesByRoot = new Dictionary<string, Dictionary<string, long>>(); //root -> name:size
            var filesByExtension = new Dictionary<string, string>();  //extension:name

            for (int i = 0; i < n; i++)
            {
                string[] inputParams = Console.ReadLine().Split('\\');
                string root = inputParams[0];
                string[] fileParams = inputParams[inputParams.Length - 1]
                    .Split(new[] { '.', ';' }, StringSplitOptions.RemoveEmptyEntries);

                string fileName = fileParams[0];
                string fileExtension = fileParams[1];
                long fileSize = long.Parse(fileParams[2]);

            }

            //QUERY 
        }
    }
}
