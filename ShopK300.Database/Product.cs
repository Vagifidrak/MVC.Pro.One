using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopK300.Database
{
   public class Product:BaseTable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Thumbnail { get; set; }
        public Category Category { get; set; }
        public List<ProductToPicture> ProductToPictures { get; set; }
    }
}
