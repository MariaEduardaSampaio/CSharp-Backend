using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Biblioteca
    {
        private List<Livro> livros;

        public Biblioteca()
        {
            livros = new List<Livro>()
            {
                new Livro("A Guerra dos Tronos", ["George R. R. Martin"], "Fantasia", 1996, 694),
                new Livro("O Senhor dos Anéis", ["J. R. R. Tolkien"], "Fantasia", 1954, 1178),
                new Livro("1984", ["George Orwell"], "Ficção Científica", 1949, 328),
                new Livro("O Código Da Vinci", ["Dan Brown"], "Suspense", 2003, 689),
                new Livro("Cem Anos de Solidão", ["Gabriel García Márquez"], "Ficção", 1967, 417),
                new Livro("Harry Potter e a Pedra Filosofal", ["J.K. Rowling"], "Fantasia", 1997, 332),
                new Livro("O Hobbit", ["J.R.R. Tolkien"], "Fantasia", 1937, 310),
                new Livro("Neuromancer", ["William Gibson"], "Ficção Científica", 1984, 271),
                new Livro("O Círculo", ["Dave Eggers"], "Ficção", 2013, 491),
                new Livro("A Moreninha", ["Joaquim Manuel de Macedo"], "Romance", 1844, 200),
                new Livro("O Alquimista", ["Paulo Coelho"], "Ficção", 1988, 182),
                new Livro("A Revolução dos Bichos", ["George Orwell"], "Ficção", 1945, 128),
                new Livro("A Máquina do Tempo", ["H.G. Wells"], "Ficção Científica", 1895, 118),
                new Livro("O Principezinho", ["Antoine de Saint-Exupéry"], "Fábula", 1943, 93),
                new Livro("O Nome do Vento", ["Patrick Rothfuss"], "Fantasia", 2007, 662),
                new Livro("A Culpa é das Estrelas", ["John Green"], "Romance", 2012, 313),
                new Livro("Dom Casmurro", ["Machado de Assis"], "Romance", 1899, 256),
                new Livro("O Iluminado", ["Stephen King"], "Terror", 1977, 447),
                new Livro("A Menina que Roubava Livros", ["Markus Zusak"], "Romance", 2005, 480),
                new Livro("Os Miseráveis", ["Victor Hugo"], "Romance", 1862, 1463),
                new Livro("O Retrato de Dorian Gray", ["Oscar Wilde"], "Ficção", 1890, 223),
                new Livro("A Odisséia", ["Homero"], "Épico", 1, 324),
                new Livro("A Divina Comédia", ["Dante Alighieri"], "Épico", 1320, 798),
                new Livro("A Guerra do Fim do Mundo", ["Mario Vargas Llosa"], "Ficção", 1981, 568),
                new Livro("O Senhor das Moscas", ["William Golding"], "Ficção", 1954, 224),
                new Livro("Sapiens: Uma Breve História da Humanidade", ["Yuval Noah Harari"], "Não Ficção", 2014, 443),
                new Livro("O Silmarillion", ["J.R.R. Tolkien"], "Fantasia", 1977, 365),
                new Livro("O Pequeno Príncipe", ["Antoine de Saint-Exupéry"], "Fábula", 1943, 91),
                new Livro("O Poderoso Chefão", ["Mario Puzo"], "Crime", 1969, 448),
                new Livro("A Revolta de Atlas", ["Ayn Rand"], "Ficção", 1957, 1168),
                new Livro("O Apanhador no Campo de Centeio", ["J.D. Salinger"], "Ficção", 1951, 234),
                new Livro("O Grande Gatsby", ["F. Scott Fitzgerald"], "Ficção", 1925, 218),
                new Livro("O Pequeno Livro das Grandes Virtudes", ["William J. Bennett"], "Não Ficção", 1993, 544),
                new Livro("O Ladrão de Raios", ["Rick Riordan"], "Fantasia", 2005, 400),
                new Livro("O Médico", ["Noah Gordon"], "Histórico", 1986, 544),
                new Livro("O Labirinto dos Espíritos", ["Carlos Ruiz Zafón"], "Mistério", 2016, 920),
                new Livro("As Crônicas de Nárnia", ["C.S. Lewis"], "Fantasia", 1950, 767),
                new Livro("O Exorcista", ["William Peter Blatty"], "Terror", 1971, 385)
            };
        }

        public void AdicionarLivro(Livro livroAdicionado)
        {
            if (livros.Where(livro => livro.GetTitulo() == livroAdicionado.GetTitulo()) == null)
                livros.Add(livroAdicionado);
            else
                Console.WriteLine("Livro já existe no acervo.");
        }

        public List<Livro> FiltrarAcervo(string titulo)
        {
            List<Livro> livroEncontrado = livros.Where(livro => livro.GetTitulo().ToUpper().Contains(titulo.ToUpper())).ToList();
            if (livroEncontrado == null)
                Console.WriteLine("Não existe livro com este nome.");
            
            return livroEncontrado;
        }

        public Livro ProcurarLivro(string titulo)
        {
            Livro livroEncontrado = livros.FirstOrDefault(livro => livro.GetTitulo().ToUpper().Contains(titulo.ToUpper()));
            if (livroEncontrado == null)
                Console.WriteLine("Não existe livro com este nome.");
            
            return livroEncontrado;
        }

        public List<Livro> FiltrarAcervoPorAutor(string[] autores)
        {
            List<Livro> livrosEncontrados = livros
                .Where(livro => autores.All(autor => livro.GetAutor().Contains(autor)))
                .ToList();

            if (livrosEncontrados.Count == 0)
                Console.WriteLine("Não existe livro deste autor.");

            return livrosEncontrados;
        }
        public List<Livro> FiltrarAcervoPorGenero(string genero)
        {
            List<Livro> livroEncontrado = livros.Where(livro => livro.GetGenero().ToUpper().Contains(genero.ToUpper())).ToList();
            if (livroEncontrado == null)
                Console.WriteLine($"Não existem livros do gênero {genero}.");

            return livroEncontrado;
        }

        public void EmprestarLivro(Livro livro)
        {
            if (livro.GetDisponibilidade())
            {
                Console.WriteLine("\nLivro emprestado com sucesso!");
                livro.SetDisponibilidade(false);
            }
            else
                Console.WriteLine("\nLivro não está disponível.");
        }

        public void DevolverLivro(Livro livro)
        {
            if (!livro.GetDisponibilidade())
            {
                Console.WriteLine("\nLivro devolvido com sucesso!");
                livro.SetDisponibilidade(true);
            }
            else
                Console.WriteLine("\nLivro não foi emprestado para ser devolvido.");
        }

        public void ListarLivros()
        {
            Console.WriteLine("************************************");
            foreach (Livro livro in livros)
                ListarLivro(livro);
            Console.WriteLine("************************************");
        }

        public void ListarLivros(List<Livro> livros)
        {
            Console.WriteLine("************************************");
            foreach (Livro livro in livros)
                ListarLivro(livro);
            Console.WriteLine("************************************");
        }

        public void ListarLivro(Livro livro)
        {
            Console.WriteLine($"\nTítulo: {livro.GetTitulo()}");
            Console.WriteLine($"Autor(es): {string.Join(", ", livro.GetAutor())}");
            Console.WriteLine($"Gênero: {livro.GetGenero()}");
            Console.WriteLine($"Ano de publicação: {livro.GetAnoDePublicacao()}");
            Console.WriteLine($"Número de páginas: {livro.GetPaginas()}");
            if (livro.GetDisponibilidade())
                Console.WriteLine($"Disponibilidade: Disponível para empréstimo");
            else
                Console.WriteLine($"Disponibilidade: Emprestado");
        }

        public void ListarLivrosDisponiveis()
        {
            Console.WriteLine("************************************");
            foreach (Livro livro in livros.Where(livro => livro.GetDisponibilidade()))
                ListarLivro(livro);
            Console.WriteLine("************************************");
        }

        public void ListarLivrosEmprestados()
        {
            Console.WriteLine("************************************");
            foreach (Livro livro in livros.Where(livro => !livro.GetDisponibilidade()))
                ListarLivro(livro);
            Console.WriteLine("************************************");
        }

        public void EstatisticasGerais()
        {
            List<Livro> livrosDisponiveis = livros.Where(livro => livro.GetDisponibilidade()).ToList();
            List<Livro> livrosEmprestados = livros.Where(livro => !livro.GetDisponibilidade()).ToList();
            Console.WriteLine($"Quantidade de livros: {livros.Count()}");
            Console.WriteLine($"Quantidade de livros disponíveis: {livrosDisponiveis.Count()}");
            Console.WriteLine($"Quantidade de livros emprestados: {livrosEmprestados.Count()}");
        }
    }
}
