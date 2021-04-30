using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos usuario
        /// </summary>
        /// <returns>Uma lista de tipos usuario</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca um tipo usuario pelo id
        /// </summary>
        /// <param name="id">Id do tipoUsuario que será buscado</param>
        /// <returns>Um tipoUsuario encontrado ou null</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo que será cadastrado</param>
        void Cadastrar(TiposUsuario novoTipo);

        /// <summary>
        /// Atualiza um tipoUsuariio existente
        /// </summary>
        /// <param name="id">Id do tipoUsuario que será atualizado</param>
        /// <param name="tipoAtualizado">Objeto tipoAtualizado com as novas informações</param>
        void Atualizar(int id, TiposUsuario tipoAtualizado);

        /// <summary>
        /// Deleta um tipoUsuario existente
        /// </summary>
        /// <param name="id">Id do tipoUsuario que será deletado</param>
        void Deletar(int id);
    }
}
