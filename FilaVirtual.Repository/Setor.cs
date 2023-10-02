using System;
using System.Collections.Generic;

namespace FilaVirtual.Business
{
    public partial class Setor
    {
        public Setor()
        {
            Caixas = new HashSet<Caixa>();
        }

        public int SetorId { get; set; }
        public string Nome { get; set; } = null!;
        public int LojaId { get; set; }

        public virtual Loja Loja { get; set; } = null!;
        public virtual ICollection<Caixa> Caixas { get; set; }
    }
}
