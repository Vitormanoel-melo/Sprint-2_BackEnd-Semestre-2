﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inlock_webApi_DBFirst.Domains;
using senai_inlock_webApi_DBFirst.Interfaces;
using senai_inlock_webApi_DBFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints (URLs) referentes aos estúdios
/// </summary>
namespace senai_inlock_webApi_DBFirst.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // http://localhost:5000/api/estudios
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Objeto _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _estudioRepository para que haja a referência nos métodos implementados no repositório EstudioRepository
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();        
        }


        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_estudioRepository.Listar());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_estudioRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="estudio">Objeto novoEstudio que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            // Faz a chamada para o método
            _estudioRepository.Cadastrar(novoEstudio);

            // Retorna um status code
            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudio estudioAtualizado)
        {
            _estudioRepository.Atualizar(id, estudioAtualizado);

            return StatusCode(204);
        }


        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);

            return StatusCode(204);
        }


        /// <summary>
        /// Lista todos os estúdios com seus respectivos jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com os jogos e um status code 200 - Ok</returns>
        [HttpGet("jogos")]
        public IActionResult GetGames()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_estudioRepository.ListarJogos());
        }


    }
}
