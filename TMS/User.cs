using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS.Data
{
    class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(1), MaxLength(50)]
        public string firstName { get; set; }

        [MinLength(1), MaxLength(50)]
        public string lastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public Role role { get; set; }
    }

    enum Role
    {
        Engineer,
        ProjectManager,
        TeamLead
    }
}
