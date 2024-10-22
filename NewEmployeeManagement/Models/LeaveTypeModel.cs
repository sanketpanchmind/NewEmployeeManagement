using System.ComponentModel.DataAnnotations;

namespace NewEmployeeManagement.Models
{
    public class LeaveTypeModel : UserActivity
    {
        [Key]
        public int Id {  get; set; }

        public string LeaveType { get; set; }
    }
}
