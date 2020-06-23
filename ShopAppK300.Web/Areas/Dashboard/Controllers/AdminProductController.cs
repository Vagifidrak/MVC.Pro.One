using ShopK300.Database;
using ShopK300.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAppK300.Web.Areas.Dashboard.Controllers
{
    public class AdminProductController : Controller
    {
        ProductService productService = new ProductService();
        PictureService pictureService = new PictureService();
        // GET: Dashboard/AdminProduct
        public ActionResult Index()
        {
            return View(productService.GetProducts());
        }

        // GET: Dashboard/AdminProduct/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/AdminProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/AdminProduct/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                List<int> selectedPic = new List<int>();
                HttpFileCollectionBase photos = Request.Files;
                for (int i = 0; i < photos.Count; i++)
                {
                    HttpPostedFileBase file = photos[i];
                    string fname = Guid.NewGuid() + file.FileName;
                    Picture newPicture = new Picture()
                    {
                        Url = "/Uploads/" + fname.ToString() //bazaya elave edir
                    };
                    pictureService.SavePicture(newPicture);
                    selectedPic.Add(newPicture.ID);
                    var path = Server.MapPath("~/Uploads/")+fname;  //papkaya elave etmek
                    photos[i].SaveAs(path);
                }
                product.Thumbnail = selectedPic[0];  //ilk elave olan sekil ilk sekil o olacaq
                productService.SaveProduct(product);
                foreach (var selPic in selectedPic)   //id lere baxir selectedPicdeki listden
                {
                    pictureService.SaveProductPicture(selPic, product.ID);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/AdminProduct/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/AdminProduct/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/AdminProduct/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/AdminProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
