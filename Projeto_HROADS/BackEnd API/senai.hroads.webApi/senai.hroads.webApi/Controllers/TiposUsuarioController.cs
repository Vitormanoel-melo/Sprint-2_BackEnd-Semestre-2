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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipo);

                return Ok();
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

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
