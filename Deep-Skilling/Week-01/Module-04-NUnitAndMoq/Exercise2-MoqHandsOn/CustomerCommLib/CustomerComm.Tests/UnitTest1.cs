using CustomerCommLib;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace CustomerComm.Tests
{
    public class Tests
    {
        private Mock<ICustomerComm> mock;
        private CustomerCommLib.CustomerComm customerComm;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<ICustomerComm>();
            customerComm = new CustomerCommLib.CustomerComm(mock.Object);
        }

        [Test]
        public void TestSendMail()
        {
            mock.Setup(x => x.SendMail()).Returns("Mail Sent");

            string result = customerComm.SendMail();

            ClassicAssert.AreEqual("Mail Sent", result);
        }

        [Test]
        public void TestSendSMS()
        {
            mock.Setup(x => x.SendSMS()).Returns("SMS Sent");

            string result = customerComm.SendSMS();

            ClassicAssert.AreEqual("SMS Sent", result);
        }
    }
}