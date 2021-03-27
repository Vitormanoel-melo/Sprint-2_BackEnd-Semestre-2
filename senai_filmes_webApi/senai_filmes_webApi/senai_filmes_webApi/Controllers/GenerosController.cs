using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints referentes aos gêneros
/// </summary>
namespace senai_filmes_webApi.Controllers
{   
    // Define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto GeneroRepository para que haja a referencia aos métodos do repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }


        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> Uma lista de gêneros e um status code </returns>
        [HttpGet]
        public IActionResult Get()
        {
            // cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // Retorna um status code (200) com a lista de gêneros no formato JSON
            return Ok(listaGeneros);
        }


        /// <summary>
        /// Busca um gênero através de seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado ou NotFound caso nenhum gênero seja encontrado</returns>
        /// http://localhost:5000/api/generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 204 - Not Found com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado");
            }

            // Caso seja encontrado, retorna um gênero com o status code Ok - 200
            return Ok(generoBuscado);
        }


        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns> Um status code 201 - Created </returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o método .Cadastrar()
            _generoRepository.Cadastrar(novoGenero);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza um gênero existente passando o seu id pela url da requisição
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/generos/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            /// Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Caso não seja encontrado
            if (generoBuscado == null)
            {
                return NotFound
                        (
                            new
                            {
                                mensagem = "Gênero não encontrado!",
                                erro = true
                            }
                        );
            }

            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                // Retorna um status code 204 - No content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception codErro)
            {
                // Retorna um Status Code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }

        }


        /// <summary>
        /// Atualiza um gênero existente passando seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {

            /// Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            // Verifica se algum gênero foi encontrado
            if (generoBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {   
                    // Faz a chamada para o método .AtualizarIdCorpo
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    // Retorna um Status Code 204 - No content
                    return NoContent();
                }
                // Caso o ocorra algum erro
                catch (Exception codErro)
                {
                    // Retorna um BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }

            // Caso não seja encontrado, retorna um NotFound com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Gênero não encontrado!"
                    }
                );
        }


        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http:localhost:5000/api/generos/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _generoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }

    }
}
