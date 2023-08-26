namespace AppTestNUnit
{
    public class Conta
    {
        #region Atribuitos
        private string cpf;
        private decimal saldo;
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

        public bool Sacar(decimal valor)
        {
            if(saldo < valor)
                return false;

            saldo -= valor;
            return true;
        }
    }
}
