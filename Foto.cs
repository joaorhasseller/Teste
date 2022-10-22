using System;
using System.Collections.Generic;

namespace Teste
{
    public partial class Foto
    {
        public Foto()
        {
            Veiculos = new HashSet<Veiculo>();
        }

        public int CodFoto { get; set; }
        public int CodVeiculo { get; set; }
        public string NomeFoto { get; set; } = null!;

        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
