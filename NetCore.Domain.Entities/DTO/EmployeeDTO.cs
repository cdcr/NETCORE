namespace NetCore.Domain.Entities.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkingHours { get; set; }
        public string Title { get; set; }
        public bool IsFullTime { get; set; }
    }
}
