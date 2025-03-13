using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class Pedido
    {
        public int NumeroPedido;
        public List<Produto> Produtos = new List<Produto>();
        public string cliente;
        public double TotalPedido;

        public Pedido(int NumeroPedido, List<Produto> Produtos, string cliente)
        {
            this.NumeroPedido = NumeroPedido;
            this.Produtos = Produtos;
            this.cliente = cliente;
    }
    }
}
