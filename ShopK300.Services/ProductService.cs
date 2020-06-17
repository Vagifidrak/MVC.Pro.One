using ShopK300.Database;
using ShopK300.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopK300.Services
{
   public class ProductService
    {
        public List<Product> GetProducts() { //Burdaki ID saxta addi 
            using (ShopDbContext db=new ShopDbContext())
            {
                return db.Products.ToList();
            }
        }

        public Product GetProduct (int Id) { 
            using (ShopDbContext db=new ShopDbContext())
            {
                return db.Products.Find(Id);
            }
        }
        public void SaveProduct(Product product)
        {
            using (ShopDbContext db = new ShopDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
    }
}
