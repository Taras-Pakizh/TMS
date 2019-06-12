using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TMS.Data
{
    [DataContract]
    public class Report
    {
        [DataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public virtual Task task { get; set; }

        //[DataMember]
        public virtual User engineer { get; set; }

        [DataMember]
        public ActivityType activity { get; set; }

        [DataMember]
        public ReportStatus status { get; set; }

        [DataMember]
        [DataType(DataType.DateTime)]
        public DateTime start { get; set; }

        [DataMember]
        [DataType(DataType.DateTime)]
        public DateTime end { get; set; }

        [DataMember]
        [MinLength(1)]
        public string description { get; set; }

        [DataMember]
        public double effort { get; set; }

        //[DataMember]
        public virtual ICollection<Approve> approves { get; set; }
    }

    public enum ReportStatus
    {
        Open,
        Approved,
        Declined
    }

    public enum ActivityType
    {
        BackEnd_Developing,
        FrontEnd_Developing,
        Testing,
        UI_Designing,
        DB_Designing,
        Bug_fixing
    }
}
