using Timesheet.Domain.Models;

namespace Timesheet.Domain.Iterfaces
{
    public interface ITimesheetService
    {
        bool TrackTime(TimeLog timeLog);
    }
}