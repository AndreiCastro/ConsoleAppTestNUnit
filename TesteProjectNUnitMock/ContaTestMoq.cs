using NUnit.Framework;
using Moq;
using AppTestNUnit;

namespace TesteProjectNUnitMock
{
    [TestFixture]
    public class ContaTestMoq
    {
        Conta conta;
        [SetUp]
        public void Setup()
        {
            conta = new Conta("0001", 100);
        }

        [Test]
        [Category("Principal")]
        public void TesteSolicitarEmprestimo()
        {
            /* mock é a classe do Framework Moq, responsavel por criar os metodos da 
             classe ou interface passados <>() */
            var mock = new Mock<IValidadorCredito>();

            //Metodo Setup é responsavel por como o Mock deve se comportar

            /* 
             mock.Setup(x => x.ValidarCredito("0001", 5000)).Returns(true);

             - Desta forma se passar 1º parametro != "0001" ou 2º != 5000 o teste irá falhar
             pois estou dizendo que os parametros devem ser esses.
             - No Moq existem o Matching Arguments, que digo se qualquer valor for passado o retorno
             do mock será positivo, só precisa ter os valores do parametros e o msm tipo */
            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);
            
            /*
             mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.Is<decimal>(i => i < 5000))).Returns(true);
             Somente ira passar funcionar se o valor for < que 5000 */

            conta.SetValidadorCredito(mock.Object);
            conta.SolicitarEmprestimo(5000);

            Assert.IsTrue(conta.GetSaldo() == 5100);
        }
    }
}