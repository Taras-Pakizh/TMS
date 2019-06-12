using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TMS.Data
{
    [DataContract]
    public class Risk
    {
        [DataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public virtual RiskStatus status { get; set; }

        [DataMember]
        public virtual Impact impact { get; set; }

        //[DataMember]
        public virtual Project project { get; set; }

        [DataMember]
        [MinLength(1)]
        public string description { get; set; }
    }

    public enum RiskStatus
    {
        Active,
        Closed
    }

    public enum Impact
    {
        Low,
        Medium,
        High,
        Critical
    }
}
