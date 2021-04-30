using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuarios> Listar();

        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>Um usuário encontrado ou null</returns>
        Usuarios BuscarPorId(int id);

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(Usuarios novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int id, Usuarios usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um usuário pelo e-mail
        /// </summary>
        /// <param name="email">E-mail do usuário que será buscado</param>
        /// <returns>Um usuário encontrado</returns>
        Usuarios BuscarPorEmail(string email);

        /// <summary>
        /// Busca um usuário existente pelo email e senha
        /// </summary>
        /// <param name="email">E-mail do usuário que será buscado</param>
        /// <param name="senha">Senha do usuário que será buscado</param>
        /// <returns>Um usuário encontrado</returns>
        Usuarios BuscarPorEmailSenha(string email, string senha);

        string BuscarPermissao(int id);
    }
}
