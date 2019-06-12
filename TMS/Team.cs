﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TMS.Data
{
    [DataContract]
    public class Team
    {
        [DataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[DataMember]
        public virtual ICollection<User> engineers { get; set; }

        //[DataMember]
        public virtual User teamlead { get; set; }

        [DataMember]
        [MinLength(1), MaxLength(50)]
        public string name { get; set; }
    }
}
