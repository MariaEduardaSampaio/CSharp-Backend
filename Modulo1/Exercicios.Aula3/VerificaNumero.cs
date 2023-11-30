using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public static class VerificaNumero
    {
        public static bool EhPar(int numero)
        {
            return (numero % 2 == 0);
        }

        public static bool AprovadoEmDisciplina(float nota)
        {
            return (nota >= 7);
        }

        public static void ConversaoDeTipos(decimal numero)
        {
            int numeroInteiro = Decimal.ToInt32(numero);
            double numeroDouble = Decimal.ToDouble(numero);
            float numeroFloat = Decimal.ToSingle(numero);

            Console.WriteLine($"O número {numero} como inteiro é {numeroInteiro}, " +
                $"como double é {numeroDouble} e como float é {numeroFloat}.");
        }

        public static decimal CalculaAreaCirculo(decimal raio)
        {
            return 3.1415926m * raio * raio;
        }
    }
}
