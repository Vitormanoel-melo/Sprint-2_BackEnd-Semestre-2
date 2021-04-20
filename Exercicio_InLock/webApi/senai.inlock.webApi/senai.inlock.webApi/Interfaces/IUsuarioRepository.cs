using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        List<UsuarioDomain> Listar();


        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>Objeto UsuarioDomain encontrado</returns>
        UsuarioDomain BuscarPorId(int id);


        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuario">Objeto UsuarioDomain que será cadastrado</param>
        void Cadastrar(UsuarioDomain usuario);


        /// <summary>
        /// Atualiza um usuário peo seu id
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuario">Objeto usuário com as novas informações</param>
        void Atualizar(int id, UsuarioDomain usuario);


        /// <summary>
        /// Deleta um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
        void Deletar(int id);
    }
}
