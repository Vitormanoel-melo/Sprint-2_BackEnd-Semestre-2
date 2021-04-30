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
    public class TiposHabilidadeController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidade { get; set; }

        public TiposHabilidadeController()
        {
            _tipoHabilidade = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os tipos de habilidade
        /// </summary>
        /// <returns>Um Status Code 200 - Ok e lista de tipos de habilidade</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoHabilidade.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um tipo de habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de habilidade buscado</param>
        /// <returns>Um Status Code 200 - Ok e um tipo de habilidade encontrado ou NotFound caso não encontre</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                TipoHabilidadeDomain tipoBuscado = _tipoHabilidade.BuscarPorId(id);

                if (tipoBuscado != null)
                {
                    return Ok(tipoBuscado);
                }

                return NotFound("Tipo de habilidade não encontrado!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um tipo de habilidade existente
        /// </summary>
        /// <param name="novoTipo">Objeto novo tipo com as informações para cadastro</param>
        /// <returns>UStatus code</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(TipoHabilidadeDomain novoTipo)
        {
            try
            {
                TipoHabilidadeDomain tipoBuscado = _tipoHabilidade.BuscarPorTitulo(novoTipo.titulo);

                if (tipoBuscado == null)
                {
                    _tipoHabilidade.Cadastrar(novoTipo);

                    return StatusCode(201);
                }

                return BadRequest("Este tipo de habilidade já existe!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualia um tipo de habilidade existente
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será atualizado</param>
        /// <param name="tipoAtualizado">Objeto tipoAtualizado com as novas informações</param>
        /// <returns>Um Status Code 204 - NoContent</returns>
        [Authorize(Roles = "administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidadeDomain tipoAtualizado)
        {
            try
            {
                if (_tipoHabilidade.BuscarPorId(id) != null)
                {
                    bool validacao = _tipoHabilidade.Atualizar(id, tipoAtualizado);

                    if (validacao == true)
                    {
                        return StatusCode(204);
                    }
                    else
                    {
                        return BadRequest("Não é possível atualizar pois já existe um tipo de habilidade com este título!");
                    }
                }

                return NotFound("Tipo de habilidade não encontrado!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será deletado</param>
        /// <returns>Um status code 204 - NoContent ou NotFound</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_tipoHabilidade.BuscarPorId(id) != null)
                {
                    _tipoHabilidade.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Tipo de habilidade não encontrado");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


    }
}
