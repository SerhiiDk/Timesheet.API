using Timesheet.Domain.Models;

namespace Timesheet.Domain.Services
{
    public interface IEmployeeRepository
    {
        StaffEmployee GetEmployee(string lastName);
    }
}