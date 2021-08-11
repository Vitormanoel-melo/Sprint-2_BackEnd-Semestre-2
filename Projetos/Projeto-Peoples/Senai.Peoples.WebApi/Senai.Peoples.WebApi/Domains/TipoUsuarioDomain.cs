using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class TipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo descrição do tipo de usuário não pode ser vazio")]
        public string descricao { get; set; }

    }
}
