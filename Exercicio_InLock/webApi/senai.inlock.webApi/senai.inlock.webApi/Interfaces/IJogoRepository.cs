using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Método que lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<JogoDomain> Listar();


        /// <summary>
        /// Busca um jogo pelo id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>Objeto jogo buscado</returns>
        JogoDomain BuscarPorId(int id);


        /// <summary>
        /// Método que cadastra um jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);


        /// <summary>
        /// Atualiza um jogo pelo id
        /// </summary>
        /// <param name="id">id do jogo que será atualizado</param>
        /// <param name="jogo">Objeto com as novas informações</param>
        void Atualizar(int id, JogoDomain jogo);


        /// <summary>
        /// Deleta um jogo pelo id
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        void Deletar(int id);
    }
}
