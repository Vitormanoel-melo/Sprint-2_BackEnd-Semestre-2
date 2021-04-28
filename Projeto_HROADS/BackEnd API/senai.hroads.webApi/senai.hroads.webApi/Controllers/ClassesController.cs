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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as classes existentes
        /// </summary>
        /// <returns>Um status code 200 - Ok com uma lista de classes</returns>
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_classeRepository.Listar());
        }

        /// <summary>
        /// Busca uma classe pelo id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>Status code 200 - OK com a classe encontrada ou 404 - NotFound caso não seja encontrada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Classes classeBuscada = _classeRepository.BuscarPorId(id);

            if (classeBuscada != null)
            {
                return Ok(classeBuscada);
            }

            return NotFound("Classe não encontrada!");
        }


        /// <summary>
        /// Cadastra uma classe
        /// </summary>
        /// <param name="novaClasse">Objeto nova classe com as informações</param>
        /// <returns>Status code 201- Created se a classe foi cadastrada ou BadRequest caso ela já exista</returns>
        [HttpPost]
        public IActionResult Post(Classes novaClasse)
        {
            Classes classeBuscada = _classeRepository.BuscarPorNome(novaClasse.nomeClasse);

            if (classeBuscada == null)
            {
                _classeRepository.Cadastrar(novaClasse);

                return StatusCode(201);
            }

            return BadRequest("Não é possível cadastrar essa classe pois ela já existe");
        }

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        /// <returns>Status code 204 - No content caso seja atualizado ou NotFound caso a classe não seja encontrada </returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classes classeAtualizada)
        {
            Classes classeBuscada = _classeRepository.BuscarPorId(id);

            if (classeBuscada != null)
            {
                bool validacao = _classeRepository.Atualizar(id, classeAtualizada);

                if(validacao == true)
                {
                    return StatusCode(204);
                }
                else
                {
                    return BadRequest("Já existe uma classe com esse nome");
                }
            }

            return NotFound("Classe não encontrada");
        }

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será deletada</param>
        /// <returns>Status code 204 - No Content caso seja deletado ou NotFound caso não seja encontrado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_classeRepository.BuscarPorId(id) != null)
            {
                _classeRepository.Deletar(id);

                return StatusCode(204);
            }

            return NotFound("Classe não encontrada");
        }


    }
}
