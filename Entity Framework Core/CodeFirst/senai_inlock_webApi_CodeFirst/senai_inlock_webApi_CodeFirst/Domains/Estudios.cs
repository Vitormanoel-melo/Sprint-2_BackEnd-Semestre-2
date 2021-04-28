using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_inlock_webApi_CodeFirst.Domains
{
    [Table("Estudios")]
    public class Estudios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstudio { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string nomeEstudio { get; set; }
        
        // propriedade que vai ser utilizada apenas pela API, não vai para o banco
        public List<Jogos> jogos { get; set; }
    }
}
