using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ClassesHabilidadeController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeRepository { get; set; }

        public ClassesHabilidadeController()
        {
            _classeRepository = new ClasseHabilidadeRepository();
        }

        /// <summary>
        /// Endpoint que lista todas as classes habilidade
        /// </summary>
        /// <returns>Uma lista de classe habilidade</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_classeRepository.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Busca uma classe habilidade existente
        /// </summary>
        /// <param name="id">Id da classe habilidade que será buscada</param>
        /// <returns>Um status code 200 - Ok e uma classe habilidade encontrada</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_classeRepository.BuscarPorId(id));
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Cadastra uma nova classe habilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto novaClasseHabilidade com as informações para cadastro</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(ClassesHabilidade novaClasseHabilidade)
        {
            try
            {
                _classeRepository.Cadastrar(novaClasseHabilidade);

                return StatusCode(201);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Atualiza uma classe habilidade existente
        /// </summary>
        /// <param name="id">Id da classe habilidade que será atualizada</param>
        /// <param name="classeHabilidade">Objeto classeHabilidade com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "administrador")]
        [HttpPatch("{id}")]
        public IActionResult Atualizar(int id, ClassesHabilidade classeHabilidade)
        {
            try
            {
                if (_classeRepository.BuscarPorId(id) != null)
                {
                    _classeRepository.Atualizar(id, classeHabilidade);

                    return StatusCode(204);
                }

                return NotFound("Classe Habilidade não encontrada");
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Deleta uma classe habilidade
        /// </summary>
        /// <param name="id">Id da classe habilidade que será deletada</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _classeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
