using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("Personagens")]
    public class Personagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPersonagem { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O nome do personagem é obrigatório!")]
        public string nome { get; set; }


        [Required(ErrorMessage = "A vida máxima do personagem é obrigatória!")]
        public int MaxVida { get; set; }


        [Required(ErrorMessage = "A mana máxima do personagem é obrigatória!")]
        public int MaxMana { get; set; }


        [Column(TypeName = "DATE")]
        public DateTime dataAtualização { get; set; }


        [Column(TypeName = "DATE")]
        public DateTime dataCriacao { get; set; }

        [Required(ErrorMessage = "O personagem precisa ter uma classe")]
        public int idClasse { get; set; }

        public int idUsuario { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario usuario { get; set; }

        [ForeignKey("idClasse")]
        public Classe classe { get; set; }
    }
}
