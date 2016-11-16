using ImageGallery.GenericDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.ApiDataAccess
{
    public class ApiDataRetriever : IDataRetriever
    {
        public string GetRequestData(string url)
        {
            Uri validateUri;
            if(!Uri.TryCreate(url, UriKind.Absolute, out validateUri))
            {
                throw new ArgumentException("url");
            }

            System.Net.WebClient webClient = new System.Net.WebClient();
            return webClient.DownloadString(url);
        }       
    }
}
