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
                new Livro("A Guerra dos Tronos", new string[] { "George R. R. Martin" }, "Fantasia", 1996, 694),
                new Livro("O Senhor dos Anéis", new string[] { "J. R. R. Tolkien" }, "Fantasia", 1954, 1178),
                new Livro("1984", new string[] { "George Orwell" }, "Ficção Científica", 1949, 328),
                new Livro("O Código Da Vinci", new string[] { "Dan Brown" }, "Suspense", 2003, 689),
                new Livro("Cem Anos de Solidão", new string[] { "Gabriel García Márquez" }, "Ficção", 1967, 417)
            };
        }

        public void AdicionarLivro(Livro livro)
        {
            livros.Add(livro);
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
