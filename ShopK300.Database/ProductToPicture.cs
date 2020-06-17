using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopK300.Database
{
   public class ProductToPicture:BaseTable
    {
        public int ProductID { get; set; }
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }    
    }
}
