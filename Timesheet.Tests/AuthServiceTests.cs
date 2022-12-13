using NUnit.Framework;
using Timesheet.Application.Services;

namespace Timesheet.Tests
{
    public class AuthServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Иванов")]
        [TestCase("Петров")]
        [TestCase("Сидоров")]
        public void Login_ShouldReturnTrue(string lastName)
        {
            // arrange
            //подготовка теста

            var service = new AuthService();
            // act
            // випольнения теста

            var result = service.Login(lastName);

            // етап проверки логики 
            // assert
            Assert.IsNotNull(UserSession.Sessions);
            Assert.IsNotEmpty(UserSession.Sessions);
            Assert.IsTrue(UserSession.Sessions.Contains(lastName));
            Assert.IsTrue(result);
        }
        // проверка если пользователь два раза логиниться
        [Test]
        public void Login_InvokeLoginTwiceForOneLastName_ShouldReturnTrue()
        {
            // arrange
            //подготовка теста
            var lastName = "Иванов";
            var service = new AuthService();
            // act
            // випольнения теста

            var result = service.Login(lastName);
            result = service.Login(lastName);

            // етап проверки логики 
            // assert
            Assert.IsNotNull(UserSession.Sessions);
            Assert.IsNotEmpty(UserSession.Sessions);
            Assert.IsTrue(UserSession.Sessions.Contains(lastName));
            Assert.IsTrue(result);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("TestUser")]
        public void Login_ShouldReturnFalse(string lastName)
        {
            // arrange
            //подготовка теста
            var service = new AuthService();
            // act
            // випольнения теста

            var result = service.Login(lastName);

            // етап проверки логики 
            // assert
            Assert.IsFalse(result);
        }
    }
}