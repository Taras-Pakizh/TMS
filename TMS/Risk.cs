using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS.Data
{
    class Risk
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual RiskStatus status { get; set; }

        public virtual Impact impact { get; set; }

        public virtual Project project { get; set; }

        [MinLength(1)]
        public string description { get; set; }
    }

    enum RiskStatus
    {
        Active,
        Closed
    }

    enum Impact
    {
        Low,
        Medium,
        High,
        Critical
    }
}
