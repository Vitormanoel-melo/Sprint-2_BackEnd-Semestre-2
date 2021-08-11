using senai_inlock_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi_DBFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        List<Estudio> Listar();

        /// <summary>
        /// Busca um estúdio através de seu id
        /// </summary>
        /// <param name="id">id do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado</returns>
        Estudio BuscarPorId(int id);

        /// <summary>
        /// Cadastra um estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        void Cadastrar(Estudio novoEstudio);

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        void Atualizar(int id, Estudio estudioAtualizado);

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os estúdios com a lista de jogos
        /// </summary>
        /// <returns>Lista de estúdios com a lista de jogos</returns>
        List<Estudio> ListarJogos();

    }
}
