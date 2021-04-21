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


        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> lista = _usuarioRepository.Listar();

            return Ok(lista);
        }



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


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, UsuarioDomain usuario)
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

            return NotFound("Usuário não encontrado");
        }


    }
}
