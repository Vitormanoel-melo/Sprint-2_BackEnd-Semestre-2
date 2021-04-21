using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class LoginDomain
    {
        [Required(ErrorMessage = "O E-mail é obrigatório!")]
        public string email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string senha { get; set; }
    }
}
