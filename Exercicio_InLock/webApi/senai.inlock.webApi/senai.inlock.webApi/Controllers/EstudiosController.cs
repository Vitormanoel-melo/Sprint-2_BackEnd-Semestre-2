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
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }


        /// <summary>
        /// Endpoint que lista todos os estúdios e seus respectivos jogos
        /// </summary>
        /// <returns>Status code 200 - Ok com a lista de estúdios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> lista = _estudioRepository.Listar();

            List<object> listObj = new List<object>();

            foreach (EstudioDomain item in lista)
            {
                List<JogoDomain> jogos = _estudioRepository.ListarJogos(item.idEstudio);

                object obj = new { item.idEstudio, item.nomeEstudio, jogos };

                listObj.Add(obj);
            }

            return Ok(listObj);
        }



        /// <summary>
        /// Endpoint que busca um estúdio pelo id
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <returns>Objeto estudio encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudio = _estudioRepository.BuscarPorId(id);

            if (estudio != null) 
            {
                try
                {
                    return Ok(estudio);
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }

            }

            return NotFound("Estudio não encontrado!");
        }


        /// <summary>
        /// Endpoint que cadastra um novo estúdio
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(EstudioDomain estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return StatusCode(201);
            }
            catch (Exception codErro )
            {

                return BadRequest(codErro);
            }

        }


        /// <summary>
        /// Endpoint que atualiza um estúdio pelo id
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <param name="estudio">Objeto com as novas informações</param>
        /// <returns>Status code 201 - Ok ou Status code 404 - Not Found</returns>
        [HttpPut("{id}")]
        public IActionResult PutByIdUrl(int id, EstudioDomain estudio)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                try
                {
                    _estudioRepository.Atualizar(id, estudio);

                    return StatusCode(200);
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }

            }

            return NotFound("Estúdio não encontrado!");
        }


        /// <summary>
        /// Endpoint que deleta um estúdio pelo id
        /// </summary>
        /// <param name="id">id do estúdio que será deletado</param>
        /// <returns>Status code 204 - No content ou 404 - Not Found</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                try
                {
                    _estudioRepository.Deletar(id);

                    return StatusCode(204);
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }

            }

            return NotFound("Estúdio não encontrado!");
        }


    }
}
