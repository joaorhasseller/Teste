using System;
using System.Collections.Generic;

namespace Teste
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Locacaos = new HashSet<Locacao>();
            Pedidos = new HashSet<Pedido>();
        }

        public int CodVeiculo { get; set; }
        public string Nome { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public short Ano { get; set; }
        public string Placa { get; set; } = null!;
        public string Cor { get; set; } = null!;
        public string Combustivel { get; set; } = null!;
        public string Renavan { get; set; } = null!;
        public string Chassi { get; set; } = null!;
        public string Cambio { get; set; } = null!;
        public double Preco { get; set; }
        public int CodItens { get; set; }
        public string Tipo { get; set; } = null!;
        public int CodFoto { get; set; }

        public virtual Foto CodFotoNavigation { get; set; } = null!;
        public virtual Itensop CodItensNavigation { get; set; } = null!;
        public virtual ICollection<Locacao> Locacaos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
