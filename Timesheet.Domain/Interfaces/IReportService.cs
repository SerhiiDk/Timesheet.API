using Timesheet.Domain.Models;

namespace Timesheet.Domain.Iterfaces
{
    public interface IReportService
    {
        EmployeeReport GetEmployeeReport(string lastName);
    }
}