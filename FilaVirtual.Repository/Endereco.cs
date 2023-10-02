using System;
using System.Collections.Generic;

namespace FilaVirtual.Business
{
    public partial class Endereco
    {
        public Endereco()
        {
            Lojas = new HashSet<Loja>();
        }

        public int EnderecoId { get; set; }
        public string CoordLat { get; set; } = null!;
        public string CoordLong { get; set; } = null!;

        public virtual ICollection<Loja> Lojas { get; set; }
    }
}
