using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ImageGallery.ApiDataAccess.Models
{
    [Serializable]
    public class CategoryData
    {
        [XmlArray(ElementName = "categories", IsNullable = true)]
        [XmlArrayItem(ElementName = "category", IsNullable= true, Type = typeof(Category))]
        public Category[] Categories { get; set; }
    }
}
