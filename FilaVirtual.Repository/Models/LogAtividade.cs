using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace	FilaVirtual.Business.Models
{
	[Table(nameof(LogAtividade))]
	public partial class LogAtividade : Entity
	{
		[Key]
		public int LogAtividadeID { get; set; }
		public int AspNetUserID { get; set; }
		[StringLength(50)]
		public string TipoAtividade { get; set; }
		[StringLength(100)]
		public string Complemento { get; set; }
		[InverseProperty(nameof(LogAtividade) + "s")]
		public virtual AspNetUsers AspNetUser { get; set; }
		[StringLength(20)]
		public virtual string? Ip { get; set; }
		public override void SetId(int id)
		{
            LogAtividadeID = id;
		}
	}
}
