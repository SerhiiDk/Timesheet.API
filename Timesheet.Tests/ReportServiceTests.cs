using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Application.Services;
using Timesheet.Domain.Interfaces;
using Timesheet.Domain.Iterfaces;
using Timesheet.Domain.Models;
using Timesheet.Domain.Services;

namespace Timesheet.Tests
{
    internal class ReportServiceTests
    {
        [Test]
        public void GetEmpoyeeRepost_ShouldReturnReport()
        {
            // arrange
            var timesheetRepositoryMock = new Mock<ITimesheetRepository>();
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var expectedLastName = "Иванов";
            var expectedTotal = 8750m; // (8+8+4)/160 * 7000(Salary)


            timesheetRepositoryMock.Setup(x => x.GetTimeLogs(It.Is<string>(y => y == expectedLastName)))
                .Returns(() => new[]
                {
                    new TimeLog
                    {
                        LastName = expectedLastName,
                        // two days ago
                        Date = DateTime.Now.AddDays(-2),
                        WorkingHours = 8,
                        Comment = Guid.NewGuid().ToString(),
                    },
                    new TimeLog
                    {
                        LastName = expectedLastName,
                        //yesterday
                        Date = DateTime.Now.AddDays(-1),
                        WorkingHours = 8,
                        Comment = Guid.NewGuid().ToString(),
                    },                    
                    new TimeLog
                    {
                        LastName = expectedLastName,
                        Date = DateTime.Now,
                        WorkingHours = 4,
                        Comment = Guid.NewGuid().ToString(),
                    }
                })
                .Verifiable();

            employeeRepositoryMock.Setup(x => x.GetEmployee(It.Is<string>(y => y == expectedLastName)))
                .Returns(() => new StaffEmployee 
                {
                    LastName = expectedLastName,
                    Salary = 70000
                })
                .Verifiable();


            var service = new ReportService(timesheetRepositoryMock.Object, employeeRepositoryMock.Object);

            // act
            var result = service.GetEmployeeReport("Иванов");
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedLastName,result.LastName);

            Assert.IsNotEmpty(result.TimeLogs);
            Assert.IsNotNull(result.TimeLogs);

            Assert.AreEqual(expectedTotal, result.EarnMoney);
        }
    }


    class TestTimesheetRepositoryMock : ITimesheetService

    {
        public bool TrackTime(TimeLog timeLog)
        {
            throw new NotImplementedException();
        }
    }



}
