namespace Exercicios
{
    internal class Program
    {
        static void TrocaNumeros(ref int numero1, ref int numero2)
        {
            int aux = numero1;
            numero1 = numero2;
            numero2 = aux;
        }

        static bool Divisao(decimal numerador, decimal divisor, out decimal divisao)
        {
            divisao = -1;
            
            if (divisor == 0.0m)
                return false;
            else 
            {
                divisao = numerador / divisor;
                return true;
            }
        }

        static void RecebeInteiro(out int numero)
        {
            bool deuCerto;
            do
            {
                Console.WriteLine("Entre com um número inteiro: ");
                deuCerto = int.TryParse(Console.ReadLine(), out numero);
            } while (!deuCerto);
        }

        static void RecebeDecimal(out decimal numero)
        {
            bool deuCerto;
            do
            {
                Console.WriteLine("Entre com um número: ");
                deuCerto = decimal.TryParse(Console.ReadLine(), out numero);
            } while (!deuCerto);
        }
        static void Exercicio1()
        {
            RecebeInteiro(out int numero1);
            RecebeInteiro(out int numero2);
            Console.WriteLine($"Os valores antes da troca são {numero1} e {numero2}");
            TrocaNumeros(ref numero1, ref numero2);
            Console.WriteLine($"Os valores depois da troca são {numero1} e {numero2}");
        }

        static void Exercicio2()
        {
            RecebeDecimal(out decimal numerador);
            RecebeDecimal(out decimal divisor);
            if (Divisao(numerador, divisor, out decimal divisao))
                Console.WriteLine($"O resultado da divisão entre {numerador} e {divisor} é {divisao:F2}!");
            else
                Console.WriteLine("A divisão não é válida pois divisor é 0!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n1 - Escreva uma função que recebe dois números inteiros e os troca utilizando parâmetros ref. Em seguida, crie um programa principal que chama essa função, exibindo os valores antes e depois da troca.\n");
            Exercicio1();

            Console.WriteLine("\n2 - Implemente uma função que calcula a divisão e o resto de dois números inteiros. Utilize parâmetros out para retornar os resultados. Crie um programa principal que chama essa função, passa os números e exibe os resultados.\n");
            Exercicio2();
        }
    }
}
