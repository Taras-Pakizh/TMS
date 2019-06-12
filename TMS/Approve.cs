using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TMS.Data
{
    [DataContract]
    public class Approve
    {
        [DataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public bool isApproved { get; set; }

        [DataMember]
        public string rootCase { get; set; }

        //[DataMember]
        public virtual Report report { get; set; }

        //[DataMember]
        public virtual User approveAuthor { get; set; }
    }
}
