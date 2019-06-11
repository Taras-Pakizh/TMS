using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS.Data
{
    class Report
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Project project { get; set; }

        public virtual Task task { get; set; }

        public virtual User engineer { get; set; }

        public ActivityType activity { get; set; }

        public ReportStatus status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime start { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime end { get; set; }

        [MinLength(1)]
        public string description { get; set; }

        public double effort { get; set; }

        public virtual ICollection<Approve> approves { get; set; }
    }

    enum ReportStatus
    {
        Open,
        Approved,
        Declined
    }

    enum ActivityType
    {
        BackEnd_Developing,
        FrontEnd_Developing,
        Testing,
        UI_Designing,
        DB_Designing,
        Bug_fixing
    }
}
