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

            ListaDeProdutos listaDeProdutos = new ListaDeProdutos();
            List<string> produtosListados = listaDeProdutos.ListarProdutos("C", 'c');

            //Convertendo lista em um só string contendo todos os valores
            //Console.WriteLine(string.Join("\n", produtosListados));

            foreach (string produto in produtosListados)
            {
                Console.WriteLine(produto);
            }
        }
    }
}
