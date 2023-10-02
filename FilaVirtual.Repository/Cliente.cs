using System;
using System.Collections.Generic;

namespace FilaVirtual.Business
{
    public partial class Cliente
    {
        public Cliente()
        {
            Senhas = new HashSet<Senha>();
        }

        public int ClienteId { get; set; }
        public int LojaId { get; set; }
        public bool Ativo { get; set; }
        public int AspNetUsersId { get; set; }

        public virtual ICollection<Senha> Senhas { get; set; }
    }
}
