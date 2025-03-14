using Teste;

public class UsuarioService
{
    private List<Usuario> usuarios;

    public UsuarioService(List<Usuario> usuarios)
    {
        this.usuarios = usuarios;
    }

    public void AdicionarUsuario(string nome, double conta, string cpf)
    {
        foreach (var pessoa in usuarios)
        {
            if (nome == pessoa.NomeUsuario)
            {
                throw new Exception("O CPF já foi cadastrado anteriormente no sistema.");
            }
        }
        var usuario = new Usuario(nome, conta, cpf);
        usuarios.Add(usuario);
    }

    public void ListarUsuarios()
    {
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Não há nenhum usuário cadastrado no sistema.");
            return;
        }
        Console.WriteLine("----------Lista de Usuários----------\n");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"Nome do Usuario: {usuario.NomeUsuario}");
            Console.WriteLine($"Conta Bancária do Usuario: {usuario.ContaBancaria}");
            Console.WriteLine($"CPF do Usuario: {usuario.Cpf}\n");
        }
    }

    public void BuscarUsuario(List<Pedido> pedidosList)
    {
        Console.WriteLine($"Digite o CPF do usuário: ");
        string cpf = Console.ReadLine();

        var cliente = usuarios.FirstOrDefault(u => u.Cpf.Equals(cpf));
        if (cliente == null)
        {
            Console.WriteLine("Usuário não encontrado.");
            return;
        }
        else
        {
            Console.WriteLine($"\nNome do Usuario: {cliente.NomeUsuario}");
            Console.WriteLine($"Conta Bancária do Usuario: {cliente.ContaBancaria}");
            Console.WriteLine($"CPF do Usuario: {cliente.Cpf}\n");
            Console.WriteLine("-Pedidos:\n");

            if (cliente.Pedidos.Count == 0)
            {
                Console.WriteLine("Não há nenhum pedido relacionado a este usuário no sistema.");
                return;
            }

            foreach (int numeroPedido in cliente.Pedidos)
            {
                foreach (Pedido pedido in pedidosList)
                {
                    if (numeroPedido == pedido.NumeroPedido)
                    {
                        double total = 0;

                        Console.WriteLine($"Número do pedido: {pedido.NumeroPedido}");
                        Console.WriteLine($"Itens: ");
                        for (int j = 0; j < pedido.Produtos.Count; j++)
                        {
                            Console.WriteLine($"Item {j + 1} - {pedido.Produtos[j].NomeProduto}");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < pedido.Produtos.Count; i++)
                        {
                            total += pedido.Produtos[i].Preco;
                        }
                        Console.WriteLine($"Valor Total do Pedido: {total}\n");
                    }
                }
            }
        }
    }
}
