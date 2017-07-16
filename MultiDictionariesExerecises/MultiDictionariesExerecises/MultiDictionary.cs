
namespace MultiDictionariesExerecises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    public class MultiDictionary
    {
        public static void Main()
        {
            //Every method represents a small problem

            //AverageStudentGrades();
            //CitiesByContinentAndCountry();
            //RecordUniqueNames();
            //GroupContinentsCounriesAndCities();
            //ShellBound();
            //DictRefAdvanced();
            //ForumTopics();             
            //SocialPosts();
            //PrintNestedDictionary();
            //NestedDictionary();
            //FillDictionary();
        }

        private static void PrintNestedDictionary()
        {
            var names = new Dictionary<string, Dictionary<string, string>>();

            names["klas"] = new Dictionary<string, string>();
            names["klas"]["grupC"] = "Ivan Ivanov";
            names["klas"]["grupB"] = "Stoqn Stoqnov";
            names["klas"]["grupA"] = "Petko Petkov";

            foreach (var item in names)
            {
                foreach (var innerItem in item.Value)
                {
                    Console.WriteLine("{0} -> {1} , {2}", item.Key, innerItem.Key, innerItem.Value);
                }
            }
        }

        private static void SocialPosts()
        {
            var postBase = new Dictionary<string, Dictionary<string, string>>();
            var postCounter = new Dictionary<string, List<int>>();

            var line = Console.ReadLine();

            while (line != "drop the media")
            {
                var tokens = line.Split(' ');
                var command = tokens[0];
                var post = tokens[1];

                switch (command)
                {
                    case "post":

                        if (! postBase.ContainsKey(post))
                        {
                            postBase[post] = new Dictionary<string, string>();
                        }
                        if (!postCounter.ContainsKey(post))
                        {
                            postCounter[post] = new List<int>();
                        }
                        postCounter[post].Add(0);
                        postCounter[post].Add(0);

                        break;
                    case "like":
                                                
                        postCounter[post][0] += 1;
                        
                        break;
                    case "dislike":
                                                                        
                        postCounter[post][1] += 1;
                        
                        break;
                    case "comment":
                                                
                        var postName = tokens[1];
                        var postCommentator = tokens[2];
                        var postComment = tokens[3];

                        if (! postBase.ContainsKey(postName))
                        {
                            postBase[postName] = new Dictionary<string, string>();
                        }

                        postBase[postName][postCommentator] = postComment;

                        break;
                    default:
                        Console.WriteLine("Not a valid input");
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine();

            foreach (var post in postBase)
            {
                var postName = post.Key;

                Console.WriteLine($"Post: {postName} | Likes: {string.Join("", postCounter[postName][0])} " +
                    $"| Dislikes: {string.Join("", postCounter[postName][1])}");

                Console.WriteLine("Comments:");
                                
                foreach (var comment in post.Value)
                {
                    
                    Console.WriteLine($"*  {comment.Key}: {string.Join("", comment.Value)}");
                }


                Console.WriteLine();
            }

            Console.WriteLine();
        }               

        public static void CreatePost(Dictionary<string, Dictionary<string, string>> posts, string postName)
        {
            if (!posts.ContainsKey(postName))
            {
                posts[postName] = new Dictionary<string, string>();
            }
            
        }

        public static void Counter(Dictionary<string, List<int>> commentsCounter, string postName)
        {            
            if (!commentsCounter.ContainsKey(postName))
            {
                commentsCounter[postName] = new List<int>();
            }
            commentsCounter[postName].Add(0);
        }

        private static void ForumTopics()
        {
            var forumTopics = new Dictionary<string, HashSet<string>>();
            var line = Console.ReadLine();

            while (! line.Equals("filter"))
            {
                var tokens = line.Split(new string[] { "->" },
                    StringSplitOptions.RemoveEmptyEntries);
                var topic = tokens[0];
                var tags = tokens[1].Split(new char[] { ',', ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                if (! forumTopics.ContainsKey(topic))
                {
                    forumTopics[topic] = new HashSet<string>();
                }

                foreach (var tag in tags)
                {
                    forumTopics[topic].Add(tag);
                }

                line = Console.ReadLine();
            }
            var filters = Console.ReadLine().Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine();
            foreach (var item in forumTopics)
            {
                foreach (var filter in filters)
                {
                    if (! item.Value.Contains(filter))
                    {
                        break;
                    }
                    Console.WriteLine("{0} | #{1}", item.Key, string.Join(", #", item.Value));
                }               
                
            }

            Console.WriteLine();
        }

        private static void DictRefAdvanced()
        {
            var notesByName = new Dictionary<string, List<int>>();
            var line = Console.ReadLine();
            
            while (! line.Equals("end"))
            {
                var tokens = line.Split(new string[] { " -> " }, 
                    StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var input = tokens[1].Split(new char[] { ',', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                bool isName = false;

                if (input.Length == 1)
                {
                    var otherKey = input[0];

                    if (notesByName.ContainsKey(otherKey))
                    {
                        notesByName[name] = notesByName[otherKey];
                        isName = true;
                    }
                    
                    
                }
                
                var notes = 0;
                
                if (! notesByName.ContainsKey(name) && ! isName)
                {
                    notesByName[name] = new List<int>();
                }

                foreach (var item in input)
                {
                    if (int.TryParse(item, out notes))
                    {
                        notesByName[name].Add(notes);
                    }
                }
                                
                line = Console.ReadLine();
            }

            foreach (var item in notesByName)
            {
                Console.WriteLine($"{item.Key} === {string.Join(", ", item.Value)}");
            }

        }

        private static void ShellBound()
        {
            var regionData = new Dictionary<string, HashSet<int>>();
            var line = Console.ReadLine();

            while (! line.Equals("Aggregate"))
            {
                var tokens = line.Split(' ');
                var regionName = tokens[0];
                var shell = int.Parse(tokens[1]);

                if (! regionData.ContainsKey(regionName))
                {
                    regionData[regionName] = new HashSet<int>();
                }

                regionData[regionName].Add(shell);

                line = Console.ReadLine();
            }

            Console.WriteLine();
            foreach (var region in regionData)
            {
                Console.WriteLine($"{region.Key} -> {string.Join(", ", region.Value)}" +
                    $" ({Math.Round(region.Value.Sum() - region.Value.Average())})");
            }

            Console.WriteLine();
        }

        private static void GroupContinentsCounriesAndCities()
        {
            var continentData =
                new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();

            var inputLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLine; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var continent = tokens[0];
                var country = tokens[1];
                var city = tokens[2];

                if (! continentData.ContainsKey(continent))
                {
                    continentData[continent] = 
                        new SortedDictionary<string, SortedSet<string>>();
                }

                if (! continentData[continent].ContainsKey(country))
                {
                    continentData[continent][country] = new SortedSet<string>();
                }

                continentData[continent][country].Add(city);
            }

            Console.WriteLine();
            foreach (var continent in continentData)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var kvp in continent.Value)
                {
                    Console.WriteLine($"    {kvp.Key} -> {string.Join(", ", kvp.Value)}");
                }
            }
            Console.WriteLine();
        }

        private static void RecordUniqueNames()
        {
            var names = new HashSet<string>();
            var sortedNames = new SortedSet<string>();
            var linesOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesOfInput; i++)
            {
                var token = Console.ReadLine();

                names.Add(token);
                sortedNames.Add(token);
            }

            Console.WriteLine("===== OUTPUT =====");
            Console.WriteLine(string.Join(Environment.NewLine, names));

            Console.WriteLine("===== SORTED =====");
            Console.WriteLine(string.Join(Environment.NewLine, sortedNames));

        }

        private static void NestedDictionary()
        {
            var countryAndPopulation = 
                new Dictionary<string, Dictionary<string, int>>();

            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                var tokens = line.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var country = tokens[0];
                var city = tokens[1];
                var population = int.Parse(tokens[2]);

                if (! countryAndPopulation.ContainsKey(country))
                {
                    countryAndPopulation[country] = new Dictionary<string, int>();
                }

                countryAndPopulation[country][city] = population;

                line = Console.ReadLine();
            }

            foreach (var item in countryAndPopulation)
            {                
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"{item.Key} -> {kvp.Key} -> {kvp.Value}");
                }
            }
        }

        private static void CitiesByContinentAndCountry()
        {
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var continent = tokens[0];
                var country = tokens[1];
                var city = tokens[2];

                if ( ! cities.ContainsKey(continent))
                {
                    cities[continent] = new Dictionary<string, List<string>>();                    
                }
                                
                if (!cities[continent].ContainsKey(country))
                {
                    cities[continent][country] = new List<string>();
                }

                cities[continent][country].Add(city);
                
            }

            Console.WriteLine();
            foreach (var continent in cities)
            {
                Console.WriteLine("{0}:", continent.Key);

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }


        }

        private static void AverageStudentGrades()
        {
            var studentGrades = new Dictionary<string, List<double>>();
            var studentCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentCount; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var stringGrade = tokens[1];
                double grade;

                if (double.TryParse(stringGrade, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out grade))   // input double: 5.50 format
                {
                    if ( ! studentGrades.ContainsKey(name))
                    {
                        studentGrades[name] = new List<double>();
                    }

                    studentGrades[name].Add(grade);
                }
                else
                {
                    Console.WriteLine("Grade is not a double");
                }

                
            }
            Console.WriteLine("====================");

            foreach (var kvp in studentGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", kvp.Value)} " +
                    $"(avg: {kvp.Value.Average():F2})");
            }

            Console.WriteLine("====================");
        }

        private static void FillDictionary()
        {
            var dataBase = new Dictionary<string, List<int>>();
            var line = Console.ReadLine();
            while (!line.Equals("end"))
            {
                var tokens = line.Split(' ');
                var name = tokens[0];
                var grade = int.Parse(tokens[1]);

                AddGrade(dataBase, name, grade);
                line = Console.ReadLine();
            }

            foreach (var kvp in dataBase)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(" ", kvp.Value)}");
            }
        }

        public static void AddGrade(Dictionary<string, List<int>> dataBase, string name, int grade)
        {
            if (!dataBase.ContainsKey(name))
            {
                dataBase[name] = new List<int>();
            }

            dataBase[name].Add(grade);
        }
    }
}