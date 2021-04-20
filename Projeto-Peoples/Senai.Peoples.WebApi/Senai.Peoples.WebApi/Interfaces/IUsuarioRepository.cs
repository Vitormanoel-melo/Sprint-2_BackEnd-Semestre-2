using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Método que cadastra um usuário
        /// </summary>
        /// <param name="usuario">Objeto UsuarioDomain que será cadastrado</param>
        void Cadastrar(UsuarioDomain usuario);


        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<UsuarioDomain> Listar();


        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>Um objeto UsuarioDomainEncontrado ou null</returns>
        UsuarioDomain BuscarPorId(int id);


        /// <summary>
        /// Atualiza um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuario">Objeto UsuarioDomain com as novas informações</param>
        void Atualizar(int id, UsuarioDomain usuario);


        /// <summary>
        /// Deleta um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuario que será deletado</param>
        void Deletar(int id);
    }
}
