using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally
{
    public class Rally
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split();

            var trackIndices = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var checkpointIndices = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (var participant in participants)
            {
                double fuel = participant[0];  // take the first letter ascii code as fuel

                for (int currentTrackIndex = 0; currentTrackIndex <= trackIndices.Length; currentTrackIndex++)
                {
                    bool outOfFuel = fuel <= 0;
                    bool reachedEndOfTrack = currentTrackIndex == trackIndices.Length;

                    var raceEnded = outOfFuel || reachedEndOfTrack;

                    if (raceEnded)
                    {
                        if (outOfFuel)
                        {
                            Console.WriteLine($"{participant} - reached {currentTrackIndex - 1}");
                        }
                        else if (reachedEndOfTrack)
                        {
                            Console.WriteLine($"{participant} - fuel left {fuel:f2}");
                        }

                        break;
                    }

                    var fuelAtCheckpoint = trackIndices[currentTrackIndex];

                    var isCheckpoint = checkpointIndices.Contains(currentTrackIndex);

                    if (isCheckpoint)
                    {
                        fuel += fuelAtCheckpoint;
                    }
                    else
                    {
                        fuel -= fuelAtCheckpoint;
                    }
                }
            }
        }
    }
}
