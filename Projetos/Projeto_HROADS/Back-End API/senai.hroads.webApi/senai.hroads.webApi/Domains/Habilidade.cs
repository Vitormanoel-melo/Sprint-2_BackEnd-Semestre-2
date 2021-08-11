using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("Habilidades")]
    public class Habilidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idHabilidade { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O nome da habilidade é obrigatório!")]
        public string nome { get; set; }

        public int idTipoHabilidade { get; set; }

        [ForeignKey("idTipoHabilidade")]
        public TipoHabilidadeDomain tipoHabilidade { get; set; }
    }
}
