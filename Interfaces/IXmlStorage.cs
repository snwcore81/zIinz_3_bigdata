using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zIinz_3_bigdata.Interfaces
{
    public interface IXmlStorage
    {
        bool FromXml(Stream Stream);

        MemoryStream ToXml();

    }
}
