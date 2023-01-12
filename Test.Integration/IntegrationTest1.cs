

namespace Test.Intergration
{
    public class IntergrationTests
    {

        IGodkendLaan _controllerClass2;
        Class1 _class1;


        [SetUp]
        public void Setup()
        {
            _class1 = new Class1();
            _controllerClass2 = new GodkendLaan();
        }

        [Test]
        public void ClassInController()
        {
            
            Assert.That(4, Is.EqualTo(4));
        }

    }
}
