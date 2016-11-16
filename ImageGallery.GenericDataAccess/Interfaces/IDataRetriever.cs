using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.GenericDataAccess
{
    public interface IDataRetriever
    {
        string GetRequestData(string url);
    }
}
