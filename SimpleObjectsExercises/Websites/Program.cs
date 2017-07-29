
namespace Websites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var websiteData = new List<Website>();

            var line = Console.ReadLine();

            while ( !line.Equals("end"))
            {
                var currentWebsite = Website.Parse(line);
                                
                websiteData.Add(currentWebsite);

                line = Console.ReadLine();
            }

            foreach (var website in websiteData)
            {
                Console.Write($"https://www.{website.Host}.{website.Domain}");

                if (website.Queries.Count > 0)
                {
                    Console.Write($"/query?=");

                    for (int i = 0; i < website.Queries.Count; i++)
                    {
                        Console.Write($"[{website.Queries[i]}]");

                        if (i == 0 || i < website.Queries.Count - 1)
                        {
                            Console.Write("&");
                        }                      
                    }
                    Console.WriteLine();
                }                                              
            }
            Console.WriteLine();
        }
    }
}
