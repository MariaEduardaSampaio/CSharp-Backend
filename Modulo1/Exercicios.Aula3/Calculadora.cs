using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal class Calculadora
    {
        public static string Soma(decimal n1, decimal n2)
        {
            return ($"Soma = {n1 + n2}");
        }
        public static string Divisao(decimal n1, decimal n2)
        {
            if (n2 == 0)
                return "Divisão por zero é impossível";
            else
                return ($"Divisão = {n1 / n2}");
        }
        public static string Subtracao(decimal n1, decimal n2)
        {
            return ($"Subtração = {n1 - n2}");
        }
        public static string Multiplicacao(decimal n1, decimal n2)
        {
            return ($"Multiplicação = {n1 * n2}");
        }
    }
}
