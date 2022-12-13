
using Timesheet.Domain.Iterfaces;
using Timesheet.Domain.Models;

namespace Timesheet.Application.Services
{
    public class TimesheetService : ITimesheetService
    {


        public bool TrackTime(TimeLog timeLog)
        {

            bool isValid = timeLog.WorkingHours > 0 && timeLog.WorkingHours <= 24;
            bool isContainsEmlpoyee = UserSession.Sessions.Contains(timeLog.LastName);
            bool isTimelogValid = isValid && isContainsEmlpoyee;


            if (
                timeLog == null || string.IsNullOrWhiteSpace(timeLog.LastName) || !isTimelogValid)
            {
                return false;
            }



            Timesheet.TimeLogs.Add(timeLog);


            return true;
        }
    }

    public static class Timesheet
    {
        public static List<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
    }
}
