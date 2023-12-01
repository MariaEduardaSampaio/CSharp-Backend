using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal class SenhaMenorQue8Caracteres(string message) : Exception(message)
    {
    }
    internal class SenhaNula(string message) : Exception(message)
    {
    }
    internal class SenhaNaoContemNumero(string message) : Exception(message)
    {
    }
    internal class SenhaNaoContemCaractereEspecial(string message) : Exception(message)
    {
    }
}
