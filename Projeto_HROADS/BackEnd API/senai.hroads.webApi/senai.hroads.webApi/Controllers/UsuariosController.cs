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
        /// <returns>Um Status code 200 - Ok e uma lista de usuários</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Um status code 200 - Ok e um usuário buscado</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }

                return NotFound("Usuário não encontrado!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as informações para cadastro</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmail(novoUsuario.email);

                if (usuarioBuscado == null)
                {
                    _usuarioRepository.Cadastrar(novoUsuario);

                    return StatusCode(201);
                }

                return BadRequest("Já existe um usuário cadastrado com esse E-mail!");
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "administrador")]
        [HttpPatch]
        public IActionResult Patch(int id, UsuarioViewModel usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    usuarioBuscado = new Usuario
                    {
                        nome = usuarioAtualizado.nome,
                        sobrenome = usuarioAtualizado.sobrenome,
                        email = usuarioAtualizado.email,
                        senha = usuarioAtualizado.senha
                    };

                    _usuarioRepository.Atualizar(id, usuarioBuscado);

                    return StatusCode(204);
                }

                return NotFound("Usuário não encontrado!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }

        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        /// <returns>Um status code 204 no content</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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

    }
}
