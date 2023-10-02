using System.ComponentModel.DataAnnotations;

namespace FilaVirtual.Business.Models
{
	public abstract class Entity
	{
		public DateTime? DataHoraInclusao { get; set; }
		public DateTime? DataHoraAlteracao { get; set; }
		[StringLength(200)]
		public string? UsuarioInclusao { get; set; }
		[StringLength(200)]
		public string? UsuarioAlteracao { get; set; }
		public abstract void SetId(int id);
	}
}
