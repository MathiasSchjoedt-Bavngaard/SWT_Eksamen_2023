using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;

namespace Test.Unit
{
    public class RenteserverInterfaceTest
    {
        private RenteserverInterface _uut;
        private NyRenteEventArgs _recivedNyRenteEvent;
        
        [SetUp]
        public void Setup()
        {
            _recivedNyRenteEvent = null;
            _uut = new RenteserverInterface();
            _uut.NyRente +=
                (o, args) =>
                {
                    _recivedNyRenteEvent = args;
                };

        }

        
        [TestCase(0.05)]
        [TestCase(0.10)]
        [TestCase(0.005)]
        [TestCase(0)]
        [TestCase(-0.05)]
        public void SetAndGetRente(double rente)
        {
            _uut.SetRente(rente);
            Assert.That(_uut.Rente, Is.EqualTo(rente));
        }
        
       
        [TestCase(0.05)]
        [TestCase(0.10)]
        [TestCase(0.005)]
        [TestCase(0)]
        [TestCase(-0.05)]
        public void RecivedEvent(double rente)
        {
            _uut.SetRente(rente);
            Assert.That(_recivedNyRenteEvent, Is.Not.Null);
        }
        
        [TestCase(0.05)]
        [TestCase(0.10)]
        [TestCase(0.005)]
        [TestCase(0)]
        [TestCase(-0.05)]
        public void RecivedEvent_WithCorrect_Rente(double rente)
        {
            _uut.SetRente(rente);
            Assert.That(_recivedNyRenteEvent.NyRente, Is.EqualTo(rente));
        }

        [Test]
        public void DidNotRecivedEvent_whenSameRente_1_5()
        {
            _uut.SetRente(0.015);
            Assert.That(_recivedNyRenteEvent, Is.Null);
        }















    }
}