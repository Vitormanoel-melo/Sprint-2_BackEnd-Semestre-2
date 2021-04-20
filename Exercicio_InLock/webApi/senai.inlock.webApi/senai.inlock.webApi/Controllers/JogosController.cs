using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {

        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }


        /// <summary>
        /// Endpoint que lista todos os jogos
        /// </summary>
        /// <returns>Status code 200 - Ok e uma lista de jogos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> lista = _jogoRepository.Listar();

            return Ok(lista);
        }


        /// <summary>
        /// Endpoint que busca um jogo pelo id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>Objeto jogo encontrado</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            JogoDomain jogo = _jogoRepository.BuscarPorId(id);

            if (jogo != null)
            {

                return Ok(jogo);
            }

            return NotFound("Jogo não encontrado");
        }


        /// <summary>
        /// Cadastra um jogo
        /// </summary>
        /// <param name="jogo">Jogo que será cadastrado</param>
        /// <returns>Status Code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain jogo)
        {
            try
            {
                _jogoRepository.Cadastrar(jogo);

                return StatusCode(201);
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }

        }



        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        /// <returns>Status Code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Deletar(id);

                    return StatusCode(204);
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }

            }

            return NotFound("Usuário não encontrado para deletar!");
        }


        /// <summary>
        /// Atualiza um jogo pelo id
        /// </summary>
        /// <param name="id">id do jogo que será atualizado</param>
        /// <param name="jogo">Objeto jogo com as novas informações</param>
        /// <returns>Status Code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, JogoDomain jogo)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(id, jogo);

                    return Ok();
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }

            }

            return NotFound("Usuário não encontrado");
        }


    }
}
