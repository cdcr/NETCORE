using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NetCore.Domain.Entities
{
    public class WeekPeriod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public int WorkedHours { get; set; }
        public DateTime UpdatedDate { get; set;}
        public ICollection<Employee> Employees { get; set; }
    }
}   
