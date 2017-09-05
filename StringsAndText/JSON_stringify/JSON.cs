
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

            var line = Console.ReadLine();

            //line = ToJSON(studentsBase, line);    //ENABLE FROM STRING TO JSON METHOD

            var info = line.Trim('{', '}').Split(':', ',');
            //.Trim('{', '}', '"', ':', '[', ']')

            var name = info[1].Trim('"');     // name|"Ivan"|age|28|grades|[2| 2| 3]
            var age = int.Parse(info[3]);
            var grades = info.Skip(5).ToArray();
            //grades = grades.Trim('[', ']');

            Console.WriteLine(string.Join("|", info));
            Console.WriteLine(name + " is " + age);
            Console.WriteLine("grades: "+ string.Join("", grades));

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
