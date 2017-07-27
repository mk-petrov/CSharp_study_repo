
namespace SimpleObjects2
{
    public class Sale
    {
        public string Town { get; set; }

        public string Product { get; set; }

        public decimal Price { get; set; }   // decimal always with money operations

        public decimal Quantity { get; set; }

        public static Sale Parse(string saleAsString)
        {
            var saleParts = saleAsString.Split(' ');

            return new Sale
            {
                Town = saleParts[0],
                Product = saleParts[1],
                Price = decimal.Parse(saleParts[2]),
                Quantity = decimal.Parse(saleParts[3])
            };
        }
    }
}
