using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ImageGallery.GenericDataAccess
{
    public class ReponseDao<T>
    {
        private IDataRetriever _dataRetriever;
        private string _baseUrl;
        public ReponseDao(string baseUrl, IDataRetriever dataRetriever)
        {
            _dataRetriever = dataRetriever;
            _baseUrl = baseUrl;
        }

        public Response<T> GetResponse(string url)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Response<T>));
            var data = _dataRetriever.GetRequestData(url);

            if (String.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            return (Response<T>)serializer.Deserialize(memStream);
        }
    }
}
