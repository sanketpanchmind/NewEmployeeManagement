using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEmployeeManagement.Models
{
    public class LeaveApplicationModel : UserActivity
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int NoofDays { get; set; }

        public string? Status {  get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [ValidateNever]
        public EmployeeModel Employee { get; set; }

        public int DurationId { get; set; }
        [ForeignKey("DurationId")]
        [ValidateNever]
        public LeaveDurationModel Duration { get; set; }

        public int LeavetypeId { get; set; }
        [ForeignKey("LeavetypeId")]
        [ValidateNever]
        public LeaveTypeModel LeaveType { get; set; }

     




    }
}
