using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.gufi.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário deve ser informado!")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo E-mail deve ser informado!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha deve ser informado!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter de 5 a 30 caracteres!")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
