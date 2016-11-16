using System;
using System.Xml.Serialization;

namespace ImageGallery.ApiDataAccess.Models
{
    [Serializable]
    public class Category
    {
        [XmlElement(ElementName = "id", DataType = "int")]
        public int Id { get; set; }
        [XmlElement(ElementName = "name", DataType = "string")]
        public string Name { get; set; }
    }
}
