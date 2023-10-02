using System;
using System.Collections.Generic;

namespace FilaVirtual.Business
{
    public partial class Senha
    {
        public Senha()
        {
            Caixas = new HashSet<Caixa>();
        }

        public int SenhaId { get; set; }
        public string TempoMedioEspera { get; set; } = null!;
        public string Posicao { get; set; } = null!;
        public string? DataHoraInicioAtendimento { get; set; }
        public string? DataHoraFimAtendimento { get; set; }
        public int ClienteId { get; set; }
        public int? CarrinhoId { get; set; }

        public virtual Carrinho? Carrinho { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual ICollection<Caixa> Caixas { get; set; }
    }
}
