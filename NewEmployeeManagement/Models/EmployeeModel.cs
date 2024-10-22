using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace NewEmployeeManagement.Models
{
    public class EmployeeModel : UserActivity
    {
        //designation & dept model need to b created
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string ContactNo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public DepartmentModel Departments { get; set; }

        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        [ValidateNever]
        public DesignationModel Designations { get; set; }




    }
}
