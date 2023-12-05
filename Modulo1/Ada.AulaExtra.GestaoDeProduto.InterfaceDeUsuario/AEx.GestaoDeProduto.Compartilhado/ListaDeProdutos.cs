namespace AEx.GestaoDeProduto.Compartilhado
{
    public class ListaDeProdutos
    {
        private List<string> produtos = new List<string>()
        {
            "Doce de leite", "Leite", "Queijo", "Goiabada",
            "Suco de Uva", "Iogurte", "Queijadinha", "Cocada",
            "Coca cola", "Refrigerante", "Cerveja", "Pão", "Limão"
        };

        public List<string> OrdenarProdutos(char ordenacao)
        {
            if (ordenacao == 'c')
                produtos = produtos.Order().ToList();

            if (ordenacao == 'd')
                produtos = produtos.OrderDescending().ToList();

            return produtos;
        }
        public List<string> FiltrarProdutos(string filtro)
        {
            List<string> produtosFiltrados = produtos.Where(produto => produto.StartsWith(filtro)).ToList();
            
            return produtosFiltrados;
        }
        public void ListarProdutos(List<string> produtos)
        {
            foreach (string produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }

        public void AdicionarProduto(string produto)
        {
            produtos.Add(produto);
            Console.WriteLine($"{produto} adicionado com sucesso!");
        }

        public void AlterarProduto(string produtoAnterior, string produtoAtual)
        {
            produtos[produtos.IndexOf(produtoAnterior)] = produtoAtual;
            Console.WriteLine("Produto alterado com sucesso!");
        }

        public void RemoverProduto(string produto)
        {
            if (produtos.Remove(produto))
                Console.WriteLine("Produto removido com sucesso!");
            else
                Console.WriteLine("Produto não encontrado!");
        }
    }
}
