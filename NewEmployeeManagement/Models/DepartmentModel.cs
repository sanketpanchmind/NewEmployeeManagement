using System.ComponentModel.DataAnnotations;

namespace NewEmployeeManagement.Models
{
    public class DepartmentModel : UserActivity
    {

        [Key]
        public int Id { get; set; }

        public string DepartmentName { get; set; }
    }
}
