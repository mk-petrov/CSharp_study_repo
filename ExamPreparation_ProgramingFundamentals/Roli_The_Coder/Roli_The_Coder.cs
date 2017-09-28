using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roli_The_Coder
{
    public class Roli_The_Coder
    {

        public class Event
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public List<string> Participants { get; set; }
        } 

        public static void Main()
        {
            var result = new List<Event>();
            var eventsById = new Dictionary<int, Event>();

            while (true)
            {
                var currentLine = Console.ReadLine();

                if (currentLine == "Time for Code")
                {
                    break;
                }

                var lineParts = currentLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                var eventId = 0;

                if (!int.TryParse(lineParts[0], out eventId))
                {
                    //if can't be parsed, ignore the invalid input
                    continue;
                }

                string eventName = null;

                //event name always is at 1 index and starts with "#"
                if (lineParts.Length > 1 && lineParts[1].StartsWith("#"))
                {
                    eventName = lineParts[1].Trim('#');
                }
                else
                {
                    continue;
                }

                var participants = new List<string>();
                                                 
                if (lineParts.Length > 2)
                {
                    participants = lineParts.Skip(2).ToList();

                    //Check the names, all valid participant names start with @ else continue
                    if (!participants.All(p => p.StartsWith("@")))
                    {
                        continue;
                    }
                }

                if (eventsById.ContainsKey(eventId))
                {
                    if (eventsById[eventId].Name == eventName)
                    {
                        var existingEvent = eventsById[eventId];

                        foreach (var participant in participants)
                        {
                            if (!existingEvent.Participants.Contains(participant))
                            {
                                existingEvent.Participants.Add(participant);
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                else
                {
                    var newEvent = new Event
                    {
                        Id = eventId,
                        Name = eventName,
                        Participants = participants
                    };

                    result.Add(newEvent);
                    eventsById.Add(eventId, newEvent);
                }
                                
            }

            var sortedEvents = result
                .OrderByDescending(e => e.Participants.Count)
                .ThenBy(e => e.Name);

            //  or @event to escape event as saved word
            foreach (var ev in sortedEvents)
            {
                // Distinct to print only unique names
                var distinctParticipants = ev.Participants.Distinct().ToList();
                Console.WriteLine($"{ev.Name} - {distinctParticipants.Count}");
                foreach (var participant in distinctParticipants.OrderBy(p => p))  
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}
