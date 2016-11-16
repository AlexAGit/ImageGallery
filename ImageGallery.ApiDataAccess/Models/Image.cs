using System;
using System.Xml.Serialization;

namespace ImageGallery.ApiDataAccess.Models
{
    [Serializable]
    public class Image
    {
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "source_url")]
        public string SourceUrl { get; set; }
    }
}
