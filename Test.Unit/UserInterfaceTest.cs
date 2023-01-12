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

        [TestCase(900, 1234)]
        [TestCase(20000, 12345)]
        [TestCase(3000, 123456)]
        [TestCase(100000, 1234567)]
        public void FriGivLaan_overNul(double beloeb, int kontonummer)
        {
            _godkendLaan.FrigivLaan(beloeb, kontonummer).Returns(true);
            Assert.That(_uut.FrigivLaan(beloeb, kontonummer), Is.EqualTo(true));
        }
        
        [Test]
        public void _godkendLaan_Calls_ansoeg()
        {
            _uut.Ansoeg(10000, 12, 100000, 10000);
            _godkendLaan.Received(1).Ansoeg(10000, 12, 100000, 10000);
        }

        [Test]
        public void _godkendLaan_Calls_frigivLaan()
        {
            _uut.FrigivLaan(10000, 1234);
            _godkendLaan.Received(1).FrigivLaan(10000, 1234);
        }

        [Test]
        public void Properties_Set_Get()
        {
            _uut._godkendLaan = _godkendLaan;
            _uut._display = _display;
            Assert.That(_uut._godkendLaan, Is.EqualTo(_godkendLaan));
            Assert.That(_uut._display, Is.EqualTo(_display));
        }


    }
}