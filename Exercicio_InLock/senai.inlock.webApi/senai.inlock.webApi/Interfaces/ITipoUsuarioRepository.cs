using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Listar todos os tipos de usuario
        /// </summary>
        /// <returns>Lista de tipos de usuário</returns>
        List<TipoUsuarioDomain> Listar();


        /// <summary>
        /// Busca um tipoUsuario pelo id
        /// </summary>
        /// <param name="id">id do tipo que será buscado</param>
        /// <returns>Objeto TipoUsuarioDomain com as informações</returns>
        TipoUsuarioDomain BuscarPorId(int id);
    }
}
