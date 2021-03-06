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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Um status code 200 - Ok e uma lista de habilidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_habilidadeRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será buscada</param>
        /// <returns>Um Status Code 200 - OK com uma habilidade encontrada ou NotFound se não encontrar</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

                if(habilidadeBuscada != null)
                {
                    return Ok(habilidadeBuscada);
                }

                return NotFound("Habilidade não encontrada!");
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            try
            {
                Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorNome(novaHabilidade.nome);

                if (habilidadeBuscada == null)
                {
                    _habilidadeRepository.Cadastrar(novaHabilidade);

                    return StatusCode(201);
                }

                return BadRequest("Já existe uma habilidade cadastrada com esse nome");
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - NoContent se for atualizado ou NotFound caso a habilidade não seja encontrada</returns>
        [Authorize(Roles = "administrador")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, HabilidadeViewModel habilidadeAtualizada)
        {
            try
            {
                Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

                if (habilidadeAtualizada != null)
                {
                    habilidadeBuscada = new Habilidade()
                    {
                        nome = habilidadeAtualizada.nome,
                        idTipoHabilidade = habilidadeAtualizada.idTipoHabilidade
                    };

                    _habilidadeRepository.Atualizar(id, habilidadeBuscada);

                    return StatusCode(204);
                }

                return NotFound("Habilidade não encontrada!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será deletada</param>
        /// <returns>Um status code 204 - NoContent caso seja deletado ou NotFound caso não seja encontrado</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_habilidadeRepository.BuscarPorId(id) != null)
                {
                    _habilidadeRepository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Habilidade não encontrada");
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

    }
}
