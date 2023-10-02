using System;
using System.Collections.Generic;

namespace FilaVirtual.Business
{
    public partial class Caixa
    {
        public int CaixaId { get; set; }
        public int Ativo { get; set; }
        public int? TipoAtendimentoId { get; set; }
        public string? TempoMedioAtendimento { get; set; }
        public string? TempoMedioItem { get; set; }
        public int SenhaId { get; set; }
        public int SetorId { get; set; }

        public virtual Senha Senha { get; set; } = null!;
        public virtual Setor Setor { get; set; } = null!;
    }
}
