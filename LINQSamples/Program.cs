


using LINQSamples.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

class ProductModel
{
    public string Name { get; set; }
    public decimal? Price { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            var product = db.Products.FirstOrDefault(a => a.ProductId == 1);

            if (product != null) 
            {
                product.UnitsInStock += 10;
                db.SaveChanges();

                Console.WriteLine("Veri Güncellendi.");
            }
        }

        Console.ReadLine();
    }


    private static void LINQORNEKLER()
    {
        //using (var db = new NorthwindContext())
        //{
        //    // Tüm müşteri kayıtlarını getiriniz (Customers)
        //    //var customers = db.Customers.ToList();


        //    //foreach (var customer in customers)
        //    //{
        //    //    Console.WriteLine(customer.ContactName);
        //    //}



        //    // Tüm müşterilerin sadece CustomerID ve ContactName kolonlarını getiriniz.
        //    //var customers = db.Customers.Select(a => new { a.CustomerId, a.ContactName }).ToList();


        //    //foreach (var customer in customers)
        //    //{
        //    //    Console.WriteLine(customer.CustomerId + " " + customer.ContactName);
        //    //}



        //    // Almanyada yaşayan müşterilerin adlarını getiriniz.
        //    //var customers = db.Customers.Select(a => new { a.ContactName, a.Country }).Where(a => a.Country == "Germany").ToList();


        //    //foreach (var customer in customers)
        //    //{
        //    //    Console.WriteLine(customer.ContactName + " " + customer.Country);
        //    //}



        //    // "Diego Roel" isimli müşteri nerede yaşamaktadır ?
        //    //var customer = db.Customers.Where(a => a.ContactName == "Diego Roel").FirstOrDefault();
        //    //Console.WriteLine(customer.ContactName + " " + customer.Country);



        //    // Stokta olmayan ürünler hangileridir ?
        //    //var products = db.Products.Select(a => new { a.ProductName, a.UnitsInStock }).Where(a => a.UnitsInStock == 0).ToList();

        //    //foreach (var product in products)
        //    //{
        //    //    Console.WriteLine(product.ProductName + " " + product.UnitsInStock);
        //    //}



        //    // Tüm çalışanların ad ve soyadlarını tek kolon şeklinde getiriniz.
        //    //var employess = db.Employees.Select(a => new { FullName = a.FirstName + " " + a.LastName }).ToList();

        //    //foreach (var employee in employess)
        //    //{
        //    //    Console.WriteLine(employee.FullName);
        //    //}



        //    // Ürünler tablosundaki ilk 5 kaydı alınız.
        //    //var products = db.Products.Take(5).ToList();

        //    //foreach (var product in products)
        //    //{
        //    //    Console.WriteLine(product.ProductId + " " + product.ProductName);
        //    //}



        //    // Ürünler tablosundaki ikinci 5 kaydı alınız. (Take, Skip)
        //    //var products = db.Products.Skip(5).Take(5).ToList();

        //    //foreach (var product in products)
        //    //{
        //    //    Console.WriteLine(product.ProductId + " " + product.ProductName);
        //    //}
        //}

        //Console.ReadLine();
    }
    private static void KayıtEklemeSorguları(NorthwindContext db)
    {
        //  YENİ EKLENEN ÜRÜNE KATEGORİ BİLGİSİNİ VERME 


        //var p1 = new Product() { ProductName = "Yeni Ürün 4", CategoryId = 1 };
        //var p2 = new Product() { ProductName = "Yeni Ürün 5", CategoryId = 1 };

        //var products = new List<Product>() { p1, p2 };

        //db.Products.AddRange(products);
        //db.SaveChanges();

        //Console.WriteLine("Yeni Veriler Eklendi..");
        //Console.WriteLine(p1.ProductId);
        //Console.WriteLine(p2.ProductId);




        // VEYA 



        //var category = db.Categories.Where(a=>a.CategoryName== "Beverages").FirstOrDefault();

        //var p1 = new Product() { ProductName = "Yeni Ürün 6", Category = category };
        //var p2 = new Product() { ProductName = "Yeni Ürün 7", Category = category };

        //var products = new List<Product>() { p1, p2 };

        //db.Products.AddRange(products);
        //db.SaveChanges();

        //Console.WriteLine("Yeni Veriler Eklendi..");
        //Console.WriteLine(p1.ProductId);
        //Console.WriteLine(p2.ProductId);




        // VEYA KATEGORİ TABLOSUNDA OLMAYAN BİR KATEGORİYİ VERİ EKLERKEN GİRMEK İÇİN





        //var p1 = new Product() { ProductName = "Yeni Ürün 8", Category = new Category() { CategoryName="Yeni Kategori 1" } };
        //var p2 = new Product() { ProductName = "Yeni Ürün 9", Category = new Category() { CategoryName = "Yeni Kategori 2" } };

        //var products = new List<Product>() { p1, p2 };

        //db.Products.AddRange(products);
        //db.SaveChanges();

        //Console.WriteLine("Yeni Veriler Eklendi..");
        //Console.WriteLine(p1.ProductId);
        //Console.WriteLine(p2.ProductId);




        // KATEGORİ TABLOSUNDAKİ PRODUCT NAVİGASYONUNU KULLANARAK YENİ VERİ EKLENMESİ 




        //var category = db.Categories.Where(a => a.CategoryName == "Beverages").FirstOrDefault();

        //var p1 = new Product() { ProductName = "Yeni Ürün 10" };
        //var p2 = new Product() { ProductName = "Yeni Ürün 11" };

        //category.Products.Add(p1);
        //category.Products.Add(p2);

        //db.SaveChanges();

        //Console.WriteLine("Yeni Veriler Eklendi..");
        //Console.WriteLine(p1.ProductId);
        //Console.WriteLine(p2.ProductId);

    }
    private static void SıralamaVeHesaplamaSorguları()
    {
        //var result = db.Products.Count(); // Product tablosundaki ürünlerin sayısını göster  FOREACH YOK

        //var result = db.Products.Count(a => a.UnitPrice >= 10 && a.UnitPrice <= 30);  // unitprice 10 dahil 10 dan büyük ve 30 dahil 30 dan küçük olanları listele. FOREACH YOK

        //var result = db.Products.Count(a => a.Discontinued == false); // Satışta olan ürünleri listele. FOREACH YOK

        //var result = db.Products.Min(a => a.UnitPrice);  // Satışta olan minimum fiyat FOREACH YOK

        //var result = db.Products.Max(a => a.UnitPrice);  // Satışta olan maksimum fiyat FOREACH YOK

        //var result = db.Products.Where(a => a.CategoryId == 2).Max(a => a.UnitPrice);  // Kategori ıd si 2 olan kategorideki maksimum fiyatı listele FOREACH YOK

        //var result = db.Products.Average(a => a.UnitPrice); // Bütün ürünlerin ortalama fiyatlarını ver. FOREACH YOK

        //var result = db.Products.Where(a => a.Discontinued == false).Average(a => a.UnitPrice); // Satışta olan bütün ürünlerin ortalama fiyatlarını ver. FOREACH YOK

        //var result = db.Products.Where(a => a.Discontinued == false).Sum(a => a.UnitPrice); // Satışta olan bütün ürünlerin toplam fiyatlarını ver. FOREACH YOK

        //var result = db.Products.OrderBy(a => a.UnitPrice).ToList(); // Ürün fiyatı artarak giden liste (EN DÜŞÜK FİYATLI OLAN ÜRÜN EN BAŞTA)

        //var result = db.Products.OrderByDescending(a => a.UnitPrice).ToList(); // Ürün fiyatı artarak giden liste (EN YÜKSEK FİYATLI OLAN ÜRÜN EN BAŞTA)

        //var result = db.Products.OrderByDescending(a => a.UnitPrice).FirstOrDefault();  // Ürün fiyatı artarak giden liste içindeki ilk ürünü yazdırır

        //var result = db.Products.OrderByDescending(a => a.UnitPrice).LastOrDefault(); // Ürün fiyatı artarak giden liste içindeki son ürünü yazdırır

        //Console.WriteLine(result.ProductName + " " + result.UnitPrice);
    }
    private static void FiltrelemeSorguları(NorthwindContext db)
    {
        //var products = db.Products.Where(a=>a.UnitPrice>18).ToList();
        //var products = db.Products.Select(a => new { a.ProductName, a.UnitPrice }).Where(a => a.UnitPrice > 18).ToList();
        //var products = db.Products.Select(a => new { a.ProductName, a.UnitPrice }).Where(a => a.UnitPrice > 18 && a.UnitPrice<30).ToList();
        //var products = db.Products.Where(a => a.CategoryId == 1).ToList();
        //var products = db.Products.Where(a => a.CategoryId >= 1 && a.CategoryId <= 5).ToList(); // 1 dahil yazmak istiyorsak < operatörünün yanına = (<=) - (>=) eklememiz gerekiyor !!
        //var products = db.Products.Where(a => a.CategoryId == 1 || a.CategoryId == 5).ToList();
        //var products = db.Products.Where(a => a.CategoryId == 1).Select(a => new { a.ProductName, a.UnitPrice }).ToList(); // kategori ıd si 1 olan tabloyu ilk seçmemiz gerekiyor, buna göre daha sonra select yazılıyor.
        //var products = db.Products.Where(a => a.ProductName=="Chai").ToList();
        //var products = db.Products.Where(a => a.ProductName.Contains("Ch")).ToList();



        //foreach (var product in products)
        //{
        //    Console.WriteLine(product.ProductName + " " + product.UnitPrice);
        //}
    }
    private static void SeçmeSorguları(NorthwindContext db)
    {
        //var products = db.Products.ToList();
        //var products = db.Products.Select(a => a.ProductName).ToList();
        //var products = db.Products.Select(a => new {a.ProductName, a.UnitPrice}).ToList();
        //var products = db.Products.Select(a => new ProductModel { Name = a.ProductName, Price = a.UnitPrice }).ToList();

        //var product = db.Products.First();
        //var product = db.Products.Select(a => new { a.ProductName, a.UnitPrice }).FirstOrDefault();

        //Console.WriteLine(product.ProductName + "" + product.UnitPrice);

        //foreach (var product in products)
        //{
        //    Console.WriteLine(product.Name + "" + product.Price);
        //}
    }
}