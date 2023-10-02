using System;
using System.Collections.Generic;

namespace FilaVirtual.Business
{
    public partial class Loja
    {
        public Loja()
        {
            Setors = new HashSet<Setor>();
        }

        public int LojaId { get; set; }
        public string NomeSocial { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public int AspNetUsersId { get; set; }
        public int EnderecoId { get; set; }
        public int FilialId { get; set; }

        public virtual Endereco Endereco { get; set; } = null!;
        public virtual ICollection<Setor> Setors { get; set; }
    }
}
