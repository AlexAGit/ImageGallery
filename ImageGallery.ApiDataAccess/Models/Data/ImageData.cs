using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImageGallery.ApiDataAccess.Models
{
    [Serializable]
    public class ImageData
    {
        [XmlArray(ElementName = "images", IsNullable = true)]
        [XmlArrayItem(ElementName = "image", IsNullable = true, Type = typeof(Image))]
        public Image[] Images { get; set; }
    }
}
