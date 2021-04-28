using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        /// <returns>true se atualizar ou false se não atualizar</returns>
        public bool Atualizar(int id, Classes classeAtualizada)
        {
            // Busca uma classe pelo id passado como parâmetro
            Classes classeBuscada = ctx.Classes.FirstOrDefault(c => c.idClasse == id);

            // Busca uma classe pelo nomeClasse da classeAtualizada
            Classes classeBuscadaNome   = ctx.Classes.FirstOrDefault(c => c.nomeClasse == classeAtualizada.nomeClasse);

            // Se o nomeClasse da classeAtualizada for diferente de null e se a classeBuscadaNome for igual a null
            // então executa 
            if (classeAtualizada.nomeClasse != null && classeBuscadaNome == null)
            {
                classeBuscada.nomeClasse = classeAtualizada.nomeClasse;

                ctx.Classes.Update(classeBuscada);

                ctx.SaveChanges();

                return true;
            }

            return false;
        }


        /// <summary>
        /// Busca uma classe pelo id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>Um objeto Classe encontrado</returns>
        public Classes BuscarPorId(int id)
        {
            return ctx.Classes.Find(id);
        }

        /// <summary>
        /// Busca uma classe pelo nome
        /// </summary>
        /// <param name="nome">Nome da classe que será buscada</param>
        /// <returns>Uma classe encontrada</returns>
        public Classes BuscarPorNome(string nome)
        {
            Classes classeBuscada = ctx.Classes.FirstOrDefault(c => c.nomeClasse == nome);

            if (classeBuscada != null)
            {
                return classeBuscada;
            }

            return null;
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que será cadastrado</param>
        public void Cadastrar(Classes novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será deletada</param>
        public void Deletar(int id)
        {
            Classes classeBuscada = ctx.Classes.Find(id);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        public List<Classes> Listar()
        {
            return ctx.Classes.ToList();
        }

    }
}
