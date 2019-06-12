using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TMS.Data
{
    [DataContract]
    public class Project
    {
        [DataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [MaxLength(100), MinLength(1)]
        public string name { get; set; }

        [DataMember]
        [MaxLength(5), MinLength(1)]
        public string abbreviation { get; set; }

        [DataMember]
        [MinLength(1)]
        public string description { get; set; }

        [DataMember]
        public double effort { get; set; }

        [DataMember]
        [DataType(DataType.Date)]
        public DateTime start { get; set; }

        [DataMember]
        [DataType(DataType.Date)]
        public DateTime end { get; set; }

        //[DataMember]
        public virtual ICollection<Risk> risks { get; set; }

        //[DataMember]
        public virtual ICollection<Task> task { get; set; }
    }
}
