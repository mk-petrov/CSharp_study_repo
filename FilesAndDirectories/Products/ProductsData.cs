
namespace Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ProductsData
    {
        private static Dictionary<string, Product> database =
            new Dictionary<string, Product>();

        private static string dbPath = "ProductsDatabase.txt";

        public static void Main()
        {

            //“Food”, “Electronics”, “Domestics”.

            //LOAD DATA FROM DATABASE
            if (File.Exists(dbPath))
            {
                string[] products = File.ReadAllLines(dbPath);

                foreach (var product in products)
                {
                    var productParts = product.Split(' ');
                    
                    var newProduct = Product.Parse(productParts);

                    database[newProduct.Name] = newProduct;

                }
            }

            var line = Console.ReadLine();

            while (!line.Equals("exit"))
            {
                var input = line.Split(' ');

                if (input.Length > 1)
                {
                    var newProduct = Product.Parse(input);
                    
                    database[newProduct.Name] = newProduct;
                }
                else
                {
                    //sales; analyze; stock 
                    switch (input[0])
                    {
                        case "sales":
                            Sales();
                            break;
                        case "stock":
                            StockDatabase();
                            break;
                        case "analyze":
                            Analyze();
                            break;
                    }
                }

                line = Console.ReadLine();
            }


        }

        private static void Sales()
        {
            var sumOfProducts = new Dictionary<string, decimal>();

            sumOfProducts["Electronics"] = 0;
            sumOfProducts["Food"] = 0;
            sumOfProducts["Domestics"] = 0;

            foreach (var product in database)
            {
                var typeOfProduct = product.Value.Type;
                                                                
                switch (typeOfProduct)
                {
                    case "Electronics":
                        sumOfProducts["Electronics"] += product.Value.Quantity * product.Value.Price;                        
                        break;
                    case "Food":
                        sumOfProducts["Food"] += product.Value.Quantity * product.Value.Price;
                        break;
                    case "Domestics":
                        sumOfProducts["Domestics"] += product.Value.Quantity * product.Value.Price;
                        break;
                }
                
            }

            foreach (var sum in sumOfProducts.OrderByDescending(x => x.Value))
            {
                if (sum.Value != 0)
                {
                    Console.WriteLine($"{sum.Key}: ${sum.Value}");
                }
                else
                {
                    Console.WriteLine("No products stocked");
                }
                
            }
        }

        private static void Analyze()
        {
            if (File.Exists(dbPath))
            {
                string[] products = File.ReadAllLines(dbPath);
                var tempDatabase = new Dictionary<string, Product>();
                                
                foreach (var product in products)
                {
                    var productParts = product.Split(' ');
                    var newProduct = Product.Parse(productParts);

                    tempDatabase[newProduct.Name] = newProduct;                                        
                }

                foreach (var tempProduct in tempDatabase.OrderBy(x => x.Value.Type))
                {
                    Console.WriteLine($"{tempProduct.Value.Type}, Product: {tempProduct.Key}");
                    Console.WriteLine($"Price: ${tempProduct.Value.Price:f2}, Amount Left: {tempProduct.Value.Quantity}");

                }
            }            
        }

        private static void StockDatabase()
        {
            
            if ( !File.Exists(dbPath))
            {
                File.Create(dbPath).Close();
            }

            foreach (var data in database)
            {
                File.AppendAllLines(dbPath,new[] { $"{data.Key} {data.Value.Type} {data.Value.Price} {data.Value.Quantity}" });
            }
        }
    }
}
