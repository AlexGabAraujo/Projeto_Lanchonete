using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class Usuario
    {
        public string NomeUsuario;
        public double ContaBancaria;
        public string Cpf;
        public List<int> Pedidos = new List<int>();

        public Usuario(string NomeUsuario, double ContaBancaria, string Cpf)
        {
            this.NomeUsuario = NomeUsuario;
            this.ContaBancaria = ContaBancaria;
            this.Cpf = Cpf;
        }

    }
}
