using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string nome { get; set; }


        [Required(ErrorMessage = "O sobrenome é obrigatório!")]
        public string sobrenome { get; set; }


        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        public string email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = ("A senha deve ter de 8 a 20 caracteres!"))]
        public string senha { get; set; }


        [Required(ErrorMessage = "A permissão é obrigatória!")]
        public int permissao { get; set; }

        public TipoUsuarioDomain tipo { get; set; }
    }
}
