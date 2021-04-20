using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de Usuario
        /// </summary>
        /// <returns>Lista com todos os tipos</returns>
        List<TipoUsuarioDomain> Listar();


        /// <summary>
        /// Busca um tipo de usuario pelo id
        /// </summary>
        /// <param name="id">id do tipo de usuário que será buscado</param>
        /// <returns>Um objeto TipoUsuarioDomain ou null</returns>
        TipoUsuarioDomain BuscarPorId(int id);


        /// <summary>
        /// Atualiza um tipo de usuario
        /// </summary>
        /// <param name="id">id do tipo que será atualizado</param>
        /// <param name="tipoUsuario">Objeto TipoUsuarioDomain com as novas informações</param>
        void Atualizar(int id, TipoUsuarioDomain tipoUsuario);


        /// <summary>
        /// Deleta um tipo de usuário pelo id
        /// </summary>
        /// <param name="id">id do tipo de usuario que será deletado</param>
        void Deletar(int id);
    }
}
