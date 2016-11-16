using ImageGallery.ApiDataAccess.Models;
using ImageGallery.GenericDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.ApiDataAccess.Dao
{
    public class GalleryRepository
    {
        private string BaseCategoriesUrl = "http://thecatapi.com/api/categories/list";
        private string BaseCategoryImagesUrl = "http://thecatapi.com/api/images/get?format=xml&amp;results_per_page={0}&amp;category={1}";

        private ReponseDao<CategoryData> _categoryDao;
        private ReponseDao<ImageData> _imageDao;

        public GalleryRepository()
        {
            _categoryDao = new ReponseDao<CategoryData>(BaseCategoriesUrl, new ApiDataRetriever());
            _imageDao = new ReponseDao<ImageData>(BaseCategoryImagesUrl, new ApiDataRetriever());
        }

        public Response<CategoryData> GetCategories()
        {
            return _categoryDao.GetResponse(BaseCategoriesUrl);
        }

        public Response<ImageData> GetImagesForCategory(string categoryName, int resultsPerPage)
        {
            if(resultsPerPage <= 0)
            {
                throw new ArgumentOutOfRangeException("resultsPerPage");
            }

            if (String.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentNullException("categoryName");
            }

            var imagesUrl = string.Format(BaseCategoryImagesUrl, resultsPerPage, categoryName);
            return _imageDao.GetResponse(imagesUrl);
        }
    }
}
