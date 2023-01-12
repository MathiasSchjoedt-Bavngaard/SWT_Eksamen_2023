using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;

namespace Test.Unit;

public class GodkendLaanTest
{
    private IKontoserverInterface _kontoserver;
    private IBeregnYdelser _beregnYdelser;
    private IDisplay _display;
    private IPrinter _printer;
    private GodkendLaan _uut;

    [SetUp]
    public void Setup()
    {
        _display = Substitute.For<IDisplay>();
        _printer = Substitute.For<IPrinter>();
        _kontoserver = Substitute.For<IKontoserverInterface>();
        _beregnYdelser = Substitute.For<IBeregnYdelser>();
        _uut = new GodkendLaan(_printer, _display, _kontoserver, _beregnYdelser);
    }

    [Test]
    public void DefaultConstructor()
    {
        _uut = new GodkendLaan();
        Assert.That(_uut, Is.Not.Null);
    }

    [Test]
    public void Properties_Set_Get()
    {
        _uut = new GodkendLaan();
        _uut._beregnYdelser = _beregnYdelser;
        _uut._display = _display;
        _uut._kontoserver = _kontoserver;
        _uut._printer = _printer;

        Assert.That(_uut._beregnYdelser, Is.EqualTo(_beregnYdelser));
        Assert.That(_uut._display, Is.EqualTo(_display));
        Assert.That(_uut._kontoserver, Is.EqualTo(_kontoserver));
        Assert.That(_uut._printer, Is.EqualTo(_printer));

    }
    
    [TestCase(10000, 0.015, 60, 253.93)]
    [TestCase(50000, 0.0025, 120, 482.80)]
    [TestCase(100000, 0.005, 120, 1110.21)]
    public void Ansoeg_returns_true(double beloeb, double rente, int varighed, double ydelse)
    {
        _uut._beregnYdelser.AktuelRente.Returns(rente);
        _uut._beregnYdelser.BeregnYdelse(beloeb, varighed).Returns(ydelse);
        Assert.That(_uut.Ansoeg(beloeb,varighed,50000,35400), Is.True);
    }

    [TestCase(1000)]
    [TestCase(700)]
    [TestCase(600)]
    [TestCase(501)]
    public void Ansoeg_YdelseForStor_VisYdelseForStor(double ydelse)
    {
        _beregnYdelser.BeregnYdelse(10000, 12).Returns(ydelse);
        _uut.Ansoeg(10000, 12, 10000, 5000);
        _display.Received(1).VisYdelseForStor(ydelse);
    }

    
    [TestCase(900)]
    [TestCase(200)]
    [TestCase(300)]
    [TestCase(1)]
    public void Ansoeg_YdelseOk_VisLaanGodkendt(double ydelse)
    {
        _beregnYdelser.BeregnYdelse(10000, 12).Returns(ydelse);
        _uut.Ansoeg(10000, 12, 10000, 1000);
        _display.Received(1).VisLaanGodkendt( ydelse);
    }
    
    

    [TestCase(900, 1234)]
    [TestCase(20000,12345)]
    [TestCase(3000,123456)]
    [TestCase(100000, 1234567)]
    public void FrigivLaan_BogFoerBeloeb_True(double beloeb, int kontonummer)
    {
        _kontoserver.BogFoerBeloeb(beloeb, kontonummer).Returns(true);
        Assert.That(_uut.FrigivLaan(beloeb, kontonummer), Is.True);
    }





}