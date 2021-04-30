using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        public string nome { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O sobrenome do usuário é obrigatório!")]
        public string sobrenome { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        public string email { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha deve conter de 8 a 30 caracteres")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }

        [ForeignKey("idTipoUsuario")]
        public TiposUsuario tipoUsuario { get; set; }

        public List<Personagem> personagens { get; set; }
    }
}
