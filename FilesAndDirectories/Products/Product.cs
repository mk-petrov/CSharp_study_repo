
namespace Products
{
    public class Product
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }
                
        public static Product Parse(string[] input)
        {
            
            return new Product
            {
                Name = input[0],
                Type = input[1],
                Price = decimal.Parse(input[2]),
                Quantity = int.Parse(input[3])
            };
        }
    }
}
