using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace zIinz_3_bigdata.Classes.Bussines
{
    [DataContract]
    public class ResponseObject : AutoInitXmlStorage<ResponseObject>
    {
        [DataMember]
        public string ResponseString { get; set; }

        public ResponseObject()
        {
            ResponseString = string.Empty;
        }
        public override string ToString()
        {
            return $"[ResponseString={ResponseString}]";
        }
    }
}
