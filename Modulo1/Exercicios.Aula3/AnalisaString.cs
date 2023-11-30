using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal class AnalisaString
    {
        public static void AnalisarString(string frase)
        {
            int contadorMinusculas = 0;
            int contadorMaiusculas = 0;
            int contadorPalavras = 1;

            foreach (char caractere in frase)
            {
                if (char.IsLower(caractere))
                    contadorMinusculas++;
                else if (char.IsUpper(caractere))
                    contadorMaiusculas++;
                else if (char.IsWhiteSpace(caractere))
                    contadorPalavras++;
            }

            int contadorLetras = contadorMinusculas + contadorMaiusculas;

            Console.WriteLine($"Quantidade de palavras: {contadorPalavras}");
            Console.WriteLine($"Quantidade de letras: {contadorLetras}");
            Console.WriteLine($"Quantidade de maiúsculas: {contadorMaiusculas}");
            Console.WriteLine($"Quantidade de minúsculas: {contadorMinusculas}");
        }
    }
}
