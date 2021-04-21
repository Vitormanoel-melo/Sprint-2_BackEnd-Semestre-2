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
        /// <returns>Lista de usuários</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> lista = _usuarioRepository.Listar();

            return Ok(lista);
        }


        /// <summary>
        /// Lista um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>Status Code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario != null)
            {

                return Ok(usuario);
            }

            return NotFound("Usuário não encontrado!");
        }


        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Usuário que será cadastrado</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <param name="usuario">Objeto usuário com as novas informações</param>
        /// <returns>Status Code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuario);

                    return Ok();
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }

            }

            return NotFound("Usuário não encontrado!");
        }


        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">id do usuário que será colocado</param>
        /// <returns>Status Code 204 - No Content</returns>
        [Authorize(Roles = "1")]
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

            return NotFound("Usuário não encontrado");
        }


    }
}
