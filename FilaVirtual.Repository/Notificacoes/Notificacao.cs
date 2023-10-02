using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilaVirtual.Business.Notificacoes
{
    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            this.Mensagem = mensagem;
        }
        public string Mensagem;
    }
}
