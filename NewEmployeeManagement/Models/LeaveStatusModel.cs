using System.ComponentModel.DataAnnotations;

namespace NewEmployeeManagement.Models
{
    public class LeaveStatusModel : UserActivity
    {
        [Key]
        public int Id { get; set; }

        public string LeaveStatus { get; set; }
    }
}
