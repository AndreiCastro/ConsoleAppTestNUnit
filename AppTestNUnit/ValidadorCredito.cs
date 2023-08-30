using System;
using System.Collections.Generic;
using System.Text;

namespace AppTestNUnit
{
    internal class ValidadorCredito : IValidadorCredito
    {
        public bool ValidarCredito(string cpf, decimal valor)
        {
            bool statusSerasa = VerificarStatusSerasa(cpf);
            bool statusSPC = VerificarStatusSPC(cpf);

            return (statusSerasa && statusSPC);
        }

        public bool VerificarStatusSerasa(string cpf)
        {
            //Chama o WebService do Serasa
            return true;
        }

        public bool VerificarStatusSPC(string cpf)
        {
            //Chama o WebService do SPC
            return true;
        }
    }
}
