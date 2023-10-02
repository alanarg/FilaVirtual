using System;
using System.Collections.Generic;

namespace FilaVirtual.Business
{
    public partial class TipoAtendimento
    {
        public int? TipoAtendimentoId { get; set; }
        public string? Descricao { get; set; }
        public string? TempoMedioAtendimentoDefault { get; set; }
    }
}
