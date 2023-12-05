using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEx.GestaoDeProduto.Compartilhado;

namespace Ada.AulaExtra
{
    internal class GeradorDeInterface
    {
        public void Gerar()
        {
            Console.WriteLine("Bem vindo ao sistema de Gestão de Produtos.");
            // falta fazer o menu
            ListaDeProdutos listaDeProdutos = new ListaDeProdutos();

            // listaDeProdutos.AlterarProduto("Leite", "Café");
            List<string> produtosFiltrados = listaDeProdutos.FiltrarProdutos("Co");
        }
    }
}
