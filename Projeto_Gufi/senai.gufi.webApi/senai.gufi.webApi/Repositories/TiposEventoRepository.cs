using senai.gufi.webApi.Contexts;
using senai.gufi.webApi.Domains;
using senai.gufi.webApi.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.gufi.webApi.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, TiposEvento tipoEventoAtualizado)
        {
            TiposEvento tipoEventoBuscado = BuscarPorId(id);

            if (tipoEventoAtualizado.TituloTipoEvento != null) 
            {
                tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
            }

            ctx.TiposEventos.Update(tipoEventoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de evento através do ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento encontrado</returns>
        public TiposEvento BuscarPorId(int id)
        {
            return ctx.TiposEventos.FirstOrDefault(te => te.IdTipoEvento == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(TiposEvento novoTipoEvento)
        {
            ctx.TiposEventos.Add(novoTipoEvento);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        public void Deletar(int id)
        {
            ctx.TiposEventos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Uma lista de tipos de eventos</returns>
        public List<TiposEvento> Listar()
        {
            return ctx.TiposEventos.ToList();
        }
    }
}
