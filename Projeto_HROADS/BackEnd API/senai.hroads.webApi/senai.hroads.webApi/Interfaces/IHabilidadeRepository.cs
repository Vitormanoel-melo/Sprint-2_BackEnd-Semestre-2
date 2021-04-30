using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma habilidade pelo id
        /// </summary>
        /// <param name="id">Id da habilidade que será buscada</param>
        /// <returns>Uma habilidade encontrada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com as informações para cadastro</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        void Atualizar(int id, Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Busca uma habilidade pelo seu nome
        /// </summary>
        /// <param name="nome">nome da habilidade buscada</param>
        /// <returns>Uma habilidade buscada ou null</returns>
        Habilidade BuscarPorNome(string nome);
    }
}
