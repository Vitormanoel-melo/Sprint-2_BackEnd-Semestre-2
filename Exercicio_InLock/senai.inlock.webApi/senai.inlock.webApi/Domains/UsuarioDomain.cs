using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        public string email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string senha { get; set; }


        [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
        public int idTipoUsuario { get; set; }
    }
}
