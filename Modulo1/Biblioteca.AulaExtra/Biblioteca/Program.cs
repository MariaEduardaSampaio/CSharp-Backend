namespace Biblioteca
{
    internal class Program
    {
        static void ListarOperacoes()
        {
            Console.WriteLine("\n0 - Sair do programa");
            Console.WriteLine("1 - Filtrar livros. ");
            Console.WriteLine("2 - Procurar livro específico. ");
            Console.WriteLine("3 - Adicionar livro.");
            Console.WriteLine("4 - Listar todos os livros do acervo. ");
            Console.WriteLine("5 - Listar todos os livros emprestados. ");
            Console.WriteLine("6 - Listar todos os livros disponíveis. ");
            Console.WriteLine("7 - Emprestar livro. ");
            Console.WriteLine("8 - Devolver livro. ");
            Console.WriteLine("9 - Procurar livros por autor(es).");
            Console.WriteLine("10 - Procurar livros por gênero.");
            Console.WriteLine("11 - Estatísticas gerais da biblioteca.");
            Console.WriteLine("Qualquer outro número para listar as operações novamente.\n");
        }
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            int option = 9;
            bool opcaoValida = false;
            do {
                switch (option)
                {
                    case 0:
                        Console.WriteLine("\nSaindo do programa...\n");
                        break;

                    case 1: 
                        Console.WriteLine("\nEntre com o filtro sobre o acervo: ");
                        string filtro = Console.ReadLine();
                        List<Livro> livrosFitlrados = biblioteca.FiltrarAcervo(filtro);
                        biblioteca.ListarLivros(livrosFitlrados);
                        break;

                    case 2:
                        Console.WriteLine("\nEntre com o nome do livro que deseja procurar: ");
                        string nomeDoLivro = Console.ReadLine();
                        Livro livroEspecifico = biblioteca.ProcurarLivro(nomeDoLivro);
                        if (livroEspecifico != null)
                            biblioteca.ListarLivro(livroEspecifico);
                        break;

                    case 3:
                        Console.WriteLine("Entre com o nome do livro que deseja adicionar:");
                        string titulo = Console.ReadLine();

                        Console.WriteLine("Existem quantos autores?");
                        int numeroAutores = int.Parse(Console.ReadLine());

                        string[] autores = new string[numeroAutores];
                        for(int i = 0; i < numeroAutores; i++)
                        {
                            Console.WriteLine("Entre com o autor do livro:");
                            autores[i] = Console.ReadLine();
                        }
                        Console.WriteLine("Entre com o gênero do livro: ");
                        string genero = Console.ReadLine();

                        Console.WriteLine("Entre com o ano de publicação: ");
                        int anoDePublicacao = int.Parse(Console.ReadLine());

                        Console.WriteLine("Entre com o número de páginas: ");
                        int paginas = int.Parse(Console.ReadLine());

                        Livro livro = new Livro(titulo, autores, genero, anoDePublicacao, paginas);
                        break;
                    case 4:
                        Console.WriteLine("\n\tLivros do Acervo\n");
                        biblioteca.ListarLivros();
                        break;

                    case 5:
                        Console.WriteLine("\n\tLivros Emprestados\n");
                        biblioteca.ListarLivrosEmprestados();
                        break;

                    case 6:
                        Console.WriteLine("\n\tLivros Disponíveis\n");
                        biblioteca.ListarLivrosDisponiveis();
                        break;

                    case 7:
                        Console.WriteLine("\nEntre com o nome do livro que deseja pegar: ");
                        string nomeLivro = Console.ReadLine();
                        Livro livroEmprestado = biblioteca.ProcurarLivro(nomeLivro);
                        if (livroEmprestado != null)
                        {
                            biblioteca.EmprestarLivro(livroEmprestado);
                            biblioteca.ListarLivro(livroEmprestado);
                        }
                        break;

                    case 8:
                        Console.WriteLine("\nEntre com o nome do livro que deseja devolver: ");
                        string nome = Console.ReadLine();
                        Livro livroDevolvido = biblioteca.ProcurarLivro(nome);
                        if (livroDevolvido != null)
                        {
                            biblioteca.DevolverLivro(livroDevolvido);
                            biblioteca.ListarLivro(livroDevolvido);
                        }
                        break;

                    case 9:
                        Console.WriteLine("\nExistem quantos autores?");
                        int numAutores = int.Parse(Console.ReadLine());
                        string[] autoresFiltro = new string[numAutores];
                        for (int i = 0; i < numAutores; i++)
                        {
                            Console.WriteLine($"Entre com o {i+1}o autor do livro:");
                            autoresFiltro[i] = Console.ReadLine();
                        }

                        List<Livro> livrosFitlradosPorAutor = biblioteca.FiltrarAcervoPorAutor(autoresFiltro);
                        Console.WriteLine("Livros do autor: ");
                        biblioteca.ListarLivros(livrosFitlradosPorAutor);
                        break;

                    case 10:
                        Console.WriteLine("\nEntre com o gênero que deseja filtrar o acervo:");
                        string generoFiltro = Console.ReadLine();
                        List<Livro> livrosFitlradosPorGenero = biblioteca.FiltrarAcervoPorGenero(generoFiltro);
                        Console.WriteLine("Livros do gênero: ");
                        biblioteca.ListarLivros(livrosFitlradosPorGenero);
                        break;

                    case 11:
                        Console.WriteLine("\n\tEstatísticas gerais da biblioteca");
                        biblioteca.EstatisticasGerais();
                        break;

                    default:
                        ListarOperacoes();
                        break;
                }

                do
                {
                    Console.WriteLine("\nEntre com uma operação: ");
                    opcaoValida = int.TryParse(Console.ReadLine(), out option);
                } while (!opcaoValida);

            } while (option != 0);
        }
    }
}
