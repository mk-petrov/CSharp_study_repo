
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
        }
    }
}
