using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Um status code 200 - Ok com a lista de usuários</returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> lista = _usuarioRepository.Listar();

            return Ok(lista);
        }


        /// <summary>
        /// Busca um usuário pelo seu id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>Status code 200 - Ok com o usuário encontrado ou Status Code 404 - NotFound se o usuário ão for encontrado</returns>
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario != null)
            {
                try
                {

                    return Ok(usuario);
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }

            }

            return NotFound("Usuário não encontrado!");
        }


        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuario">Objeto usuário que será cadastrado</param>
        /// <returns>Status code 201 - Created</returns>
        [HttpPost("cadastrar")]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }

        }


        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
        /// <returns>Status code 204 - No content, ou Status Code 404 - NotFound se o usuário não for encontrado</returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Deletar(id);

                    return StatusCode(204);
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }

            }

            return NotFound("Usuário não encontrado!");
        }


        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuario">Objeto usuário com as novas informações</param>
        /// <returns>Status code 204 - No content, ou Status code 404 - Not Found se o usuário não for encontrado</returns>
        [Authorize(Roles = "2")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuario);

                    return NoContent();
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
