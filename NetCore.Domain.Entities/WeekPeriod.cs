namespace NetCore.Domain.Entities
{
    public class WeekPeriod
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public int WorkedHours { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
