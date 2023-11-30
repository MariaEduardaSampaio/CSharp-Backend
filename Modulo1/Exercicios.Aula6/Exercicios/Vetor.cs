using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal static class Vetor
    {
        internal static int[] CriaVetor()
        {
            bool validaOpcao;
            int tamanhoVetor;
            do
            {
               Console.WriteLine("Entre com o tamanho do vetor: ");
               validaOpcao = int.TryParse(Console.ReadLine(), out tamanhoVetor);
            } while (!validaOpcao);

            int[] vetor = new int[tamanhoVetor];

            for(int i = 0; i < vetor.Length; i++)
            {
                do
                {
                   Console.WriteLine($"Entre com o valor da {i + 1}a posição: ");
                   validaOpcao = int.TryParse(Console.ReadLine(), out vetor[i]);
                } while (!validaOpcao);
            }

            return vetor;
        }
    }
}
