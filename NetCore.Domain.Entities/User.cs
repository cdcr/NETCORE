using NetCore.Domain.Entities.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("title")]
        public string Title{ get; set; }
        [Column("status")]
        public string Status { get; set; }

        public User()
        { }

        public User(UserDTO dto)
        {
            if(dto.Id != null)
                Id = dto.Id;
            Name = dto.Name;
            Email = dto.Email;
            Title = dto.Title;
            Status = dto.Status;
        }


    }

}

