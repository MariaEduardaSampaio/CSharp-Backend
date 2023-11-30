namespace Exercicios
{
    internal class Program
    {
        static void ListarExercicios()
        {
            Console.WriteLine("0 - Sair do programa.");
            Console.WriteLine("1 - Escreva uma função que receba uma matriz de inteiros e retorne a soma de todos os elementos.");
            Console.WriteLine("2 - Crie uma função que verifique se uma matriz quadrada é uma matriz identidade. Uma matriz identidade tem todos os elementos diagonais iguais a 1 e os elementos não diagonais iguais a 0.");
            Console.WriteLine("3 - Escreva uma função que realize a multiplicação de duas matrizes. Certifique-se de verificar se as matrizes são compatíveis para a multiplicação.");
            Console.WriteLine("4 - Implemente uma função que calcule a soma de cada linha e coluna de uma matriz bidimensional e retorne os resultados.");
            Console.WriteLine("5 - Listar os exercícios novamente.");
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
                    Console.WriteLine("Escolha um exercício:");
                    validaOpcao = int.TryParse(Console.ReadLine(), out option);
                } while (!validaOpcao);

                switch (option)
                {
                    case 0: Console.WriteLine("Saindo do programa...");
                        break;

                    case 1:
                        int[,] matriz1 = Matriz.CriaMatriz();
                        matriz1 = Matriz.PreencheMatriz(matriz1);
                        Matriz.ImprimeMatriz(matriz1);
                        int soma = Matriz.SomaElementos(matriz1);
                        Console.WriteLine($"A soma dos elementos da matriz é igual a {soma}.\n\n");
                        break;

                    case 2:
                        int[,] matriz2 = Matriz.CriaMatriz();
                        matriz2 = Matriz.PreencheMatriz(matriz2);
                        Matriz.ImprimeMatriz(matriz2);
                        if (Matriz.VerificaMatrizQuadrada(matriz2))
                        {
                            if (Matriz.VerificaMatrizIdentidade(matriz2))
                            {
                                Console.WriteLine("A matriz é identidade.\n");
                            } 
                            else
                            {
                                Console.WriteLine("A matriz não é identidade.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("A matriz não é quadrada.\n");
                        }
                        break;

                    case 3:
                        int[,] matriz3A = Matriz.CriaMatriz();
                        matriz3A = Matriz.PreencheMatriz(matriz3A);
                        Matriz.ImprimeMatriz(matriz3A);
                        int[,] matriz3B = Matriz.CriaMatriz();
                        matriz3B = Matriz.PreencheMatriz(matriz3B);
                        Matriz.ImprimeMatriz(matriz3B);
                        if(Matriz.VerificaMultMatrizes(matriz3A, matriz3B))
                        {
                            int[,] matrizResultante = Matriz.MultiplicaMatrizes(matriz3A, matriz3B);
                            Console.WriteLine("A multiplicação das matrizes é igual a: ");
                            Matriz.ImprimeMatriz(matrizResultante);
                        }
                        else
                        {
                            Console.WriteLine("Não é possível multiplicar estas matrizes.");
                        }
                        break;

                    case 4:
                        int[,] matriz4 = Matriz.CriaMatriz();
                        matriz4 = Matriz.PreencheMatriz(matriz4);
                        Matriz.ImprimeMatriz(matriz4);
                        int [] totalSomaLinhas = Matriz.SomaLinhasMatriz(matriz4);
                        int[] totalSomaColunas = Matriz.SomaColunasMatriz(matriz4);
                        int passoLinhas = 0;
                        int passoColunas = 0;

                        Console.WriteLine("Soma de todos os elementos por linha e coluna: ");
                        foreach(int total in totalSomaLinhas)
                        {
                            passoLinhas++;
                            Console.WriteLine($"Linha {passoLinhas}: {total} ");
                        }

                        foreach (int total in totalSomaColunas)
                        {
                            passoColunas++;
                            Console.WriteLine($"Coluna {passoColunas}: {total} ");
                        }
                        break;
                    case 5:
                        ListarExercicios();
                        break;
                }

            } while (option != 0);
        }
    }
}
