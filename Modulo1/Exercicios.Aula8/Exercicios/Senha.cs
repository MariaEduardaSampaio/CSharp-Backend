using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal class Senha
    {
        internal static bool ValidaSenha(string senha)
        {
            if (senha == null)
                throw new SenhaNula("Senha não pode ser nula.");
            if (senha.Length < 8)
                throw new SenhaMenorQue8Caracteres("Senha menor que 8 dígitos.");
            if(!senha.Any(char.IsDigit))
                throw new SenhaNaoContemNumero("Senha deve conter ao menos um número.");
            if (!senha.Any(c => !char.IsLetterOrDigit(c)))
                throw new SenhaNaoContemCaractereEspecial("Senha deve conter ao menos um caractere especial.");
            return true;
        }
    }
}
