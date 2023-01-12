

namespace Test.Intergration
{
    public class IntergrationTests
    {

        IGodkendLån _controllerClass2;
        Class1 _class1;


        [SetUp]
        public void Setup()
        {
            _class1 = new Class1();
            _controllerClass2 = new GodkendLån();
        }

        [Test]
        public void ClassInController()
        {
            
            Assert.That(_controllerClass2.Method2(_class1.Method1(1)), Is.EqualTo(4));
        }

    }
}
