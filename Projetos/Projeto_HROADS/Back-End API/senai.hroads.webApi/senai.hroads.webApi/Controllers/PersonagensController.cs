using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using senai.hroads.webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRespository { get; set; }

        public PersonagensController()
        {
            _personagemRespository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_personagemRespository.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Busca um personagem existente
        /// </summary>
        /// <param name="id">Id do personagem que será buscado</param>
        /// <returns>Um Status Code 200 - Ok com um personagem encontrado</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Personagem personagemBuscado = _personagemRespository.BuscarPorId(id);

                if (personagemBuscado != null)
                {
                    return Ok(personagemBuscado);
                }

                return NotFound("Personagem não encontrado");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com as novas informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "jogador")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            try
            {
                if (_personagemRespository.BuscarPorNome(novoPersonagem.nome) == null)
                {
                    _personagemRespository.Cadastrar(novoPersonagem);

                    return StatusCode(201);
                }

                return BadRequest("Já existe um personagem cadastrado com esse nome");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        /// <param name="personagemAtualizado">Objeto personagem atualizado com as novas informações</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "administrador")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, PersonagemViewModel personagemAtualizado)
        {
            try
            {
                Personagem personagemBuscado = _personagemRespository.BuscarPorId(id);

                if (personagemBuscado != null)
                {
                    personagemBuscado = new Personagem
                    {
                        nome = personagemAtualizado.nome,
                        MaxVida = personagemAtualizado.maxVida,
                        MaxMana = personagemAtualizado.maxMana,
                        idClasse = personagemAtualizado.idClasse
                    };

                    _personagemRespository.Atualizar(id, personagemBuscado);

                    return StatusCode(204);
                }

                return NotFound("Personagem não encontrado");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_personagemRespository.BuscarPorId(id) != null)
                {
                    _personagemRespository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Personagem não encontrado");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
