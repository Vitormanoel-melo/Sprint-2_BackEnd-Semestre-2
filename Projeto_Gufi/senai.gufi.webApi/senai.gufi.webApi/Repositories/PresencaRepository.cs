using Microsoft.EntityFrameworkCore;
using senai.gufi.webApi.Contexts;
using senai.gufi.webApi.Domains;
using senai.gufi.webApi.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.gufi.webApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Lista todas os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">Id do usuário que participa dos eventos listados</param>
        /// <param name="status">Parâmetro que atualiza a situação da presença para para 1 - Confirmada, 0 - Recusada, 2 - Não confirmada</param>    
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        public void AprovarRecusar(int id, string status)
        {
            Presenca presencaBuscada = ctx.Presencas
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdEventoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id);

            switch (status)
            {
                case "0":
                    presencaBuscada.Situacao = "Recusada";
                    break;

                case "1":
                    presencaBuscada.Situacao = "Confirmada";
                    break;

                case "2":
                    presencaBuscada.Situacao = "Não confirmada";
                    break;

                default:
                    presencaBuscada.Situacao = presencaBuscada.Situacao;
                    break;
            }

            ctx.Presencas.Update(presencaBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscricao</param>
        public void Inscrever(Presenca inscricao)
        {
            inscricao.Situacao = "Não confirmada";

            ctx.Presencas.Add(inscricao);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">Id do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        public List<Presenca> ListarMinhas(int id)
        {
            return ctx.Presencas
                .Include(p => p.IdEventoNavigation)
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                .Where(p => p.IdUsuario == id)
                .ToList();    
        }

    }
}
