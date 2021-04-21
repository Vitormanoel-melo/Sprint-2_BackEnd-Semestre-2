using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ILoginRepository
    {
        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">email do usuário buscado</param>
        /// <param name="senha">senha do usuário buscado</param>
        /// <returns>Usuário buscado</returns>
        UsuarioDomain BuscarEmailSenha(string email, string senha);
    }
}
