using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;
using System.Reflection.Metadata;

namespace Test.Unit
{
    public class BeregnYdelserTest
    {
        private BeregnYdelser _uut;
        private IDisplay _display;
        private IRenteserverInterface _renteserverInterface;
        private NyRenteEventArgs _recivedNyRenteEvent;
        
        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _renteserverInterface = Substitute.For<IRenteserverInterface>();
            _uut = new BeregnYdelser(_renteserverInterface, _display);



        }

        #region ConstructorTests
        //constructor Tests
        [Test]
        public void DefaultConstructor_RenteserverInterfaceNotNull()
        {
            _uut = new BeregnYdelser();
            Assert.That(_uut._renteserver, Is.Not.Null);
        }
        [Test]
        public void DefaultConstructor_DisplayNotNull()
        {
            _uut = new BeregnYdelser();
            Assert.That(_uut._display, Is.Not.Null);
        }
        [Test]
        public void DisplayOnlyConstrucktor()
        {
            _uut = new BeregnYdelser(_display);
            Assert.That(_uut._renteserver, Is.TypeOf<RenteserverInterface>());
            Assert.That(_uut._display, Is.Not.Null);
        }
        [Test]
        public void RenteserverInterfaceOnlyConstrucktor()
        {
            _uut = new BeregnYdelser(_renteserverInterface);
            Assert.That(_uut._display, Is.TypeOf<Display>());
            Assert.That(_uut._renteserver, Is.Not.Null);
        }
        #endregion

        
        [TestCase(0.05)]
        [TestCase(0.10)]
        [TestCase(0.005)]
        [TestCase(0)]
        [TestCase(-0.05)]
        public void RecivedEvent_WithCorrect_Rente(double rente)
        {
            _renteserverInterface.NyRente += Raise.EventWith(new NyRenteEventArgs() { NyRente = rente });
            Assert.That(_uut.AktuelRente, Is.EqualTo(rente));
        }



        [TestCase(1)]
        [TestCase(2)]
        [TestCase(12)]
        [TestCase(119)]
        [TestCase(120)]
        public void BeregnYdelse_VarighedValid(int Varighed)
        {
            double MD = double.MaxValue;
            double beloeb = 10000;

            Assert.That(_uut.BeregnYdelse(beloeb, Varighed) , Is.Not.EqualTo(MD));
        }

        [Test]
        public void BeregnYdelse_Rente_0()
        {
            _renteserverInterface.NyRente += Raise.EventWith(new NyRenteEventArgs() { NyRente = 0 });
            Assert.That(_uut.BeregnYdelse(100, 10), Is.EqualTo(10));
        }

        [TestCase(0.05)]
        [TestCase(0.10)]
        [TestCase(0.005)]
        [TestCase(-0.05)]
        public void BeregnYdelse_DifferentRente_not_0(double Rente)
        {
            _renteserverInterface.NyRente += Raise.EventWith(new NyRenteEventArgs() { NyRente = Rente });
            Assert.That(_uut.BeregnYdelse(100, 10), Is.EqualTo(100 * Rente / (1 - Math.Pow(1 + Rente, -10))).Within(0.01));
        }


        [TestCase(10000, 0.015,60, 253.93)]
        [TestCase(50000,0.0025, 120, 482.80)]
        [TestCase(100000, 0.005,120, 1110.21)]
        public void BeregnYdelse_fromSamples(double laan, double rente, int maaneder, double ydelse)
        {
            _renteserverInterface.NyRente += Raise.EventWith(new NyRenteEventArgs() { NyRente = rente });
            double beregnetydelse = _uut.BeregnYdelse(laan, maaneder);
            Assert.That(beregnetydelse, Is.EqualTo(ydelse).Within(0.01));
           
        }
        
















    }
}