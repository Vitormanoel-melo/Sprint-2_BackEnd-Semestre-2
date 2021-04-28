using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("TiposHabilidade")]
    public class TiposHabilidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoHabilidade { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        [Required(ErrorMessage = "A descrição do tipo de habilidade é obrigatória!")]
        public string titulo { get; set; }
    }
}
