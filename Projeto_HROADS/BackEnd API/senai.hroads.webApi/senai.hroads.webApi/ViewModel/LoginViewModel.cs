using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O E-mail para login é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        public string senha { get; set; }
    }
}
