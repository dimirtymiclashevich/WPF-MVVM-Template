using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AppName.Models
{
    [DataContract]
    public class Users
    {
        [DataMember]
        public string Status { get; set; }

        [DataMember(Name = "Data")]
        public List<User> UserList { get; private set; }

        public Users()
        {
            UserList = new List<User>();
        }
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string SecondName { get; set; }

        [DataMember]
        public int Age { get; set; }

        [IgnoreDataMember]
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName;
            }
        }
    }
}
