using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Karaoke
{
    public class SoftUni_Karaoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine()
                .Split(',')
                .Select(a => a.Trim())
                .ToArray();

            var songs = Console.ReadLine()
                .Split(',')
                .Select(a => a.Trim())
                .ToArray();

            var participantAwards = new Dictionary<string, HashSet<string>>();  // or List.Distinct ;)

            var line = Console.ReadLine();
            while (line != "dawn")
            {
                var tokens = line.Split(',')
                .Select(a => a.Trim())
                .ToArray();

                var participant = tokens[0];
                var song = tokens[1];
                var award = tokens[2];

                if (songs.Contains(song) && participants.Contains(participant))
                {
                    if (!participantAwards.ContainsKey(participant))
                    {
                        participantAwards[participant] = new HashSet<string>();
                    }

                    participantAwards[participant].Add(award);
                }

                line = Console.ReadLine();
            }

            if (!participantAwards.Any()) // !participantAwarda.Count == 0
            {
                Console.WriteLine("No awards");
                return;
            }

            var sortedParticipantAwards = participantAwards
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var kvp in sortedParticipantAwards)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} awards");

                foreach (var award in kvp.Value.OrderBy(a => a))   // or use SortedSet to avoid .OrderBy()
                {
                    Console.WriteLine("--{0}", award);
                }
            }
        }
    }
}
