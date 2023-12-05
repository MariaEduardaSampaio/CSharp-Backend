using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Livro
    {
        public string Titulo;
        public string[] Autor;
        public string Genero;
        public int AnoDePublicacao;
        public int Paginas;
        public bool Disponivel;

        public Livro(string titulo, string[] autor, string genero, int anoDePublicacao, int paginas) { 
            SetTitulo(titulo);
            SetAutor(autor);
            SetGenero(genero);
            SetAnoDePublicacao(anoDePublicacao);
            SetPaginas(paginas);
            SetDisponibilidade(true);
        }
        public string GetTitulo()
        {
            return this.Titulo;
        }

        public void SetTitulo(string titulo)
        {
            if (!string.IsNullOrEmpty(titulo))
                this.Titulo = titulo;
            else
                Console.WriteLine("O título não pode ser vazio.");
        }
        public string[] GetAutor()
        {
            return this.Autor;
        }

        public void SetAutor(string[] autor)
        {
            if (!autor.Any(string.IsNullOrEmpty))
                Autor = autor;
            else
                Console.WriteLine("O livro deve ter ao menos um autor.");
        }

        public int GetAnoDePublicacao()
        {
            return AnoDePublicacao;
        }

        public void SetAnoDePublicacao(int anoDePublicacao)
        {
            if (anoDePublicacao <= 0)
                Console.WriteLine("Ano de publicação de livro é inválido.");
            else
                AnoDePublicacao = anoDePublicacao;
        }

        public int GetPaginas()
        {
            return Paginas;
        }

        public void SetPaginas(int paginas)
        {
            if (paginas <= 0)
                Console.WriteLine("Número de páginas deve ser maior que 0.");
            else 
                Paginas = paginas;
        }

        public bool GetDisponibilidade()
        {
            return Disponivel;
        }

        public void SetDisponibilidade(bool disponivel)
        {
            Disponivel = disponivel;
        }

        public string GetGenero()
        {
            return Genero;
        }

        public void SetGenero(string genero)
        {
            if (genero.Trim().Length > 0 || genero != null)
                Genero = genero;
            else
                Console.WriteLine("Gênero inválido.");
        }

    }
}
