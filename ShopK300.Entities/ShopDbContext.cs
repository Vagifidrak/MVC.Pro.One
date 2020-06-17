using ShopK300.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopK300.Entities
{
    class ShopDbContext:DbContext
    {
        public ShopDbContext() : base("ShopDbConnection") //Base Valideyn
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
