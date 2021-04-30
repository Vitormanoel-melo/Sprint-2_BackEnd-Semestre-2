using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um tipoUsuariio existente
        /// </summary>
        /// <param name="id">Id do tipoUsuario que será atualizado</param>
        /// <param name="tipoAtualizado">Objeto tipoAtualizado com as novas informações</param>
        public void Atualizar(int id, TiposUsuario tipoAtualizado)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuario.Find(id);

            if (tipoAtualizado.titulo != null)
            {
                tipoBuscado.titulo = tipoAtualizado.titulo;
            }

            ctx.TiposUsuario.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo usuario pelo id
        /// </summary>
        /// <param name="id">Id do tipoUsuario que será buscado</param>
        /// <returns>Um tipoUsuario encontrado ou null</returns>
        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuario.FirstOrDefault(tipo => tipo.idTipoUsuario == id);
        }


        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo que será cadastrado</param>
        public void Cadastrar(TiposUsuario novoTipo)
        {
            ctx.TiposUsuario.Add(novoTipo);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipoUsuario existente
        /// </summary>
        /// <param name="id">Id do tipoUsuario que será deletado</param>
        public void Deletar(int id)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuario.Find(id);

            ctx.TiposUsuario.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos usuario
        /// </summary>
        /// <returns>Uma lista de tipos usuario</returns>
        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }
    }
}