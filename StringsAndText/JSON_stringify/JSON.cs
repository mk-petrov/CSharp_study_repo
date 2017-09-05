
namespace JSON_stringify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class JSON
    {
        public static void Main()
        {
            var studentsBase = new Dictionary<string, Student>();
            var studentsList = new List<string>();
            var line = Console.ReadLine();

            //line = ToJSON(studentsBase, line);    //ENABLE FROM STRING TO JSON METHOD

            var infoFromJSON = line.Trim('[', ']').Split(new[] { '}' },
                StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var info in infoFromJSON)
            {                
                studentsList.Add(info.Trim(',', '{'));
            }

            foreach (var studentInfo in studentsList)
            {
                var infoParams = studentInfo.Split(new[] { ':', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                var name = infoParams[1].Trim('"');
                var age = int.Parse(infoParams[3]);
                var gradesInfo = infoParams.Skip(5).ToArray();
                var grades = new List<int>();

                for (int i = 0; i < gradesInfo.Length; i++)
                {
                    int grade;
                    bool isGrade = int.TryParse(gradesInfo[i].Trim('[', ']', ' '), out grade);

                    if (isGrade)
                    {
                        grades.Add(grade);
                    }                    
                }

                Student newStudent = new Student();
                newStudent.Name = name;
                newStudent.Age = age;
                newStudent.Grades = grades;

                studentsBase[newStudent.Name] = newStudent;
                                                
            }

            foreach (var kvp in studentsBase)
            {
                if (kvp.Value.Grades.Count == 0)
                {
                    Console.WriteLine($"{kvp.Key} : {kvp.Value.Age} -> None");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key} : {kvp.Value.Age} -> {string.Join(", ", kvp.Value.Grades)}");
                }
            }
                        
        }

        private static string ToJSON(Dictionary<string, Student> studentsBase, string line)
        {
            while (line != "stringify")
            {
                var newStudent = Student.Parse(line);

                studentsBase[newStudent.Name] = newStudent;

                line = Console.ReadLine();
            }

            Console.Write("[");

            foreach (var kvp in studentsBase)
            {
                var currentStudent = "{name:\"" + kvp.Key + "\",age:" + kvp.Value.Age +
                    ",grades:[" + string.Join(", ", kvp.Value.Grades) + "]}";

                Console.Write(string.Join(", ", currentStudent));

                //Console.Write("{name:\"" + kvp.Key + "\",age:" + kvp.Value.Age +
                //    ",grades:[" + string.Join(", ", kvp.Value.Grades) + "]}");

            }

            Console.Write("]");
            Console.WriteLine();
            return line;
        }
    }
}
