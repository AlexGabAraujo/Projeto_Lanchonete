using System.ComponentModel.Design;
using System.Xml.Schema;
using Teste;

public class PedidoService
{
    public List<Pedido> pedidos;
    private List<Produto> produtos;
    private List<Usuario> usuarios;

    public PedidoService(List<Pedido> pedidos, List<Produto> produtos, List<Usuario> usuarios)
    {
        this.pedidos = pedidos;
        this.produtos = produtos;
        this.usuarios = usuarios;
    }

    public void CriarPedido(int numeroPedido)
    {
        int opcao, i = 1;
        double total = 0;

        List<Produto> listaPedido = new List<Produto>();

        do
        {
            Console.WriteLine($"Digite o nome ou ID do {i}º item que deseja adicionar:");
            i++;
            string nomeProduto = Console.ReadLine();
            foreach (var produto in produtos)
            {
                if (produto.NomeProduto.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase) || produto.Id == int.Parse(nomeProduto))
                    listaPedido.Add(produto);
            }
            Console.WriteLine("Quer adicionar outro item?(1- sim, 0- não)");
            opcao = int.Parse(Console.ReadLine());
        } while (opcao != 0);

        Console.WriteLine("Digite o CPF do comprador.");
        string cpf = Console.ReadLine();

        var cliente = usuarios.FirstOrDefault(u => u.Cpf.Equals(cpf));
        if (cliente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        foreach (var produto in listaPedido)
        {
            total += produto.Preco;
        }

        if (total > cliente.ContaBancaria)
        {
            throw new Exception("O usuário não possui dinheiro suficiente na conta para realizar esta compra.");
        }
        else
        {
            Console.WriteLine("Compra Realizada com Sucesso.");
            cliente.ContaBancaria -= total;
            cliente.Pedidos.Add(numeroPedido);
        }

        var pedido = new Pedido(numeroPedido, listaPedido, cliente.NomeUsuario);
        
        pedidos.Add(pedido);
    }

    public void TotalPedido(int numeroPedido)
    {
        var pedido = pedidos.FirstOrDefault(p => p.NumeroPedido.Equals(numeroPedido));
    }

    public void ListarPedidos()
    {
        double total = 0;

        if (pedidos.Count == 0)
        {
            Console.WriteLine("Não há nenhum pedido cadastrado no sistema.");
            return;
        }

        Console.WriteLine("----------Lista de Pedidos----------\n");
        foreach (Pedido pedido in pedidos)
        {
            Console.WriteLine($"Número do pedido: {pedido.NumeroPedido}");
            Console.WriteLine($"Itens: ");
            for (int i = 0; i < pedido.Produtos.Count; i++)
            {
                Console.WriteLine($"Item {i+1} - {pedido.Produtos[i].NomeProduto}");
            }
            Console.WriteLine($"Nome do Comprador: {pedido.cliente}\n");
            for(int i = 0; i < pedido.Produtos.Count; i++)
            {
                total += pedido.Produtos[i].Preco;
            }
        }
    }
}