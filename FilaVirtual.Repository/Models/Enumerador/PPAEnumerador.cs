using System.ComponentModel;

namespace FilaVirtual.Business.Models.Enumerador
{
	public class PPAEnumerador
	{
		public enum EPermissoes
        {
			[Description("Administrador")]
			Administrador,
            [Description("AdministradorRelatorios")]
            AdministradorRelatorios
        }

        public enum ELogAtividade
        {
            [Description("Cadastro")]
            Cadastro,
            [Description("Acesso")]
            Acesso,
            [Description("Acesso Falho")]
            AcessoFalho,
            [Description("Acesso Bloqueado")]
            AcessoBloqueado,

        }

		public enum ELogAtividadeRelatorio
		{
			[Description("Acesso")]
			Acesso,
			[Description("Acesso Falho")]
			AcessoFalho,
			[Description("Download Relatorio")]
			DownloadRelatorio,
		}
	}
}
