using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class LoginDomain
    {
        [Required(ErrorMessage = "O E-mail é obrigatório para fazer o login!")]
        public string email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória para fazer o login!")]
        public string senha { get; set; }
    }
}
