namespace Exercicios
{
    internal class Program
    {
        static void ListarExercicios()
        {
            Console.WriteLine("0 - Sair do programa.\n");
            Console.WriteLine("1 - Dado um array de inteiros determine qual número que mais se repete.\n");
            Console.WriteLine("2 - Crie dicionários de forma que o usuário possa selecionar entre vários idiomas para exibição dos textos do programa.\n");
            Console.WriteLine("3 - Listar exercícios novamente.\n");
        }
        static void Main(string[] args)
        {
            int option;
            bool validaOpcao;
            do
            {
                    ListarExercicios();
                do
                {
                    Console.WriteLine("\nDigite um exercício: ");
                    validaOpcao = int.TryParse(Console.ReadLine(), out option);
                } while (!validaOpcao);

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Saindo do programa...");
                        break;

                    case 1:
                        int[] vetor = Vetor.CriaVetor();
                        Dictionary<int, int> repeticoes = Dicionario.QuantificaRepeticoes(vetor);
                        int[] resultado = Dicionario.MaiorRepeticao(repeticoes);

                        Console.WriteLine($"\nO número que mais se repetiu foi o {resultado[0]}, com {resultado[1]} repetições!\n");
                        break;

                    case 2:
                        string[] traducaoSelecionada = Dicionario.LinguagemDeTexto();

                        foreach (var traducao in traducaoSelecionada)
                        {
                            Console.WriteLine($"{traducao} ");
                        }
                        Console.WriteLine("\n");
                        break;
                    case 3:
                        ListarExercicios();
                        break;

                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        break;
                }
            } while (option != 0);
        }
    }
}
