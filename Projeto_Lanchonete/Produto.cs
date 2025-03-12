using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class Produto
    {
        public int Id;
        public string NomeProduto;
        public double Preco;

        public Produto(int Id,string NomeProduto, double Preco)
        {
            this.Id = Id;
            this.NomeProduto = NomeProduto;
            this.Preco = Preco;
        }
    }
}
