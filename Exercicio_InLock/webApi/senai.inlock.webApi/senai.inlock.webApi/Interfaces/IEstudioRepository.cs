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

        void Deletar(int id);

        void Atualizar(int id, EstudioDomain estudio);

        List<JogoDomain> ListarJogos(int id);
    }
}
