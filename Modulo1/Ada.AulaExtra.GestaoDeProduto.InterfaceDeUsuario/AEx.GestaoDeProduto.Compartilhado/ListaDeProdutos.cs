namespace AEx.GestaoDeProduto.Compartilhado
{
    public class ListaDeProdutos
    {
        //extenção de funcionalidade
        //ordem da listagem
        //Filtrar para apenas produtos que comecem com uma ou mais letras

        public List<string> ListarProdutos(string? filtro = null, char? ordenacao = 'n')
        {
            List<string> produtos = new List<string>()
            {
                "Doce de leite",
                "Leite",
                "Queijo",
                "Goiabada",
                "Suco de Uva",
                "Iogurte",
                "Queijadinha",
                "Cocada",
                "Coca cola",
                "Refrigerante",
                "Cerveja",
                "Pão",
                "Limão"
            };

            if (ordenacao == 'c')
                produtos = produtos.Order().ToList();
            
            if (ordenacao == 'd')
                produtos = produtos.OrderDescending().ToList();

            if (filtro != null)
            {
                List<string> produtosFiltrados = produtos.Where(produto => produto.StartsWith(filtro)).ToList();
                return produtosFiltrados;
            }
            
            return produtos;
        }
        //novas funcionalidades
        //Adicionar Produtos
        //Alterar Produtos
        //Remover Produtos
    }
}
