using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estúios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        List<EstudioDomain> Listar();

        /// <summary>
        /// Busca um estudio pelo id
        /// </summary>
        /// <param name="id">id do estudio que será buscado</param>
        /// <returns>Um objeto EstudioDomain ou null</returns>
        EstudioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);


        /// <summary>
        /// Deleta um estúdio pelo seu id
        /// </summary>
        /// <param name="id">id do estúdio que será deletado</param>
        void Deletar(int id);


        /// <summary>
        /// Atualiza um estúdio pelo seu id
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <param name="estudio">Objeto estudio com as novas informações</param>
        void Atualizar(int id, EstudioDomain estudio);

    }
}
