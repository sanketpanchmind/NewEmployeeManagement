using System.ComponentModel.DataAnnotations;

namespace NewEmployeeManagement.Models
{
    public class LeaveDurationModel : UserActivity
    {
        //SemaphoreFullException day or half day 
        [Key]
        public int Id { get; set; }

        public string Duration { get; set; }


    }
}
