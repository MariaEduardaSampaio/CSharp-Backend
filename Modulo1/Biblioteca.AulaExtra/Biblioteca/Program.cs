using System.ComponentModel.DataAnnotations;

namespace Biblioteca
{
    internal class Program
    {
        static void ListarOperacoes()
        {
            Console.WriteLine("\n0 - Sair do programa");
            Console.WriteLine("1 - Adicionar livro.");
            Console.WriteLine("2 - Emprestar livro. ");
            Console.WriteLine("3 - Devolver livro. ");
            Console.WriteLine("4 - Procurar livro específico. ");
            Console.WriteLine("5 - Procurar livros pelo título. ");
            Console.WriteLine("6 - Procurar livros por autor(es).");
            Console.WriteLine("7 - Procurar livros por gênero.");
            Console.WriteLine("8 - Listar todos os livros do acervo. ");
            Console.WriteLine("9 - Listar todos os livros disponíveis. ");
            Console.WriteLine("10 - Listar todos os livros emprestados. ");
            Console.WriteLine("11 - Estatísticas gerais da biblioteca.");
            Console.WriteLine("Qualquer outro número para listar as operações novamente.\n");
        }

        static int tryParseInteiro()
        {
            bool entradaValida;
            int entrada;
            do
            {
                entradaValida = int.TryParse(Console.ReadLine(), out entrada);
            } while (!entradaValida);

            return entrada;
        }

        static void DevolverLivro(Biblioteca biblioteca)
        {
            Console.WriteLine("\nEntre com o nome do livro que deseja devolver: ");
            string nome = Console.ReadLine();
            Livro livroDevolvido = biblioteca.ProcurarLivro(nome);
            if (livroDevolvido != null)
            {
                biblioteca.DevolverLivro(livroDevolvido);
                biblioteca.ListarLivro(livroDevolvido);
            }
        }

        static void EmprestarLivro(Biblioteca biblioteca)
        {
            Console.WriteLine("\nEntre com o nome do livro que deseja pegar: ");
            string nomeLivro = Console.ReadLine();
            Livro livroEmprestado = biblioteca.ProcurarLivro(nomeLivro);
            if (livroEmprestado != null)
            {
                biblioteca.EmprestarLivro(livroEmprestado);
                biblioteca.ListarLivro(livroEmprestado);
            }
        }

        static void ProcurarLivroEspecifico(Biblioteca biblioteca)
        {
            Console.WriteLine("\nEntre com o nome do livro que deseja procurar: ");
            string nomeDoLivro = Console.ReadLine();
            Livro livroEspecifico = biblioteca.ProcurarLivro(nomeDoLivro);
            if (livroEspecifico != null)
                biblioteca.ListarLivro(livroEspecifico);
        }

        static void FiltrarAcervoPorGenero(Biblioteca biblioteca)
        {
            Console.WriteLine("\nEntre com o gênero que deseja filtrar o acervo:");
            string generoFiltro = Console.ReadLine();
            List<Livro> livrosFitlradosPorGenero = biblioteca.FiltrarAcervoPorGenero(generoFiltro);
            Console.WriteLine("Livros do gênero: ");
            biblioteca.ListarLivros(livrosFitlradosPorGenero);
        }

        static void FiltrarAcervoPorAutor(Biblioteca biblioteca)
        {
            Console.WriteLine("\nExistem quantos autores?");
            int numAutores = tryParseInteiro();
            string[] autoresFiltro = new string[numAutores];
            for (int i = 0; i < numAutores; i++)
            {
                Console.WriteLine($"Entre com o {i + 1}o autor do livro:");
                autoresFiltro[i] = Console.ReadLine();
            }

            List<Livro> livrosFitlradosPorAutor = biblioteca.FiltrarAcervoPorAutor(autoresFiltro);
            Console.WriteLine("Livros do autor: ");
            biblioteca.ListarLivros(livrosFitlradosPorAutor);
        }

        static void FiltrarAcervoPorTitulo(Biblioteca biblioteca)
        {
            Console.WriteLine("\nEntre com o filtro sobre o acervo: ");
            string filtro = Console.ReadLine();
            List<Livro> livrosFitlrados = biblioteca.FiltrarAcervo(filtro);
            biblioteca.ListarLivros(livrosFitlrados);
        }

        static void AdicionarLivro(Biblioteca biblioteca)
        {
            Console.WriteLine("Entre com o nome do livro que deseja adicionar:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Existem quantos autores?");
            int numeroAutores = tryParseInteiro();

            string[] autores = new string[numeroAutores];
            for (int i = 0; i < numeroAutores; i++)
            {
                Console.WriteLine("Entre com o autor do livro:");
                autores[i] = Console.ReadLine();
            }
            Console.WriteLine("Entre com o gênero do livro: ");
            string genero = Console.ReadLine();

            Console.WriteLine("Entre com o ano de publicação: ");
            int anoDePublicacao = tryParseInteiro();

            Console.WriteLine("Entre com o número de páginas: ");
            int paginas = tryParseInteiro();

            Livro livro = new Livro(titulo, autores, genero, anoDePublicacao, paginas);
            biblioteca.ListarLivro(livro);
            biblioteca.AdicionarLivro(livro);
        }
        static void Main()
        {
            int opcao = 100;
            Biblioteca biblioteca = new Biblioteca();

            do {
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("\nSaindo do programa...\n");
                        break;

                    case 1:
                        AdicionarLivro(biblioteca);
                        break;

                    case 2:
                        EmprestarLivro(biblioteca);
                        break;

                    case 3:
                        DevolverLivro(biblioteca);
                        break;

                    case 4:
                        ProcurarLivroEspecifico(biblioteca);
                        break;

                    case 5:
                        FiltrarAcervoPorTitulo(biblioteca);
                        break;

                    case 6:
                        FiltrarAcervoPorAutor(biblioteca);
                        break;

                    case 7:
                        FiltrarAcervoPorGenero(biblioteca);
                        break;

                    case 8:
                        Console.WriteLine("\n\tLivros do Acervo\n");
                        biblioteca.ListarLivros();
                        break;

                    case 9:
                        Console.WriteLine("\n\tLivros Disponíveis\n");
                        biblioteca.ListarLivrosDisponiveis();
                        break;

                    case 10:
                        Console.WriteLine("\n\tLivros Emprestados\n");
                        biblioteca.ListarLivrosEmprestados();
                        break;

                    case 11:
                        Console.WriteLine("\n\tEstatísticas gerais da biblioteca");
                        biblioteca.EstatisticasGerais();
                        break;

                    default:
                        ListarOperacoes();
                        break;
                }

                Console.WriteLine("\nEntre com uma operação: ");
                opcao = tryParseInteiro();

            } while (opcao != 0);
        }
    }
}
