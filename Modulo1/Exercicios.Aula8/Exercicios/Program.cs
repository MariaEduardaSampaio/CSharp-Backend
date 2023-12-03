namespace Exercicios
{
    internal class Program
    {
        static void ListarExercicios()
        {
            Console.WriteLine("0 - Sair do programa.");
            Console.WriteLine("1 - Implemente uma função que aceite um Array e um índice. A função deve retornar o elemento na posição especificada ou lançar uma exceção se o índice estiver fora do intervalo.");
            Console.WriteLine("2 - Crie uma função que aceite uma senha do usuário e aplique algumas regras de validação (comprimento mínimo, presença de números, etc.). Lance exceções para senhas que não atendem aos critérios.");
            Console.WriteLine("3 - Crie uma função que aceite uma string do usuário e tente convertê-la para um número inteiro. Se a conversão não for bem-sucedida, lance uma exceção.");
            Console.WriteLine("4 - Listar Exercícios.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tExercícios Aula 8\n");
            int option = 4;
            try
            {
                do
                {
                    switch(option)
                    {
                        case 0:
                            Console.WriteLine("Saindo do programa...");
                            break;
                        case 1:
                            int[] array = [4, 25, 30, 7, 8, 6, 23, 19, 21, 40];
                            Console.WriteLine("Entre com um índice: ");
                            int indice;
                            bool valido;
                            do
                            {
                                valido = int.TryParse(Console.ReadLine(), out indice);
                            } while (!valido);
                            int valor = Arrays.PegarValor(array, indice);
                            Console.WriteLine($"Valor do array no índice {indice} é {valor}.");
                            break;
                        case 2:
                            Console.WriteLine("Entre com uma senha:");
                            string senha = Console.ReadLine();
                            if (Senha.ValidaSenha(senha))
                                Console.WriteLine($"Senha {senha} é válida!");
                            break;
                        case 3:
                            Console.WriteLine("Entre com uma string para convertê-la para int: ");
                            string str = Console.ReadLine();
                            int numero = Conversao.StringParaNumero(str);
                            Console.WriteLine($"A string {str} convertida para número é {numero}!");
                            break;
                        case 4:
                            ListarExercicios();
                            break;
                    }
                    bool opcaoValida;
                    do
                    {
                        Console.WriteLine("Entre com um comando: ");
                        opcaoValida = int.TryParse(Console.ReadLine(), out option);
                    } while (!opcaoValida);
                } while (option != 0);
            } catch (SenhaMenorQue8Caracteres e)
            {
                Console.WriteLine($"Senha inválida: {e}");
            } catch( Exception e )
            {
                Console.WriteLine($"Ocorreu um erro: {e}");
            }
        }
    }
}
