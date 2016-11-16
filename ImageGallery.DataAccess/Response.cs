using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ImageGallery.ApiDataAccess.Models
{
    [Serializable]
    public class Response<T>
    {
        public T Data
        {
            get;
            set;
        }
    }
}
