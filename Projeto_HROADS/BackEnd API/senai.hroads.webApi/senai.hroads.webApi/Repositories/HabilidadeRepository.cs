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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        public bool Atualizar(int id, Habilidades habilidadeAtualizada)
        {
            Habilidades habilidadeBuscada   = ctx.Habilidades.FirstOrDefault(h => h.idHabilidade == id);
            Habilidades habilidadeNome      = ctx.Habilidades.FirstOrDefault(h => h.nome == habilidadeAtualizada.nome);

            if (habilidadeAtualizada.nome != null && habilidadeNome == null)
            {
                habilidadeBuscada.nome = habilidadeAtualizada.nome;

                if (ctx.TiposHabilidade.Find(habilidadeAtualizada.idTipoHabilidade) != null)
                {
                    habilidadeBuscada.idTipoHabilidade = habilidadeAtualizada.idTipoHabilidade;
                }

                ctx.Habilidades.Update(habilidadeBuscada);

                ctx.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Busca uma habilidade pelo id
        /// </summary>
        /// <param name="id">Id da habilidade que será buscada</param>
        /// <returns>Uma habilidade encontrada</returns>
        public Habilidades BuscarPorId(int id)
        {
            return ctx.Habilidades.Include(hab => hab.tipoHabilidade).FirstOrDefault(h => h.idHabilidade == id);
        }

        /// <summary>
        /// Busca uma habilidade pelo seu nome
        /// </summary>
        /// <param name="nome">nome da habilidade buscada</param>
        /// <returns>Uma habilidade buscada ou null</returns>
        public Habilidades BuscarPorNome(string nome)
        {
            Habilidades habilidadeBuscada = ctx.Habilidades.FirstOrDefault(h => h.nome == nome);

            if (habilidadeBuscada != null)
            {
                return habilidadeBuscada;
            }

            return null;
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com as informações para cadastro</param>
        public void Cadastrar(Habilidades novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será deletada</param>
        public void Deletar(int id)
        {
            Habilidades habilidadeBuscada = ctx.Habilidades.Find(id);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        public List<Habilidades> Listar()
        {
            return ctx.Habilidades.Include(h => h.tipoHabilidade).ToList();
        }

    }
}
