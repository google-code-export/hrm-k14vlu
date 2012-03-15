using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel.DomainServices.Server.ApplicationServices;
using System.Runtime.Serialization;

namespace WebManagement.Service
{
    [DataContractAttribute(IsReference = false)]
    [MetadataTypeAttribute(typeof(LoginUser.LoginUserMetadata))]
    public sealed class LoginUser : IUser
    {
        internal sealed class LoginUserMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private LoginUserMetadata()
            {
            }

            [Key]
            public string Name { get; set; }
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public IEnumerable<string> Roles { get; set; }

        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int UserType { get; set; }
        [DataMember]
        public Dictionary<string, string> Settings { get; set; }
    }
}
