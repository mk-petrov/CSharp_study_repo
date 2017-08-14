
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
            string[] products = File.ReadAllLines(dbPath);

            foreach (var product in products)
            {
                var productParts = product.Split(' ', '|');
                var name = productParts[0];
                var type = productParts[1];
                
                database[productParts[0]]
            }

            var line = Console.ReadLine();

            while (!line.Equals("exit"))
            {
                var input = line.Split(' ');

                if (input.Length > 1)
                {
                    var newProduct = Product.Parse(input);

                    //if ( database.ContainsKey(newProduct.Name))
                    //{
                    //    if (database[newProduct.Name].Type == input[1])
                    //    {
                    //        database[newProduct.Name].Price = decimal.Parse(input[2]);
                    //        database[newProduct.Name].Quantity = int.Parse(input[3]);
                    //    }
                         
                    //}

                    database[newProduct.Name] = newProduct;
                }
                else
                {
                    //sales; analyze; stock 
                    switch (input[0])
                    {
                        case "sales":

                            break;
                        case "stock":
                            StockDatabase();
                            break;
                        case "analyze":

                            break;
                    }
                }

                line = Console.ReadLine();
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
                File.AppendAllLines(dbPath,new[] { $"{data.Key} | {data.Value.Type} | {data.Value.Price} | {data.Value.Quantity}" });
            }
        }
    }
}
