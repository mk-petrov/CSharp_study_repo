﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladybugs
{
    public class Ladybugs
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            var ladybugIndexes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var field = new int[size];

            foreach (var ladybugIndex in ladybugIndexes)
            {
                if (ladybugIndex < 0 || ladybugIndex >= size)
                {
                    continue;
                }

                field[ladybugIndex] = 1;
            }

            // loop for each command
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                var commandParts = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var currentLadybugIndex = int.Parse(commandParts[0]);
                var direction = commandParts[1];
                var flyLength = int.Parse(commandParts[2]);

                if (currentLadybugIndex < 0 || currentLadybugIndex >= size)
                {
                    continue;
                }

                if (field[currentLadybugIndex] == 0)
                {
                    continue;
                }

                field[currentLadybugIndex] = 0;
                var position = currentLadybugIndex;

                //loop for each movement of the current ladybug
                while (true)
                {
                    if (direction == "right")
                    {
                        position += flyLength;
                    }
                    else
                    {
                        position -= flyLength;
                    }

                    if (position < 0 || position >= size)
                    {
                        break;
                    }

                    //there is an another ladybug here, keep flying
                    if (field[position] == 1)
                    {
                        continue;
                    }
                    else
                    {
                        field[position] = 1;
                        break;
                    }

                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
