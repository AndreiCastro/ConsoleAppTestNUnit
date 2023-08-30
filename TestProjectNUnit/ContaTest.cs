using NUnit.Framework;
using AppTestNUnit;
using Microsoft.VisualBasic;

namespace TestProjectNUnit
{
    /*Com o atributo TestFixture informa que a classe ser� uma classe de TESTE*/
    [TestFixture]
    public class ContaTest
    {
        Conta conta;
        
        #region SetUp TearDown
        /*Atributo [SetUp] no metodo, sempre ser� executado antes de cada metodo que tenha o 
         atributo [Test] da classe de testes.
        
        J� o atributo [TearDown] sempre ser� executado ao final de cada metodo que tenha o 
        atributo [Test] da classe de testes*/
        [SetUp]
        public void Setup()
        {
            conta = new Conta("0001", 300);
        }

        [TearDown]
        public void TearDown()
        {
            //executara ao final de cada teste
        }
        #endregion SetUp TearDown

        #region OneTime
        /*Os atributos [OneTimeSetUp] e [OneTimeTearDown] seram executado somente
         uma vez ap�s iniciar e finalizar a classe de testes respectivamente,*/
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //executara ao inicio de todos os metodos da classe
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //executara ao final de todos os metodos da classe
        }
        #endregion OneTime

        /*Sempre que for realizar um teste, tem que add o atributo [Test] para que acontece o teste
          
        [Category] serve para agrupar os testes
        PS: No Test Explorer procure as op��es que tenha o group by, nele clique em Traits assim 
        ser�o agrupados pelas categorias que voc� add*/
        [Test]
        [Category("Principal")]
        public void Sacar()
        {
            //Arrange
            //var conta = new Conta("0009", 200);

            //Act (Action)
            bool retornoConta = conta.Sacar(300);
            //Assert
            Assert.IsTrue(retornoConta);
        }

        [Test]
        [Category("Secundario")]
        public void SacarSemSaldo()
        {
            //Arrange
            conta = new Conta("0009", 0);

            //Act (Action)
            bool retornoConta = conta.Sacar(100);
            //Assert
            Assert.IsFalse(retornoConta);
        }

        [Test]
        [Category("Secundario")]
        public void SacarValorZerado()
        {
            //Act (Action)
            bool retornoConta = conta.Sacar(0);
            //Assert
            Assert.IsFalse(retornoConta);
        }

        #region Ignore
        /*O Atributo Ignore serve pra ignorar o teste, e a mensagem � exibida no Test Explorer tbm 
         pode ser usado esse atributo no come�o da classe, ai ira ignorar todos os teste da class*/
        [Test]
        [Ignore("Este metodo est� sendo ignorado para testes")]
        [Category("Ignore")]
        public void IgnorarTeste()
        {
            //Arrange
            //var conta = new Conta("0001", 200);

            //Act
            bool retornoConta = conta.Sacar(0);
            //Assert
            Assert.IsTrue(retornoConta);
        }
        #endregion Ignore

        #region TestCase
        /*[TestCase] Serve para definir os atributos que ir� passar para teste.
         Pode declarar varias vezes e passar mais de um atributo. 
         Nos testes abaixo fiz todos retornarem positivos, pois o saque n�o pode ser zerado, 
         e o valor deve ser abaixo de 300 (defi esse valor no SetUp)
        */
        [Test]
        [TestCase(0, false)]
        [TestCase(100, true)]
        [TestCase(200, true)]
        [TestCase(400, false)]
        [Category("Teste Case")]
        public void TestCase(int valor, bool resultado)
        {
            //Act
            bool retornoConta = conta.Sacar(valor);
            //Assert
            Assert.IsTrue(retornoConta == resultado);
        }
        #endregion TestCase

        #region Assert
        /*Metodos Assert
        .Istrue() -               Verifica se � true
        .IsFalse() -              Verifica se � false
        .IsEmpty() -              Verifica se uma string est� vazia
        .IsNotEmpty() -           Verifica se uma string N�O est� vazia
        .IsNull() -               Verifica se o obejto � null
        .IsNotNull() -            Verifica se uma objeto N�O � null
        .Greater(a, b) -          Verifica se valor a � maior que b
        .GreaterOrEqual(a, b) -   Verifica se valor a � maior ou igual b
        .Ignore() -               Ignora o teste tamb�m 
         */
        #endregion Assert

        #region Atributos
        /*
        [Test]
        [SetUp]
        [TearDown]
        [SetUpOneTime]
        [TearDownOneTime]
        [Category("Descri��o para Categoria")]
        [Ignore("Ignore Teste")]
        [TestCase(10)] ou [TestCase(10,50,60)] ou [TestCase(10,"string",bool)]
        [TimeOut] - Serve para verificar timeout do teste
         */
        #endregion Atributos
    }
}