namespace AppTestNUnit
{
    public class Conta
    {
        #region Atribuitos
        private string cpf;
        private decimal saldo;
        private IValidadorCredito validadorCredito;
        #endregion Atribuitos

        public Conta(string _cpf, decimal _valor)
        {
            cpf = _cpf;
            saldo = _valor;
        }

        public decimal Saldo()
        {
            return saldo;
        }

        public void Depositar(decimal valor)
        {
            saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
            if(valor < 1)
                return false;

            if(saldo < valor)
                return false;

            saldo -= valor;
            return true;
        }

        //Injeção de Dependencia
        public void SetValidadorCredito(IValidadorCredito _validadorCredito)
        {
            validadorCredito = _validadorCredito;
        }

        public bool SolicitarEmprestimo(decimal valor)
        {
            bool resultadoValidadorCredito = validadorCredito.ValidarCredito(cpf, valor);

            if (resultadoValidadorCredito)
                saldo += valor;

            return resultadoValidadorCredito;
        }

        public decimal GetSaldo()
        {
            return saldo;
        }
    }
}
