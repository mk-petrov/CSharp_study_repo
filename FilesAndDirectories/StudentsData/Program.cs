
namespace StudentsData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<double> Grades { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            //CreateDatabase(); //NEED TO RUN ONLY ONE TIME

            var studentsByName = new Dictionary<string, Student>();

            //LOAD ALL PREVIOUS DATA
            string[] storedStudents = File.ReadAllLines("Students/database.schoolfile");

            foreach (var studentInfo in storedStudents)
            {
                string[] studentsParams = studentInfo
                    .Split(new char[] { ' ', '|', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                var newStudent = new Student
                {
                    Name = studentsParams[0],
                    Age = int.Parse(studentsParams[1]),
                    Grades = studentsParams.Skip(2).Select(double.Parse).ToList()
                };

                studentsByName.Add(newStudent.Name, newStudent);
            }

            var inputLine = Console.ReadLine();

            //{student} -> {age} -> {grades}  //STUDENT ONLY IF IT DOES'T EXIST | PRINT THAT USER ALREADY EXISTS
            //{student} -> {grade}  //PRINT USER DOES NOT EXIST

            while (inputLine != "end")
            {
                string[] inputParams = inputLine
                    .Split(new[] { ' ', '-', '>', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (inputParams.Length >= 3)
                {
                    //REGISTER STUDENT LOGIC
                    try     //IF USER DOES'T EXIST
                    {
                        Student newStudent = new Student();

                        newStudent.Name = inputParams[0];
                        newStudent.Age = int.Parse(inputParams[1]);
                        newStudent.Grades = inputParams
                            .Skip(2)
                            .Select(double.Parse)
                            .ToList();

                        studentsByName.Add(newStudent.Name, newStudent);

                    }
                    catch (ArgumentException)   //MEANS THAT CAN'T ADD TWO DUPLICATE KEYS 
                    {
                        Console.WriteLine("Failed to register student. {0} already exists", inputParams[0]);
                    }
                }
                else
                {
                    //ADD GRADE LOGIC
                    try
                    {
                        string studentName = inputParams[0];

                        studentsByName[studentName].Grades
                            .AddRange(inputParams.Skip(1).Select(double.Parse));
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine("Failed to access student. Student does not exist.");
                    }
                }

                inputLine = Console.ReadLine();
            }

            //REWRITE THE DATABASE IN THE FOLLOWING FORMAT
            File.WriteAllLines("Students/database.schoolfile",
                studentsByName.OrderBy(x => x.Key)
                .Select(x => x.Value)
                .Select(x => string.Format("{0} | {1} | {2}",
                x.Name, x.Age, string.Join(", ", x.Grades))));
           
        }

        private static void CreateDatabase()
        {
            if (!Directory.Exists("Students"))
            {
                Directory.CreateDirectory("Students");
            }

            if (!File.Exists("Students/database.schoolfile"))
            {
                File.Create("Students/database.schoolfile");
            }
        }
    }
}
