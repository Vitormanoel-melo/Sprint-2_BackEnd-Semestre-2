using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um tipo de habilidade existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoAtualizado"></param>
        /// <returns>true se atualizar ou false se não atualizar</returns>
        public bool Atualizar(int id, TiposHabilidade tipoAtualizado)
        {
            TiposHabilidade tipoBuscado         = ctx.TiposHabilidade.Find(id);
            TiposHabilidade tipoBuscadoTitulo   = ctx.TiposHabilidade.FirstOrDefault(t => t.titulo == tipoAtualizado.titulo);

            if (tipoAtualizado.titulo != null && tipoBuscadoTitulo == null)
            {
                tipoBuscado.titulo = tipoAtualizado.titulo;

                ctx.TiposHabilidade.Update(tipoBuscado);

                ctx.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Busca um tipo de habilidade existente
        /// </summary>
        /// <param name="id">Id do tipo habilidade que será buscado</param>
        /// <returns>Um objeto TiposHabilidade encontrado</returns>
        public TiposHabilidade BuscarPorId(int id)
        {
            return ctx.TiposHabilidade.FirstOrDefault(t => t.idTipoHabilidade == id);
        }

        /// <summary>
        /// Busca um tipo de habilidade pelo título dela
        /// </summary>
        /// <param name="titulo">Título da habilidade que será buscada</param>
        /// <returns>Um tipo de habilidade encontrada</returns>
        public TiposHabilidade BuscarPorTitulo(string titulo)
        {
            return ctx.TiposHabilidade.FirstOrDefault(t => t.titulo == titulo);
        }

        /// <summary>
        /// Cadastra um tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo que será cadastrado</param>
        public void Cadastrar(TiposHabilidade novoTipo)
        {
            ctx.TiposHabilidade.Add(novoTipo);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será deletado</param>
        public void Deletar(int id)
        {
            ctx.TiposHabilidade.Remove(ctx.TiposHabilidade.Find(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de habilidade
        /// </summary>
        /// <returns>Uma lista de TiposHabilidade</returns>
        public List<TiposHabilidade> Listar()
        {
            return ctx.TiposHabilidade.ToList();
        }
    }
}
