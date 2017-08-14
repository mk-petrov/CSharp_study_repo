
namespace Re_Directory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class Re_Dir
    {
        public static void Main()
        {
            var outputFolder = "OutputFolder";

            Directory.CreateDirectory(outputFolder);

            var inputPath = "../../../Exercises-Resource/04. Re-Directory/input";

            string[] filesInDir = Directory.GetFiles(inputPath);

            foreach (var file in filesInDir)
            {
                var fileNameParts = file.Split('.').Reverse().ToArray();
                var fileExtension = fileNameParts[0] + "s";
                var dirPath = "../../../Exercises-Resource/04. Re-Directory/input\\";
                var fileName = file.Replace(dirPath, "");

                if (!Directory.Exists("OutputFolder/" + fileExtension))
                {
                    Directory.CreateDirectory("OutputFolder/" + fileExtension);
                }

                File.Copy(file, outputFolder + "/" + fileExtension + "/" + fileName);

                //Console.WriteLine(fileName);
            }

            //Console.WriteLine(string.Join(Environment.NewLine, filesInDir));

            Console.WriteLine("File transfer succesfull");
        }
    }
}
