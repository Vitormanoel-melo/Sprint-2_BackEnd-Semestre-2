using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.gufi.webApi.Domains;
using senai.gufi.webApi.Intefaces;
using senai.gufi.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.gufi.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private IPresencaRepository _presencaRepository { get; set; }

        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
        }

        /// <summary>
        /// Lista todas as preseças de um determinado usuário
        /// </summary>
        /// <returns>Uma lista de presenças e um status code 200 - Ok </returns>
        /// dominio/api/presencas/minhas
        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do id do usuário que está logado
                int idUsuario = Convert.ToInt32( HttpContext.User.Claims.First( c => c.Type == JwtRegisteredClaimNames.Jti).Value );

                // Retorna um status code 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_presencaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception exception)
            {
                // retorna a resposta requisição 400 - Bad Request e a exception
                return BadRequest(new 
                { 
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    exception
                });
            }
        }

        /// <summary>
        /// Inscreve o usuário logado em um evento
        /// </summary>
        /// <param name="idEvento">ID do evento que o usuário irá se inscrever</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost("inscricao/{idEvento}")]
        public IActionResult Inscrever(int idEvento)
        {
            try
            {
                Presenca inscricao = new Presenca
                {
                    IdEvento    = idEvento,
                    IdUsuario   = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),
                    Situacao    = "Não confirmada"
                };

                _presencaRepository.Inscrever(inscricao);

                return StatusCode(201);
            }
            catch (Exception exception)
            {
                // retorna a resposta requisição 400 - Bad Request e a exception
                return BadRequest(new
                {
                    mensagem = "Não é possível se inscrever se o usuário não estiver logado!",
                    exception
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult UpdateSituation(int id, Presenca status)
        {
            try
            {
                _presencaRepository.AprovarRecusar(id, status.Situacao);

                return StatusCode(204);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
