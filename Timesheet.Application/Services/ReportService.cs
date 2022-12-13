
using Timesheet.Domain.Interfaces;
using Timesheet.Domain.Iterfaces;
using Timesheet.Domain.Models;
using Timesheet.Domain.Services;

namespace Timesheet.Application.Services
{
    public class ReportService : IReportService
    {
        private const decimal MAX_WORKONG_HOURS_PER_MOUNTH = 160m;

        private readonly ITimesheetRepository _timesheetRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ReportService(ITimesheetRepository timesheetRepository, IEmployeeRepository employeeRepository)
        {
            _timesheetRepository = timesheetRepository;
            _employeeRepository = employeeRepository;
        }
        public EmployeeReport GetEmployeeReport(string lastName)
        {
            var employee = _employeeRepository.GetEmployee(lastName);
            var timeLogs = _timesheetRepository.GetTimeLogs(lastName);
            int hours = timeLogs.Sum(x => x.WorkingHours);


            decimal countEarnedMoney = (hours / MAX_WORKONG_HOURS_PER_MOUNTH) * employee.Salary;


            return new EmployeeReport
            {
                LastName = employee.LastName,
                TimeLogs = timeLogs.ToList(),
                EarnMoney = countEarnedMoney   
            };

        }
    }
}
