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
    public class TiposUsuariosController : ControllerBase
    {
        ITipoUsuarioRepository _tipoUsuario { get; set; }

        public TiposUsuariosController()
        {
            _tipoUsuario = new TipoUsuarioRepository();
        }


        /// <summary>
        /// Lista todos os tiposUsuarios
        /// </summary>
        /// <returns>Um status code 200 - Ok e uma lista de tiposUsuarios</returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> lista = _tipoUsuario.Listar();

            return Ok(lista);
        }


        /// <summary>
        /// Busca um tipoUsuario pelo id
        /// </summary>
        /// <param name="id">id do tipoUsuario que será buscado</param>
        /// <returns>Um status code 200 - Ok e um objeto tipoUsuario encontrado ou Not Found se não for encontrado</returns>
        [Authorize(Roles = "2")]
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


        /// <summary>
        /// Deleta um tipoUsuario pelo seu id
        /// </summary>
        /// <param name="id">id do tipoUsuario que será deletado</param>
        /// <returns>Um status code 204 - No content ou NotFound</returns>
        [Authorize(Roles = "2")]
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


        /// <summary>
        /// Atualiza um tipoUsuario existente
        /// </summary>
        /// <param name="id">id do tipoUsuario que será deletado</param>
        /// <param name="tipoUsuario">Objeto tipoUsuario com as novas informações</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuarioDomain tipoUsuario)
        {
            TipoUsuarioDomain tipoUser = _tipoUsuario.BuscarPorId(id);

            if (tipoUser != null)
            {
                try
                {
                    _tipoUsuario.Atualizar(id, tipoUsuario);

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
