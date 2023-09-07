using NetCore.Domain.Entities.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Column("first_name")]
        public string first_name { get; set; }
        [Column("last_name")]
        public string last_name { get; set; }
        [Column("address")]
        public string address{ get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("phone_number")]
        public string phone_number { get; set; }
        [Column("working_hours")]
        public int working_hours { get; set; }
        [Column("title")]
        public string title{ get; set; }
        [Column("is_full_time")]
        public bool is_full_time { get; set; }

        public Employee()
        { }

        public Employee(EmployeeDTO dto)
        {
            if(dto.Id != null)
                Id = dto.Id;
            first_name = dto.FirstName;
            last_name = dto.LastName;
            address = dto.Address;
            email = dto.Email;
            phone_number = dto.PhoneNumber;
            working_hours = dto.WorkingHours;
            title = dto.Title;
            is_full_time = dto.IsFullTime;
        }


    }

}

