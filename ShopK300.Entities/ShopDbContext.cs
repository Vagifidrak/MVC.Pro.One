using ShopK300.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopK300.Entities
{
   public class ShopDbContext:DbContext,IDisposable
    {
        public ShopDbContext() : base("ShopDbConnection") //Valideynin konstruktoruna göndərmək üçün
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductToPicture> ProductToPictures { get; set; }
    }
}
