

namespace Test.Intergration
{
    public class IntergrationTests
    {

        IGodkendLaan _controllerClass2;
       


        [SetUp]
        public void Setup()
        {
            
            _controllerClass2 = new GodkendLaan();
        }

        [Test]
        public void ClassInController()
        {
            
            Assert.That(4, Is.EqualTo(4));
        }

    }
}
