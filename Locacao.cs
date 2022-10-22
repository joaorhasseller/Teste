using System;
using System.Collections.Generic;

namespace Teste
{
    public partial class Locacao
    {
        public Locacao()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int CodLocacao { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int CodCliente { get; set; }
        public int CodVeiculo { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; } = null!;
        public virtual Veiculo CodVeiculoNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
