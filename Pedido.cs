using System;
using System.Collections.Generic;

namespace Teste
{
    public partial class Pedido
    {
        public int CodPedido { get; set; }
        public int CodCliente { get; set; }
        public DateOnly DataCompra { get; set; }
        public int CodVeiculo { get; set; }
        public int CodLocacao { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; } = null!;
        public virtual Locacao CodLocacaoNavigation { get; set; } = null!;
        public virtual Veiculo CodVeiculoNavigation { get; set; } = null!;
    }
}
