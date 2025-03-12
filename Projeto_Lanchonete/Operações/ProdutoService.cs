using Teste;

public class ProdutoService
{
    private List<Produto> produtos;

    public ProdutoService(List<Produto> produtos)
    {
        this.produtos = produtos;
    }

    public void AdicionarProduto(int Id, string nome, double valor)
    {
        var produto = new Produto(Id, nome, valor);
        produtos.Add(produto);
    }

    public void ListarProdutos()
    {
        if (produtos.Count == 0)
        {
            Console.WriteLine("Não há nenhum produto cadastrado no sistema.");
            return;
        }
        Console.WriteLine("----------------Cardápio----------------\n");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.Id}");
            Console.WriteLine($"Nome do Produto: {produto.NomeProduto}");
            Console.WriteLine($"Preço: {produto.Preco}\n");
        }
    }
}