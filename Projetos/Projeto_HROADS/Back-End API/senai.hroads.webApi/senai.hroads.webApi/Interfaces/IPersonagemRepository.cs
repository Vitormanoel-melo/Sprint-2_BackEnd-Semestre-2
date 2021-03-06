using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        List<Personagem> Listar();
        
        /// <summary>
        /// Busca um personagem pelo id
        /// </summary>
        /// <param name="id">Id do personagem que será buscado</param>
        /// <returns>Um Personagem encontrado</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com as informações para cadastro</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">Id do usuário que será cadastrado</param>
        /// <param name="personagemAtualizado">Objeto personagemAtualizado com as novas informações</param>
        void Atualizar(int id, Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um personagem pelo id
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um personagem pelo nome
        /// </summary>
        /// <param name="nome">Nome do personagem que será buscado</param>
        /// <returns>Um personagem encontrada</returns>
        Personagem BuscarPorNome(string nome);
    }
}
