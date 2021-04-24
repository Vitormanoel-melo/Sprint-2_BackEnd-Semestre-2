using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface ILoginRepository
    {
        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">Email do usuário que será buscado</param>
        /// <param name="senha">Senha do usuário que será buscado</param>
        /// <returns>Objeto UsuarioDomain que foi encontrado</returns>
        UsuarioDomain Logar(string email, string senha);

        /// <summary>
        /// Busca uma permissão existente
        /// </summary>
        /// <param name="id">id da permissão que será encontrada</param>
        /// <returns>uma permissão ou null</returns>
        string BuscarPermissao(int id);
    }
}
