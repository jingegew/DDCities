using DDCities.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDCities.Tests.Business
{
    [TestClass]
    public class NotificationServiceTests
    {
        [TestMethod]
        public void SendEmailTest()
        {
            var service = new NotificationService();
            service.SendMail();
        }
    }
}