using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        List<Classe> Listar();

        /// <summary>
        /// Busca uma classe pelo id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>Um objeto Classe encontrado</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que será cadastrado</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será atualizada </param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        /// <returns>true se atualizar ou false se não atualizar</returns>
        bool Atualizar(int id, Classe classeAtualizada);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Busca uma classe pelo nome
        /// </summary>
        /// <param name="nome">Nome da classe que será buscada</param>
        /// <returns>Uma classe encontrada</returns>
        Classe BuscarPorNome(string nome);
    }
}
