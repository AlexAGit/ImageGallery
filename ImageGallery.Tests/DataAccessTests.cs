using ImageGallery.ApiDataAccess.Models;
using ImageGallery.GenericDataAccess;
using Moq;
using NUnit.Framework;
using System;

namespace ImageGallery.Tests
{
    [TestFixture]
    public class DataAccessTests
    {
        private Mock<IDataRetriever> _dataRetrieverMock;
        private ReponseDao<CategoryData> _categoryDataDao;
        private ReponseDao<ImageData> _imageDataDao;

        [SetUp]
        public void Setup()
        {
            _dataRetrieverMock = new Mock<IDataRetriever>();
            _categoryDataDao = new ReponseDao<CategoryData>(string.Empty, _dataRetrieverMock.Object);
            _imageDataDao = new ReponseDao<ImageData>(string.Empty, _dataRetrieverMock.Object);
        }

        [Test]
        public void EmptyDataTest()
        {
            _dataRetrieverMock.Setup(r => r.GetRequestData(It.IsAny<string>())).Returns((string param)=> { return string.Empty; });
            var categoryResponse = _categoryDataDao.GetResponse(string.Empty);
            var imageResponse = _imageDataDao.GetResponse(string.Empty);
            Assert.IsNull(categoryResponse, "If no data is retrieved the category response will be null");
            Assert.IsNull(imageResponse, "If no data is retrieved the image response will be null");
        }

        [TestCase("")]
        [TestCase("http:/invalid-url")]
        public void ApiDataRetrieverBadUrlTest(string url)
        {
            var apiDataRetriever = new ApiDataAccess.ApiDataRetriever();
            ArgumentException argumentException = null;
            try
            {
                apiDataRetriever.GetRequestData(url);
            }
            catch(ArgumentException exception)
            {
                argumentException = exception;
            }

            Assert.IsNotNull(argumentException);
        }

        [TestCase(@"<?xml version=""1.0""?><response><data><categories><category><id>1</id><name>hats</name></category></categories></data></response>")]
        public void CategoryResponseDeserializationTest(string data)
        {
            _dataRetrieverMock.Setup(r => r.GetRequestData(It.IsAny<string>())).Returns((string param) => { return data; });
            var categoryResponse = _categoryDataDao.GetResponse(string.Empty);
            Assert.IsNotEmpty(categoryResponse.Data.Categories);
            Assert.AreEqual(categoryResponse.Data.Categories[0].Id, 1);
            Assert.AreEqual(categoryResponse.Data.Categories[0].Name, "hats");
        }

        [TestCase(@"<?xml version=""1.0""?><response><data><images><image><url>http://image.jpg</url><id>5if</id><source_url>http://thecatapi.com/?id=5if</source_url></image></images></data></response>")]
        public void ImageResponseDeserializationTest(string data)
        {
            _dataRetrieverMock.Setup(r => r.GetRequestData(It.IsAny<string>())).Returns((string param) => { return data; });
            var imageResponse = _imageDataDao.GetResponse(string.Empty);
            Assert.IsNotEmpty(imageResponse.Data.Images);
            Assert.AreEqual(imageResponse.Data.Images[0].Id, "5if");
            Assert.AreEqual(imageResponse.Data.Images[0].Url, "http://image.jpg");
            Assert.AreEqual(imageResponse.Data.Images[0].SourceUrl, "http://thecatapi.com/?id=5if");
        }
    }
}
