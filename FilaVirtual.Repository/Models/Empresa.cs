using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilaVirtual.Business.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }

        public string NomeSocial { get; set; }

        public int CNPJ { get; set; }

        public int CoordX { get; set; }
        public int CoordY { get; set; }

        [ForeignKey(nameof(AspNetUsersID))]
        public int AspNetUsersID { get; set; }
    }
}
