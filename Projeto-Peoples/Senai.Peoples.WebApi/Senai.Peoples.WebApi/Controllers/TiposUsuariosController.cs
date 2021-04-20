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
    public class TiposUsuariosController : ControllerBase
    {
        ITipoUsuarioRepository _tipoUsuario { get; set; }

        public TiposUsuariosController()
        {
            _tipoUsuario = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> lista = _tipoUsuario.Listar();

            return Ok(lista);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                TipoUsuarioDomain tipoBuscado = _tipoUsuario.BuscarPorId(id);

                if (tipoBuscado == null)
                {

                    return NotFound("Tipo de usuário não encontrado");
                }

                return Ok(tipoBuscado);
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuarioDomain tipoUser = _tipoUsuario.BuscarPorId(id);

            if (tipoUser == null)
            {

                return NotFound(
                        new
                        {
                            mensagem = "usuario não encontrado"
                        }
                    );
            }

            _tipoUsuario.Deletar(id);

            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuarioDomain tipoUsuario)
        {
            TipoUsuarioDomain tipoUser = _tipoUsuario.BuscarPorId(id);

            if (tipoUser != null)
            {
                try
                {
                    _tipoUsuario.Atualizar(id, tipoUsuario);

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
