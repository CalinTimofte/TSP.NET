using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestScenariu1();
        }

        static void TestScenariu1()
        {
            using (var db_context = new ModelSelfReferences())
            {
                var test_reference = new SelfReference()
                {
                    Name = "Test"
                };

                db_context.SelfReferences.Add(test_reference);
                db_context.SaveChanges();


                var get_ent = db_context.SelfReferences;
                foreach (var ii in get_ent)
                {
                    Console.WriteLine("{0} {1} {2}", ii.Name, ii.References, ii.SelfReferenceId);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        //static void TestScenariu2()
        //{
        //    using (var context = new ...Context()) {
        //        var product = new Product
        //        {
        //            SKU = 147,
        //            Description = "Expandable Hydration Pack",
        //            Price = 19.97M,
        //            ImageURL = "/pack147.jpg"
        //        }; context.Products.Add(product); product = new Product { SKU = 178, Description = "Rugged Ranger Duffel Bag", Price = 39.97M, ImageURL = "/pack178.jpg" }; context.Products.Add(product); product = new Product { SKU = 186, Description = "Range Field Pack", Price = 98.97M, ImageURL = "/noimage.jp" }; context.Products.Add(product); product = new Product { SKU = 202, Description = "Small Deployment Back Pack", Price = 29.97M, ImageURL = "/pack202.jpg" }; context.Products.Add(product); context.SaveChanges();
        //    }

        //    using (var context = new ...Context()) { foreach (var p in context.Products) { Console.WriteLine("{0} {1} {2} {3}", p.SKU, p.Description, p.Price.ToString("C"), p.ImageURL); } }
        //}
    }
}
