using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Teste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> usuarios = new List<Usuario>();
            List<Produto> produtos = new List<Produto>();
            List<Pedido> pedidos = new List<Pedido>();

            var usuarioService = new UsuarioService(usuarios);
            var produtoService = new ProdutoService(produtos);
            var pedidoService = new PedidoService(pedidos, produtos, usuarios);

            Menu(usuarioService, produtoService, pedidoService);
        }

        static void Menu(UsuarioService usuarioService, ProdutoService produtoService, PedidoService pedidoService)
        {
            int numeroPedido = 1, numeroItem = 1;
            int opcao;
            try
            {
                do
                {
                    Console.WriteLine("""

                ------------------Menu------------------
                -Escolha uma opção:
                1- Adicionar um novo produto.
                2- Registrar novo usuário.
                3- Criar um novo pedido.
                4- Listar Usuários.
                5- Listar Pedidos.
                6- Listar Produtos.
                7- Buscar Usuário.
                0- Sair.

                """);

                    opcao = int.Parse(Console.ReadLine());
                    Console.WriteLine("----------------------------------------\n");

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Digite o nome do produto");
                            string nomeProduto = Console.ReadLine();
                            Console.WriteLine("Digite o valor do produto:");
                            double valorProduto = double.Parse(Console.ReadLine());
                            produtoService.AdicionarProduto(numeroItem, nomeProduto, valorProduto);
                            numeroItem++;
                            break;
                        case 2:
                            Console.WriteLine("Digite o nome do usuário");
                            string nomeUsuario = Console.ReadLine();
                            Console.WriteLine("Digite quanto dinheiro o usuário possui na conta bancária:");
                            double contaBancaria = double.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o CPF do usuário");
                            string cpf = Console.ReadLine();
                            usuarioService.AdicionarUsuario(nomeUsuario, contaBancaria, cpf);
                            break;
                        case 3:
                            try
                            {
                                produtoService.ListarProdutos();
                                pedidoService.CriarPedido(numeroPedido);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                            numeroPedido++;
                            break;
                        case 4:
                            usuarioService.ListarUsuarios();
                            break;
                        case 5:
                            pedidoService.ListarPedidos();
                            break;
                        case 6:
                            produtoService.ListarProdutos();
                            break;
                        case 7:
                            usuarioService.BuscarUsuario(pedidoService.pedidos);
                            break;
                        case 0:
                            Console.WriteLine("Finalizando...");
                            break;
                        default:
                            throw new Exception("Opção Inválida");
                    }
                    Console.WriteLine("\nAperte 'Enter' para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                } while (opcao != 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nAperte 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
                Menu(usuarioService, produtoService, pedidoService);
            }
        }
    }
}