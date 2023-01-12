using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;

namespace Test.Unit
{
    public class PrinterTest
    {
        private Printer _uut;
        private IOutput _output;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _uut = new Printer();
            _uut.output = _output;
        }

        [TestCase(10000, 50, 254.93)]
        [TestCase(50000, 120, 482.80)]
        [TestCase(100000, 120, 1110.21)]
        public void UdskrivLaaneDokument(double beloeb, int varighed, double ydelse)
        {
            _uut.UdskrivLaaneDokument(beloeb, varighed, ydelse);
            _output.Received(1).OutputLine($"Laan Dokument");
            _output.Received(1).OutputLine($"Beloeb: {beloeb}");
            _output.Received(1).OutputLine($"Varighed: {varighed}");
            _output.Received(1).OutputLine($"Ydelse: {ydelse}");
        }

        [TestCase(10000, 50, 254.93)]
        [TestCase(50000, 120, 482.80)]
        [TestCase(100000, 120, 1110.21)]
        public void BlackBoxTesting_maybe_UdskrivLaaneDokument(double beloeb, int varighed, double ydelse)
        {
            _uut.UdskrivLaaneDokument(beloeb, varighed, ydelse);
            _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("Laan Dokument")));
            _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains($"Beloeb: {beloeb}")));
            _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains($"Varighed: {varighed}")));
            _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains($"Ydelse: {ydelse}")));
        }



    }
}