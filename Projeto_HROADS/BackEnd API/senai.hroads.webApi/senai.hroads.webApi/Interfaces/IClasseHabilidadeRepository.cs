using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as classes com suas habilidades
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        List<ClassesHabilidade> Listar();

        /// <summary>
        /// Busca uma classe com suas habilidade
        /// </summary>
        /// <param name="id">Id da classe habilidade que será buscada</param>
        /// <returns>Uma classe habilidade encontrada</returns>
        ClassesHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova classe habilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto novaClasseHabilidade com as informações para cadastro</param>
        void Cadastrar(ClassesHabilidade novaClasseHabilidade);

        /// <summary>
        /// Atualiza uma classe habilidade existente
        /// </summary>
        /// <param name="id">Id da classe habilidade que será atualizada</param>
        /// <param name="cHablidadeAtualizada">Objeto cHabilidadeAtualizada com as novas informações</param>
        void Atualizar(int id, ClassesHabilidade cHablidadeAtualizada);

        /// <summary>
        /// Deleta uma classe habilidade existente
        /// </summary>
        /// <param name="id">Id da classe habilidade que será deletada</param>
        void Deletar(int id);
    }
}
