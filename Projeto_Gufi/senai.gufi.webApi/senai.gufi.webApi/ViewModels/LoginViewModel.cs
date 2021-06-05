using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.gufi.webApi.ViewModels
{
    /// <summary>
    /// Classe responsável pelo modelo de login
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string senha { get; set; }
    }
}
