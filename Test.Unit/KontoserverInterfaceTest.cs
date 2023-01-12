using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;

namespace Test.Unit
{
    public class KontoserverInterfaceTest
    {
        private KontoserverInterface _uut;
        
        [SetUp]
        public void Setup()
        {

            _uut = new KontoserverInterface();
        }

        [TestCase(10000)]
        [TestCase(50000)]
        [TestCase(100000)]
        public void BogFoerBeloeb_overNul(double beloeb)
        {
            Assert.That(_uut.BogFoerBeloeb(beloeb, 1), Is.EqualTo(true));
        }
        
        [TestCase(0)]
        [TestCase(-10000)]
        public void BogFoerBeloeb_ikkeoverNul(double beloeb)
        {
            Assert.That(_uut.BogFoerBeloeb(beloeb, 1), Is.EqualTo(false));
        }


    }
}