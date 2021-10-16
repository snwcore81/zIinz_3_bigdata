using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace zIinz_3_bigdata.Classes.Bussines
{
    [DataContract]
    public class User : AutoInitXmlStorage<User>
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Permission { get; set; }
        [DataMember]
        public ResponseObject Response { get; set; }

        public User()
        {
            BaseObject = this;
            Response = new ResponseObject();
        }

        public override string ToString()
        {
            return $"[Login={Login}|Password=???|Permission={Permission}|Response={Response}";
        }
    }
}
