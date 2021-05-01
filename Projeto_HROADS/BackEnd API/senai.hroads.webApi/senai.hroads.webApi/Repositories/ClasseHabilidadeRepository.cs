using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma classe habilidade existente
        /// </summary>
        /// <param name="id">Id da classe habilidade que será atualizada</param>
        /// <param name="cHablidadeAtualizada">Objeto cHabilidadeAtualizada com as novas informações</param>
        public void Atualizar(int id, ClassesHabilidade cHablidadeAtualizada)
        {
            ClassesHabilidade classeHabilidade = BuscarPorId(id);

            if (ctx.Classes.Find(cHablidadeAtualizada.idClasse) != null)
            {
                classeHabilidade.idClasse = cHablidadeAtualizada.idClasse;
            }

            if (ctx.Habilidades.Find(cHablidadeAtualizada.idHabilidade) != null)
            {
                classeHabilidade.idHabilidade = cHablidadeAtualizada.idHabilidade;
            }

            ctx.ClasseHabilidade.Update(classeHabilidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma classe com suas habilidade
        /// </summary>
        /// <param name="id">Id da classe habilidade que será buscada</param>
        /// <returns>Uma classe habilidade encontrada</returns>
        public ClassesHabilidade BuscarPorId(int id)
        {
            return ctx.ClasseHabilidade.FirstOrDefault(c => c.idClasseHabilidade == id);
        }

        /// <summary>
        /// Cadastra uma nova classe habilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto novaClasseHabilidade com as informações para cadastro</param>
        public void Cadastrar(ClassesHabilidade novaClasseHabilidade)
        {
            ctx.ClasseHabilidade.Add(novaClasseHabilidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma classe habilidade existente
        /// </summary>
        /// <param name="id">Id da classe habilidade que será deletada</param>
        public void Deletar(int id)
        {
            ClassesHabilidade ClasseHabilidade = BuscarPorId(id);

            ctx.ClasseHabilidade.Remove(ClasseHabilidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as classes com suas habilidades
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        public List<ClassesHabilidade> Listar()
        {
            return ctx.ClasseHabilidade
                .Include(ch => ch.classe)
                .Include(ch => ch.habilidade)
                .ToList();
        }

    }
}
