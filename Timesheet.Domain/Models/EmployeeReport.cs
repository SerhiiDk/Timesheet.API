namespace Timesheet.Domain.Models
{
    public class EmployeeReport
    {
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<TimeLog> TimeLogs { get; set; }


        public int TotalHours { get; set; }
        public decimal EarnMoney { get; set; }
    }
}
