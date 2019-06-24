using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;

namespace TMS.Client.ViewModels
{
    public class ReportValidationModel : IValidatableObject
    {
        [Required(ErrorMessage = "Activity type is required")]
        public ActivityType? activity { get; set; }

        [Required(ErrorMessage = "Begin date is required")]
        public DateTime? start { get; set; }

        
        [Required(ErrorMessage = "End date is required")]
        public DateTime? end { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }

        [Required(ErrorMessage = "Task is required")]
        public ViewTask task { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (end < start)
            {
                yield return
                  new ValidationResult(errorMessage: "End Date must be greater than Begin Date",
                                       memberNames: new[] { "end" });
            }
            if(end != null && start != null)
            {
                if(_IsWeekend(((DateTime)end).DayOfWeek) || _IsWeekend(((DateTime)start).DayOfWeek))
                    yield return 
                        new ValidationResult(errorMessage: "End date and Begin date shouldn't be a weekend",
                                       memberNames: new[] { "end" });
            }
        }

        private bool _IsWeekend(DayOfWeek day)
        {
            if(day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }
    }
}
