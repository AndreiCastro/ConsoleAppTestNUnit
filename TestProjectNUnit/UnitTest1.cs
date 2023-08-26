using NUnit.Framework;
using AppTestNUnit;

namespace TestProjectNUnit
{
    /*Com o TestFixture informa que a classe será uma classe de TESTE*/
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*Sempre que for realizar um teste, tem que add o [Test] para que acontece o teste*/
        [Test]
        public void TesteSacar()
        {
            //Arrange
            var conta = new Conta("0009", 200);

            //Act (Action)
            bool retornoConta = conta.Sacar(300);

            //Assert
            Assert.IsFalse(retornoConta);
        }
    }
}