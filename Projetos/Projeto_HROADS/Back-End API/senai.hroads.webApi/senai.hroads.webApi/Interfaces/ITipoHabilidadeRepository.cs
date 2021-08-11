using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os tipos de habilidade
        /// </summary>
        /// <returns>Uma lista de TiposHabilidade</returns>
        List<TipoHabilidadeDomain> Listar();

        /// <summary>
        /// Busca um tipo de habilidade existente
        /// </summary>
        /// <param name="id">Id do tipo habilidade que será buscado</param>
        /// <returns>Um objeto TiposHabilidade encontrado</returns>
        TipoHabilidadeDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo que será cadastrado</param>
        void Cadastrar(TipoHabilidadeDomain novoTipo);

        /// <summary>
        /// Atualiza um tipo de habilidade existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoAtualizado"></param>
        /// <returns>true se atualizar ou false se não atualizar</returns>
        bool Atualizar(int id, TipoHabilidadeDomain tipoAtualizado);

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um tipo de habilidade pelo título dela
        /// </summary>
        /// <param name="titulo">Título da habilidade que será buscada</param>
        /// <returns>Um tipo de habilidade encontrada</returns>
        TipoHabilidadeDomain BuscarPorTitulo(string titulo);
    }
}
