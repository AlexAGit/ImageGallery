using ImageGallery.ApiDataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            var repository = new GalleryRepository();
             
            return View(repository.GetCategories());
        }

        public ActionResult CategoryImages(string categoryName, int itemsPerPage = 5)
        {
            var repository = new GalleryRepository();

            return View(repository.GetImagesForCategory(categoryName, itemsPerPage));
        }
    }
}