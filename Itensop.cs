using System;
using System.Collections.Generic;

namespace Teste
{
    public partial class Itensop
    {
        public Itensop()
        {
            Veiculos = new HashSet<Veiculo>();
        }

        public int CodItens { get; set; }
        public bool ArCondicionado { get; set; }
        public bool VoltanteEletrico { get; set; }
        public bool VolanteHidraulico { get; set; }
        public bool FreioAbs { get; set; }
        public bool SensorDeEstacionamento { get; set; }
        public bool VidroEletrico { get; set; }
        public bool TravaEletrica { get; set; }
        public bool Bau { get; set; }
        public bool ProtetorDoMotor { get; set; }
        public bool ParaBrisa { get; set; }
        public bool Encosto { get; set; }

        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
