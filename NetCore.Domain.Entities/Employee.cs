using NetCore.Domain.Entities.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Domain.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress{ get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public bool IsFullTime { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal HourRate { get; set; }
        public bool Active { get; set; }

        public Employee()
        { }

        public Employee(EmployeeDTO dto)
        {
            if(dto.Id != null)
                Id = dto.Id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Adress = dto.Address;
            Email = dto.Email;
            PhoneNumber = dto.PhoneNumber;
            Title = dto.Title;
            IsFullTime = dto.IsFullTime;
        }
    }
}

