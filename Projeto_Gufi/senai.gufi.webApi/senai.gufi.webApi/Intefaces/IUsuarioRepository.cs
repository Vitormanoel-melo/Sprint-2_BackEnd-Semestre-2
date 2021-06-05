using senai.gufi.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.gufi.webApi.Intefaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="email">email do usuário que será logado</param>
        /// <param name="senha">senha do usuário que será logado</param>
        /// <returns>Um usuário encontrado</returns>
        Usuario Login(string email, string senha);
    }
}
