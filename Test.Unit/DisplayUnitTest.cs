using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;

namespace Test.Unit
{
    public class DisplayUnitTest
    {
        private Display _uut;
        IOutput _output;


        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _uut = new Display(_output);
        }
        [Test]
        public  void Constructortest()
        {
            _uut = new Display();
            
            Assert.That(_uut, Is.Not.Null);
        }

        [TestCase(100)]
        [TestCase(253.93)]
        [TestCase(482.80)]
        [TestCase(1110.21)]
        [TestCase(0)]
        [TestCase(-100)]
        public void VisYdelseForStor(double ydelse)
        {
            _uut.VisYdelseForStor(ydelse);
            _output.Received(1).OutputLine($"Ydelsen: {ydelse}  er for stor");
        }

        [TestCase(100)]
        [TestCase(253.93)]
        [TestCase(482.80)]
        [TestCase(1110.21)]
        [TestCase(0)]
        [TestCase(-100)]
        public void VisLaanGodkendt(double ydelse)
        {
            _uut.VisLaanGodkendt(ydelse);
            _output.Received(1).OutputLine($"Laan Godkendt med Ydelse: {ydelse} ");
        }

        [TestCase(0.05)]
        [TestCase(0.10)]
        [TestCase(0.015)]
        [TestCase(0.005)]
        [TestCase(0)]
        [TestCase(-0.05)]
        public void OpdaterLaaneRente(double rente)
        {
            _uut.OpdaterLaaneRente(rente);
            _output.Received(1).OutputLine($"Laan rente er nu: {rente*100} % ");
        }
        
    }
}