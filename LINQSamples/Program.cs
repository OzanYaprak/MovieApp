


using LINQSamples.Data;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            var products = db.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        Console.ReadLine();
    }
}