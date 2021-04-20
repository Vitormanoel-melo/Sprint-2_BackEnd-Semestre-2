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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> lista = _tipoUsuarioRepository.Listar();

            return Ok(lista);
        }


        /// <summary>
        /// Busca um tipoUsuario pelo id
        /// </summary>
        /// <param name="id">id do tipoUsuario que será buscado</param>
        /// <returns>Status Code 200 - Ok e um objeto tipoUsuario encontrado ou null</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuarioDomain tipoBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoBuscado != null)
            {
                return Ok(tipoBuscado);
            }

            return NotFound("TipoUsuario não encontrado!");
        }


    }
}
