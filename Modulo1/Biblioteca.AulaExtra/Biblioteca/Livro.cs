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
        public int AnoDePublicacao { get; set; }
        public int Paginas { get; set; }

        public Livro(string titulo, string[] autor, int anoDePublicacao, int paginas) { 
            Titulo = titulo;
            Autor = autor;
            AnoDePublicacao = anoDePublicacao;
            Paginas = paginas;
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
    }
}
