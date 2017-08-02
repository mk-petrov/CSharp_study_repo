
namespace Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var registeredUsers = new Dictionary<string, User>();

            var line = Console.ReadLine();

            while (line != "exit")
            {
                var input = line.Split(' ');

                if (input.Length == 2)
                {
                    var nameToRegister = input[1];

                    var userToRegister = new User
                    {
                        Username = nameToRegister,
                        ReceivedMessages = new List<Message>()
                    };

                    registeredUsers[userToRegister.Username] = userToRegister; 
                }
                else
                {
                    var senderUsername = input[0];
                    var recipientUsername = input[2];
                    var content = input[3];

                    if (registeredUsers.ContainsKey(senderUsername)
                        && registeredUsers.ContainsKey(recipientUsername))
                    {

                        var newMessage = new Message
                        {
                            Content = content,
                            Sender = registeredUsers[senderUsername]
                        };

                        registeredUsers[recipientUsername].ReceivedMessages.Add(newMessage);
                    }

                    else
                    {
                        continue;
                    }
                }

                line = Console.ReadLine();
            }

            var filterUsers = Console.ReadLine().Split(' ');

            var firstUser = filterUsers[0];
            var secondUser = filterUsers[1];
                        
            Console.WriteLine();

            foreach (var message in registeredUsers[firstUser].ReceivedMessages)
            {
                Console.WriteLine($"{message.Sender.Username}: {message.Content}");

            }

            foreach (var message in registeredUsers[secondUser].ReceivedMessages)
            {
                Console.WriteLine($"{message.Sender.Username}: {message.Content}");

            }


            //if (registeredUsers[firstUser].ReceivedMessages.Count >
            //    registeredUsers[secondUser].ReceivedMessages.Count)
            //{
            //    for (int i = 0; i < registeredUsers[firstUser].ReceivedMessages.Count; i++)
            //    {
            //        var curr1 = registeredUsers[firstUser].ReceivedMessages[i];
            //        var curr2 = registeredUsers[secondUser].ReceivedMessages[i];

            //        Console.WriteLine($"{curr1.Sender.Username}: {curr1.Content}");
            //        Console.WriteLine($"{curr2.Content}: {curr2.Sender.Username}");
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < registeredUsers[secondUser].ReceivedMessages.Count; i++)
            //    {
            //        var curr1 = registeredUsers[firstUser].ReceivedMessages[i];
            //        var curr2 = registeredUsers[secondUser].ReceivedMessages[i];

            //        Console.WriteLine($"{curr1.Sender.Username}: {curr1.Content}");
            //        Console.WriteLine($"{curr2.Content}: {curr2.Sender.Username}");
            //    }
            //}


        }
    }
}
