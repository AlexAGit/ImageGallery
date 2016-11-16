using System;
using System.Xml.Serialization;

namespace ImageGallery.GenericDataAccess
{
    [Serializable]
    [XmlRoot(ElementName = "response", DataType = "string", IsNullable = true)]
    public class Response<T>
    {
        [XmlElement(ElementName ="data")]
        public T Data
        {
            get;
            set;
        }
    }
}
