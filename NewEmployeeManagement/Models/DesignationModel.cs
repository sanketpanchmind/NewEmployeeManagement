using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEmployeeManagement.Models
{
    public class DesignationModel : UserActivity
    {
        [Key]
        public int Id { get; set; }

        public string Designation {  get; set; }

        public int DeptId {  get; set; }
        [ForeignKey("DeptId")]
        [ValidateNever]
        public DepartmentModel Departments { get; set; }
    }
}
