using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FilaVirtual.Business.Models;

[Table(nameof(AspNetUsers))]
public partial class AspNetUsers : IdentityUser //Tabela AspnetUsers
{
    public int AspNetUsersID { get; set; }
    [StringLength(80)]
    public string Nome { get; set; } = null!;

    [StringLength(11)]
    public string CPF { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataHoraInclusao { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime DataHoraAlteracao { get; set; }
}
