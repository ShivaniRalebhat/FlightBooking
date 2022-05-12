using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserAPIServices.Model
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "username")]
        public string username { get; set; }

        [DataMember(Name = "emailid")]
        public string emailid { get; set; }

        [DataMember(Name = "usertype")]
        public int usertype { get; set; }

        [DataMember(Name = "password")]
        public string password { get; set; }

        [DataMember(Name = "isactive")]
        public bool isactive { get; set; }
    }
    [DataContract]
    public class LoginModel
    {
        

        [DataMember(Name = "emailid")]
        public string emailid { get; set; }


        [DataMember(Name = "password")]
        public string password { get; set; }

      
    }
}
