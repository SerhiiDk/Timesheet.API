namespace Timesheet.Domain.Iterfaces
{
    public interface IAuthService
    {
        List<string> Employees { get; }

        bool Login(string lastName);
    }
}