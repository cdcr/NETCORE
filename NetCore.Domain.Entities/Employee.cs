using NetCore.Domain.Entities.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address{ get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("working_hours")]
        public int WorkingHours { get; set; }
        [Column("title")]
        public string Title{ get; set; }
        [Column("is_full_time")]
        public bool IsFullTime { get; set; }

        public Employee()
        { }

        public Employee(EmployeeDTO dto)
        {
            if(dto.Id != null)
                Id = dto.Id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Address = dto.Address;
            Email = dto.Email;
            PhoneNumber = dto.PhoneNumber;
            WorkingHours = dto.WorkingHours;
            Title = dto.Title;
            IsFullTime = dto.IsFullTime;
        }


    }

}

