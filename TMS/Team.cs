using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS.Data
{
    class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<User> engineers { get; set; }

        public virtual User teamlead { get; set; }

        [MinLength(1), MaxLength(50)]
        public string name { get; set; }
    }
}
