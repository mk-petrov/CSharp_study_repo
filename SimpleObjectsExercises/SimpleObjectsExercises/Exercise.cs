
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleObjectsExercises
{
    public class Exercise
    {
        public string Topic { get; set; }

        public string CourseName { get; set; }

        public string JudgeContestLink { get; set; }

        public List<string> problems = new List<string>();

        public List<string> cases { get; set; }

        public List<string> Problems
        {
            get
            {
                return problems;
            }
        }

        public void AddProblem (string line)
        {
            Problems.Add(line);
        }

        public static Exercise Parse(string line)
        {
            var input = line
            .Split(new char[] { ' ', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            var inputRest = input.Skip(3).ToList();

            return new Exercise
            {
                Topic = input[0],
                CourseName = input[1],
                JudgeContestLink = input[2],
                //problems = inputRest
                cases = inputRest
            };
        }
    }
}
