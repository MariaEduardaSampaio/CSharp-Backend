using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal static class Dicionario
    {
        internal static int[] MaiorRepeticao(Dictionary<int, int> numerosPorRepeticoes)
        {
            int chaveMaiorRepeticao = 0;
            int valorMaiorRepeticao = 0;

            foreach(var (numero, repeticoes) in numerosPorRepeticoes)
            {
                if (repeticoes > valorMaiorRepeticao)
                {
                    chaveMaiorRepeticao = numero;
                    valorMaiorRepeticao = repeticoes;
                }
                else
                    continue;
            }
            int[] resultado = [ chaveMaiorRepeticao, valorMaiorRepeticao ];
            return resultado;
        }

        internal static Dictionary<int, int> QuantificaRepeticoes(int[] arrNumeros)
        {
            Dictionary<int, int> Repeticoes = new Dictionary<int, int>();

            foreach(int numero in arrNumeros)
            {
                if (Repeticoes.ContainsKey(numero))
                {
                    Repeticoes[numero]++;
                } else
                {
                    Repeticoes.Add(numero, 1);
                }
            }
            return Repeticoes;
        }

        internal static string[] LinguagemDeTexto()
        {
            Dictionary<string, string[]> traducao = new Dictionary<string, string[]>
            {
                { "PT", new string[] { "Olá", "Mundo" } },
                { "EN", new string[] { "Hello", "World" } },
                { "FR", new string[] { "Bonjour", "Monde" } },
                { "ES", new string[] { "Hola", "Mundo" } },
                { "DE", new string[] { "Hallo", "Welt" } },
            }; 
            bool validaOpcao;
            string opcao;

            foreach(var (lingua, traducoes) in traducao)
            {
                Console.Write($"{lingua} ");
            }

            do
            {
                Console.WriteLine("Entre com uma opção válida de língua:");
                opcao = Console.ReadLine();
                validaOpcao = traducao.ContainsKey(opcao.ToUpper());
            } while (!validaOpcao);

            return traducao[opcao.ToUpper()];
        }
    }
}
