using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Endereco
    {
        private string cep;
        private int numero;

        public Endereco(string cep, int numero)
        {
            ValidarCEP(cep);
            this.numero = numero;
        }

        public void ValidarCEP(string cep)
        {
            string pattern = @"^\d{5}-\d{3}$";

            if (Regex.IsMatch(cep, pattern))
                SetCEP(cep);
            else
                throw new Exception("CEP inválido.");
        }
        public void SetCEP(string cep)
        {
            this.cep = cep;
        }

        public void ImprimirEndereco()
        {
            Console.WriteLine($"CEP: {cep}");
            Console.WriteLine($"Número: {numero}");
        }
    }
}
