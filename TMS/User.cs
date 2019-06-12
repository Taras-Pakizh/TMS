using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TMS.Data
{
    [DataContract]
    public class User
    {
        [DataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [MinLength(1), MaxLength(50)]
        public string firstName { get; set; }

        [DataMember]
        [MinLength(1), MaxLength(50)]
        public string lastName { get; set; }

        [DataMember]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [DataMember]
        public Role role { get; set; }

        [DataMember]
        [MinLength(1), MaxLength(256)]
        public string login { get; set; }
    }

    public enum Role
    {
        Engineer,
        ProjectManager,
        TeamLead
    }
}
