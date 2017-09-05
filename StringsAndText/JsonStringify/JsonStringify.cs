
namespace JsonStringify
{
    //using JSON_stringify;  //if i want to use my Student class from the other task solution
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int[] Grades { get; set; }
    }

    public class JsonStringify
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();

            var line = Console.ReadLine();

            while (line != "stringify")
            {
                var inputParams = line.Split(new[] { ' ', ':', '-', '>', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                var name = inputParams[0];
                var age = int.Parse(inputParams[1]);
                int[] grades = inputParams.Skip(2).Select(int.Parse).ToArray();

                Student newStudent = new Student();

                newStudent.Name = name;
                newStudent.Age = age;
                newStudent.Grades = grades;

                students.Add(newStudent);

                line = Console.ReadLine();
            }

            Console.WriteLine(
                "[" + 
                string.Join(",", students.Select(x => $"{{name:\"{x.Name}\",age:{x.Age},grades:[{string.Join(", ", x.Grades)}]}}"))
                + "]"
                );
        }
    }
}
