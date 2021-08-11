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
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada   = BuscarPorId(id);
            Habilidade habilidadeNome      = ctx.Habilidades.FirstOrDefault(h => h.nome == habilidadeAtualizada.nome);

            if (habilidadeAtualizada.nome != null)
            {
                if (habilidadeNome == null)
                {
                    habilidadeBuscada.nome = habilidadeAtualizada.nome;
                }
            }

            if (ctx.TiposHabilidade.Find(habilidadeAtualizada.idTipoHabilidade) != null)
            {
                habilidadeBuscada.idTipoHabilidade = habilidadeAtualizada.idTipoHabilidade;
            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma habilidade pelo id
        /// </summary>
        /// <param name="id">Id da habilidade que será buscada</param>
        /// <returns>Uma habilidade encontrada</returns>
        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.Include(hab => hab.tipoHabilidade).FirstOrDefault(h => h.idHabilidade == id);
        }

        /// <summary>
        /// Busca uma habilidade pelo seu nome
        /// </summary>
        /// <param name="nome">nome da habilidade buscada</param>
        /// <returns>Uma habilidade buscada ou null</returns>
        public Habilidade BuscarPorNome(string nome)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.FirstOrDefault(h => h.nome == nome);

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
        public void Cadastrar(Habilidade novaHabilidade)
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
            Habilidade habilidadeBuscada = BuscarPorId(id);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.Include(h => h.tipoHabilidade).ToList();
        }

    }
}
