namespace Exercicios
{
    internal class Program
    {
        public static void ListarExercicios()
        {
            Console.WriteLine("1. Crie um array de números inteiros e exiba todos os elementos na tela.\n ");
            Console.WriteLine("2. Crie um projeto console, construa uma array de numeros ou string, adicione a ele dados e descubra os principais métodos e propriedade do Array em C#.\n");
            Console.WriteLine("3. Implemente uma função que busca por um elemento em um array/lista e retorna a posição ou -1 se não encontrado.\n");
            Console.WriteLine("4. Faça um algoritmo que construa dois vetores A e B de 10 elementos e, a partir deles, crie um vetor C, composto pela somados elementos, sendo: \nC[1] = A[1] + B[9], C[2] = A[2] + B[9], C[3] = A[3] + B[8], etc.\n");
            Console.WriteLine("5. Crie um programa que peça 10 números inteiros e apresente a média, a soma e o menor.\n");
            Console.WriteLine("6. Some os números de 1 a 100 a imprima o valor.\n");
            Console.WriteLine("7. Faça um algoritmo que leia números até o usuário digitar 0, após finalizar, mostre quantos números lidos, a soma e quantos são pares.\n");
            Console.WriteLine("8. Lista os exercícios novamente.\n");
        }
        public static void AnalisarArrayCSharp()
        {
            int[] vetor2 = new int[3];
            Console.WriteLine("Alguns métodos e propriedades principais de um Array em C#: ");
            Console.WriteLine("\rPropriedades\n");
            Console.WriteLine("meuArray.Length = retorna o tamanho do array.");
            Console.WriteLine("meuArray.Rank = retorna a dimensão do array.");

            Console.WriteLine("\rMétodos\n");
            Console.WriteLine("meuArray.GetValue(int index) = retorna o valor no índice index especificado.");
            Console.WriteLine("meuArray.SetValue(value, index) = atribui valor em indíce especificado.");
            Console.WriteLine("meuArray.All(function condicao) = se todos os elementos atendem a uma certa condição" +
                "retorna true, se não retorna false.");
            Console.WriteLine("meuArray.Average() = retorna a média dos elementos do array.");
            Console.WriteLine("meuArray.Sum() = retorna a soma dos elementos do array.");
            Console.WriteLine("meuArray.Max() = retorna o valor máximo do array.");
            Console.WriteLine("meuArray.Min() = retorna o valor mínimo do array.");
            Console.WriteLine("meuArray.Prepend() = adiciona um elemento ao início do array.");
            Console.WriteLine("meuArray.Where(function condicao) = retorna todos os elementos que atendem à condição.");
            Console.WriteLine("meuArray.Contains() = retorna true se array contém o valor passado e falso caso contrário.");
            Console.WriteLine("meuArray.FirstOrDefault(function condicao) = retorna o primeiro elemento que atende à condição" +
                "ou retorna o valor padrão para o tipo de elemento em questão. (0 para int, null para ref, etc)");
            Console.WriteLine("meuArray.LastOrDefault(function condicao) = retorna o último elemento que atende à condição" +
                "ou retorna o valor padrão para o tipo de elemento em questão. ");
            Console.WriteLine("meuArray.ElementAtOrDefault(int index) = retorna o elemento no índice especificado" +
                "ou retorna o valor padrão para o tipo de elemento em questão.");
            Console.WriteLine("meuArray.Order() = ordena os elementos em ordem ascendente.");
            Console.WriteLine("meuArray.OrderDescending() = ordena os elementos em ordem descendente.");
            Console.WriteLine("meuArray.Concat(meuArray2) = combina os elementos de duas ou mais sequências em uma única sequência.");
            Console.WriteLine("meuArray.GetType() = retorna o tipo da instância atual.");
            Console.WriteLine("meuArray.Reverse() = inverte a ordem dos elementos na sequência.");
            Console.WriteLine("meuArray.Equals() = usado para comparar dois objetos para igualdade. ");
            Console.WriteLine("meuArray.DistinctBy(p => p.nome) = retorna todos os elementos distintos entre si" +
                "com base na arrow function passada por parâmetro.");
        }
        public static void CriarArrayNumerosInteiros()
        {
            Console.WriteLine("Escreva o tamanho do array que deseja: ");
            int tam = int.Parse(Console.ReadLine());
            Console.WriteLine($"Escreva {tam} números inteiros.");
            int[] vetorInteiro = new int[tam];

            for (int i = 0; i < vetorInteiro.Length; i++)
                vetorInteiro[i] = int.Parse(Console.ReadLine());

            foreach (int inteiro in vetorInteiro)
                Console.WriteLine($"{inteiro} ");
        }

        public static void ProcurarElemento()
        {
            Console.WriteLine("Escreva o tamanho do array que deseja: ");
            int tam = int.Parse(Console.ReadLine());
            int[] vetorInteiro = new int[tam];

            Console.WriteLine($"Escreva {tam} números inteiros.");
            for (int i = 0; i < vetorInteiro.Length; i++)
                vetorInteiro[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual elemento deseja procurar? ");
            int element = int.Parse(Console.ReadLine());

            if (vetorInteiro.First(e => e == element) != 0)
                Console.WriteLine("O elemento existe neste array.");
            else
                Console.WriteLine("O elemento não existe neste array.");
        }

        public static void SomarVetores()
        {
            Console.WriteLine("Escreva o tamanho do array que deseja: ");
            int tam = int.Parse(Console.ReadLine());
            int[] v1 = new int[tam];
            int[] v2 = new int[tam];

            Console.WriteLine($"Escreva {tam} números inteiros para o primeiro array.");
            for (int i = 0; i < v1.Length; i++)
                v1[i] = int.Parse(Console.ReadLine());

            Console.WriteLine($"Escreva {tam} números inteiros para o segundo array.");
            for (int i = v2.Length - 1; i >= 0; i--)
                v2[i] = int.Parse(Console.ReadLine());

            int[] soma = new int[tam];
            for (int i = 0; i < soma.Length; i++)
                soma[i] = v1[i] + v2[i];
            
            Console.WriteLine($"A soma dos vetores é:");
            foreach(int somaAtual in soma)
                Console.WriteLine($"{somaAtual} ");
        }

        public static void ImprimirEstatisticas()
        {
            int[] vetor = new int[10];

            Console.WriteLine($"Escreva 10 números inteiros para o array.");
            for (int i = 0; i < vetor.Length; i++)
                vetor[i] = int.Parse(Console.ReadLine());

            Console.WriteLine($"Soma: {vetor.Sum()}");
            Console.WriteLine($"Média: {vetor.Average()}");
            Console.WriteLine($"Mínimo: {vetor.Min()}");
        }

        public static void SomaGauss()
        {
            Console.WriteLine("Entre com o valor mínimo");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o valor máximo");
            int max = int.Parse(Console.ReadLine());

            float soma = (min + max) * (max - min + 1)/2;
            Console.WriteLine($"A soma dos valores entre os intervalos {min} e {max} é {soma}!");
        }

        public static void QuantificarArray()
        {
            int value = 1;
            List<int> list = new List<int>();
            while (value != 0)
            {
                Console.WriteLine("Entre com um número para o array.");
                bool validValue = int.TryParse(Console.ReadLine(), out value);
                while (!validValue)
                {
                    Console.WriteLine("Entre com um valor válido para o array.");
                    validValue = int.TryParse(Console.ReadLine(), out value);
                }
                list.Add(value);
            }
            int tam = list.Count;
            int soma = list.Sum();
            int pares = list.Where(x => x % 2 == 0 && x != 0).Count();

            Console.WriteLine($"Quantidade: {tam} números lidos\n" +
                              $"Soma: {soma} \nPares: {pares}");
        }
        static void Main(string[] args)
        {
            bool validaOpcao;
            uint opcao = 8;

            Console.WriteLine("\n***** Exercícios Aula 4 *****\n\n");

            while (opcao != 0)
            {
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo do programa...");
                        break;

                    case 1:
                        CriarArrayNumerosInteiros();
                        break;

                    case 2:
                        AnalisarArrayCSharp();
                        break;

                    case 3:
                        ProcurarElemento();
                        break;

                    case 4:
                        SomarVetores();
                        break;

                    case 5:
                        ImprimirEstatisticas();
                        break;

                    case 6:
                        SomaGauss();
                        break;

                    case 7:
                        QuantificarArray();
                        break;

                    case 8:
                        ListarExercicios();
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Digite 9 para listar os exercícios novamente ou 0 caso deseja sair do programa.");
                        break;
                }

                Console.WriteLine("\nEscolha um comando: ");
                validaOpcao = uint.TryParse(Console.ReadLine(), out opcao);

                while (!validaOpcao)
                {
                    Console.WriteLine("Escolha um número válido. Tente novamente:");
                    validaOpcao = uint.TryParse(Console.ReadLine(), out opcao);
                }
            }
        }
    }
}
