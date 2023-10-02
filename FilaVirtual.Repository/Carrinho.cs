using System;
using System.Collections.Generic;

namespace FilaVirtual.Business
{
    public partial class Carrinho
    {
        public Carrinho()
        {
            Senhas = new HashSet<Senha>();
        }

        public int CarrinhoId { get; set; }
        public string QtdReal { get; set; } = null!;
        public int QtdMediaItems { get; set; }
        public int ClienteId { get; set; }

        public virtual ICollection<Senha> Senhas { get; set; }
    }
}
