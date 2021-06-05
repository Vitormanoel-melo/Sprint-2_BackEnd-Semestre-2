using senai.gufi.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.gufi.webApi.Intefaces
{
    interface IPresencaRepository
    {
        /// <summary>
        /// Lista todas os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">Id do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Presenca> ListarMinhas(int id);

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscricao</param>
        void Inscrever(Presenca inscricao);
        
        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá sua situação atualizada</param>
        /// <param name="status">Parâmetro que atualiza a situação da presença para 1 - Confirmada, 0 - Recusada, 2 - Não confirmada</param>
        void AprovarRecusar(int id, string status);
    }
}
