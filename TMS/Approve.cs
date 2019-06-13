using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TMS.Data
{
    public class Approve
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool isApproved { get; set; }

        public string rootCase { get; set; }

        public virtual Report report { get; set; }

        public virtual User approveAuthor { get; set; }
    }
}
