using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal class Conversao
    {
        internal static int StringParaNumero(string str)
        {
            int numero;
            if (!int.TryParse(str, out numero))
                throw new ArgumentException("Não é possível converter esta string para número.");
            else
                return numero;
        }
    }
}
