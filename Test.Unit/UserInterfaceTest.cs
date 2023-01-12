using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;

namespace Test.Unit
{
    public class UserInterfaceTest
    {
        private UserInterface _uut;
        private IGodkendLaan _godkendLaan;
        private IDisplay _display;

        [SetUp]
        public void Setup()
        {
            _godkendLaan = Substitute.For<IGodkendLaan>();
            _display = Substitute.For<IDisplay>();
            _uut = new UserInterface(_godkendLaan, _display);
        }



        [TestCase(10000, 12, 100000, 10000)]
        [TestCase(50000, 12, 100000, 10000)]
        [TestCase(100000, 12, 100000, 10000)]
        public void Ansoeg_overNul(double beloeb, int varighed, double indtaegt, double udgifter)
        {
            _godkendLaan.Ansoeg(beloeb, varighed, indtaegt, udgifter).Returns(true);
            Assert.That(_uut.Ansoeg(beloeb, varighed, indtaegt, udgifter), Is.EqualTo(true));
        }


    }
}