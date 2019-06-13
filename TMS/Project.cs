using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TMS.Data
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100), MinLength(1)]
        public string name { get; set; }

        [MaxLength(5), MinLength(1)]
        public string abbreviation { get; set; }

        [MinLength(1)]
        public string description { get; set; }

        public double effort { get; set; }

        [DataType(DataType.Date)]
        public DateTime start { get; set; }

        [DataType(DataType.Date)]
        public DateTime end { get; set; }

        public virtual ICollection<Risk> risks { get; set; }

        public virtual ICollection<Task> task { get; set; }
    }
}
