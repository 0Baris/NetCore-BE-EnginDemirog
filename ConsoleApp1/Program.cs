using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Date Transformation Object - DTO
            // IoC
            ProductTest();
            // CategoryTest();


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            // foreach (var category in categoryManager.GetAll())
            // {
            //     Console.WriteLine("Kategori İsmi: " + category.CategoryName);
            // }
        }

        private static void ProductTest()
        {
            // ProductManager productManager = new ProductManager(new EfProductDal());
            //
            // var result = productManager.GetProductDetails();
            //
            // if (result.Success == true)
            // {
            //     foreach (var product in result.Data)
            //     {
            //         Console.WriteLine("Ürün İsmi: " + product.ProductName + " - " + "Kategori: " + product.CategoryName);
            //         Console.WriteLine(result.Message);
            //     }
            // }
            // else
            // {
            //     Console.WriteLine(result.Message);
            // }
            
            // foreach (var product in productManager.GetProductDetails().Data)
            // {
            //     Console.WriteLine("Ürün İsmi: " + product.ProductName + " - " + "Kategori: " + product.CategoryName);
            // }
        }

    }
}
