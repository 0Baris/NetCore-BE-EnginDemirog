using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductID=1, CategoryID=1, ProductName="Kalem", UnitPrice=30, UnitsInStock=55},
                new Product{ProductID=2, CategoryID=2, ProductName="Defter", UnitPrice=40, UnitsInStock=15},
                new Product{ProductID=3, CategoryID=1, ProductName="Silgi", UnitPrice=15, UnitsInStock=45},
                new Product{ProductID=4, CategoryID=3, ProductName="Kitap", UnitPrice=34, UnitsInStock=22},
                new Product{ProductID=5, CategoryID=4, ProductName="C#", UnitPrice=999, UnitsInStock=1},
                new Product{ProductID=6, CategoryID=5, ProductName="Monitör", UnitPrice=5000, UnitsInStock=20}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // Varsayılan
            //Product productToDelete = null;
            //foreach (var pd in _products) { 
            //    if (product.ProductID == pd.ProductID)
            //    {
            //        productToDelete = pd;
            //    }
            //}

            // LINQ - Language Integrated Query - Dile gömülü sorgulama 
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductID == product.ProductID);

            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();

        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            // Gönderilen ürünün id'sine sahip olan ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);

            // Güncelleme işlemi
            productToUpdate.ProductID = product.ProductID;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
