using ShopK300.Database;
using ShopK300.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopK300.Services
{
   public class PictureService
    {
        //Tək şəkli tapmaq metodu
        public Picture GetPicture (int Id) { 
            using (ShopDbContext db=new ShopDbContext())
            {
                return db.Pictures.Find(Id);
            }
        }
        //ProductToPicturea Şəkil əlavə etmək
        public void SaveProductPicture (int pictureId, int productId)
        {
            using (ShopDbContext db = new ShopDbContext())
            {
                ProductToPicture proPic = new ProductToPicture()
                {
                    ProductID = productId,
                    PictureID = pictureId
                };
                db.ProductToPictures.Add(proPic);
                db.SaveChanges();
            }
        }
        //Şəkil əlavə etmək
        public void SavePicture(Picture picture)
        {
            using (ShopDbContext db = new ShopDbContext())
            {
                db.Pictures.Add(picture);
                db.SaveChanges();
            }
        }
    }
}
