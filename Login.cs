using System;
using System.Collections.Generic;

namespace Teste
{
    public partial class Login
    {
        public int CodLogin { get; set; }
        public int CodCliente { get; set; }
        public string Senha { get; set; } = null!;
        public string Perfil { get; set; } = null!;
        public string Usuario { get; set; } = null!;

        public virtual Cliente CodClienteNavigation { get; set; } = null!;
    }
}
