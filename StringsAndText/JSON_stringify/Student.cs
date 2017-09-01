
namespace JSON_stringify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<int> Grades { get; set; }

        public static Student Parse(string line)
        {
            var inputParams = line.Split(new[] { ' ', ':', '-', '>', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

            return new Student
            {
                Name = inputParams[0],
                Age = int.Parse(inputParams[1]),
                Grades = inputParams.Skip(2).Select(int.Parse).ToList()
            };
        }
        
    }
}
