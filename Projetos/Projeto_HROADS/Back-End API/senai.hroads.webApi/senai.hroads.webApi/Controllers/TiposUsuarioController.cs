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
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Um status code 200 - OK e uma lista de tipos usuário</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo de usuário existente
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será buscado</param>
        /// <returns>Um Status code 200 - Ok e um tipo de usuário encontrado</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo que será com as informações para cadastro</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será atualizado</param>
        /// <param name="tipoAtualizado">Objeto tipoAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {
            try
            {
                if (_tipoUsuarioRepository.BuscarPorId(id) != null)
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Tipo de usuário não encontrado!");
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_tipoUsuarioRepository.BuscarPorId(id) != null)
                {
                    _tipoUsuarioRepository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Tipo de usuário não encontrado!");
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }


    }
}
