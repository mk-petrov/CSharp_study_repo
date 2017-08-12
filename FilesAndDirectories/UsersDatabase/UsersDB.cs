
namespace UsersDatabase
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class UsersDB
    {
        private static string dbPath = "users.txt";   //This way can be used from the entire class 
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        private static string loggedInUser = null;


        public static void Main()
        {
            
            if ( !File.Exists(dbPath))
            {
                File.Create(dbPath).Close();
            }

            //LOAD ALL AVAILABLE USERS FROM DB
            var dbLines = File.ReadAllLines(dbPath);

            foreach (var dbLine in dbLines)
            {
                var dbLineParts = dbLine.Split(' ');
                var username = dbLineParts[0];
                var password = dbLineParts[1];

                users[username] = password;
            }

            var line = Console.ReadLine();

            while (line != "exit")
            {
                var commandParts = line.Split(' ');

                switch (commandParts[0])
                {
                    case "register":
                        var username = commandParts[1];
                        var password = commandParts[2];
                        var confirmPassword = commandParts[3];

                        Register(username, password, confirmPassword);

                        break;

                    case "login":
                        username = commandParts[1];
                        password = commandParts[2];

                        Login(username, password);

                        break;

                    case "logout":
                        Logout();
                        break;

                }

                line = Console.ReadLine();
            }

        }

        private static void Logout()
        {
            if (loggedInUser == null)
            {
                Console.WriteLine("There is no currently logged in user.");
                return;
            }

            loggedInUser = null;  //logout if there is a user
        }

        private static void Login(string username, string password)
        {
            if (loggedInUser != null)
            {
                Console.WriteLine("There is already a logged in user.");
                return; 
            }

            if ( !users.ContainsKey(username))
            {
                Console.WriteLine("There is no user with the given username.");
                return;
            }

            if (users[username] != password)
            {
                Console.WriteLine("The information you entered is incorrect.");
                return;
            }

            loggedInUser = username;
        }

        private static void Register(string username, string password, string confirmPassword)
        {
            if (users.ContainsKey(username))
            {
                Console.WriteLine("The given username already exists.");
                return;
            }
            if (password != confirmPassword)
            {
                Console.WriteLine("The two passwords must match.");
                return;
            }

            users[username] = password;
            //File.AppendAllText(dbPath, $"{username} {password}");  // same thing
            File.AppendAllLines(dbPath, new[] { $"{username} {password}" });
        }
    }
}
