using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator = null!;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public void TestAddition()
        {
            NUnit.Framework.Assert.That(calculator.Add(10, 20), Is.EqualTo(30));
        }

        [Test]
        public void TestSubtraction()
        {
            NUnit.Framework.Assert.That(calculator.Subtract(20, 10), Is.EqualTo(10));
        }

        [Test]
        public void TestMultiplication()
        {
            NUnit.Framework.Assert.That(calculator.Multiply(20, 10), Is.EqualTo(200));
        }

        [Test]
        public void TestDivision()
        {
            NUnit.Framework.Assert.That(calculator.Divide(20, 10), Is.EqualTo(2));
        }
    }
}