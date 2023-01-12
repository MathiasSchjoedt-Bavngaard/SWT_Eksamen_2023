using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;

namespace Test.Unit
{
    public class OutputTest
    
    {
        private StringWriter str;
        private Output uut;

        [SetUp]
        public void Setup()
        {
            str = new StringWriter();
            Console.SetOut(str);
            uut = new Output();
        }

        [Test]
        public void OutputLineCorrect()
        {
            uut.OutputLine("Test");

            Assert.That(str.ToString().Contains("Test"));

        }

    }
}