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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                return Ok(usuarioBuscado);
            }

            return NotFound("Usuário não encontrado!");
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorEmail(novoUsuario.email);

            try
            {
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
