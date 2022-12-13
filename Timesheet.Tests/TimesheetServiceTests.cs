using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Api.Models;
using Timesheet.Application.Services;
using Timesheet.Domain.Models;

namespace Timesheet.Tests
{
    internal class TimesheetServiceTests
    {
        [Test]
        public void TrackTime_ShouldReturnTrue()
        {
            // arrange

            var timeLog = new TimeLog
            {
                Date = new DateTime(),
                WorkingHours = 1, 
                LastName = "Иванов",
                Comment = Guid.NewGuid().ToString()
            };

            var service = new TimesheetService();


            // act
            var result = service.TrackTime(timeLog);

                // assert

            Assert.IsTrue(result);

        }

        [TestCase(-1, " ")]
        [TestCase(25, "Some user")]
        [TestCase(10, null )]
        [TestCase(5, "" )]
        [TestCase(5, "user")]
        public void TrackTime_ShouldReturnFalse(int hours, string lastName)
        {
            // arrange

            var timeLog = new TimeLog
            {
                Date = new DateTime(),
                WorkingHours = hours,
                LastName = lastName
            };
            // act
            var service = new TimesheetService();

            var result = service.TrackTime(timeLog);

            // assert

            Assert.IsFalse(result);

        }
    }
}
