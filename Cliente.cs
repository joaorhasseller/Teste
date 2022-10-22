using System;
using System.Collections.Generic;

namespace Teste
{
    public partial class Cliente
    {
        public Cliente()
        {
            Locacaos = new HashSet<Locacao>();
            Logins = new HashSet<Login>();
            Pedidos = new HashSet<Pedido>();
        }

        public int CodCliente { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Rg { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Endereço { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Locacao> Locacaos { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
