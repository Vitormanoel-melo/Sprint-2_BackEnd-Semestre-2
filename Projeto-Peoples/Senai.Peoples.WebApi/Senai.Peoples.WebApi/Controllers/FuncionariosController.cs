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
    public class FuncionariosController : ControllerBase
    {
        IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <returns>Status code Ok e a listaFuncionario</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            // armazena na lista funcionario todos os funcionários
            List<FuncionarioDomain> listaFuncionario = _funcionarioRepository.Listar();

            // retorna um status code Ok com a listaFuncionario
            return Ok(listaFuncionario);
        }


        /// <summary>
        /// Cadastra um funcionário
        /// </summary>
        /// <param name="novoFuncionario">funcionário que vai ser cadastrado</param>
        /// <returns>status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            try
            {   
                // verifica se o nome do funcionário está vazio, se estiver armazena true na variável text
                bool text = string.IsNullOrWhiteSpace(novoFuncionario.nome);

                // se text for true retorna um Bad Request com uma mensagem
                if (text == true)
                {
                    return BadRequest("O nome do funcionário não pode ser vazio");
                }
                else
                {
                    // Se não, executa o cadastro
                    _funcionarioRepository.Cadastrar(novoFuncionario);
                    return StatusCode(201);
                }

            }
            catch (Exception codErro)
            {
                // se der algum erro na execução, a aplicação continua rodando e retornamos ao front um BadRequest com o código do erro
                return BadRequest(codErro);
            }

        }


        /// <summary>
        /// Busca funcionario pelo id
        /// </summary>
        /// <param name="id">id do funcionario buscado</param>
        /// <returns> funcionario encontrado </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Buscamos o funcionário
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // se funcionarioBuscado for diferente de null executamos o try catch
            if (funcionarioBuscado != null)
            {
                try
                {
                    // retorna o funcionarioBuscado
                    return Ok(funcionarioBuscado);
                }
                catch (Exception codErro)
                {
                    // retorna BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }

            // Se o funcionário não for encontrado, retorna um NotFound com uma mensagem personalizada
            return NotFound("Funcionário não encontrado!");
        }


        /// <summary>
        /// Deleta um funcionário pelo id
        /// </summary>
        /// <param name="id">id do funcionario que será deletado</param>
        /// <returns> status code 204 - No content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Primeiro buscamos o funcionário pelo id
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Se ele existir executamos o try catch
            if (funcionarioBuscado != null)
            {
                try
                {
                    // deleta o funcionário
                    _funcionarioRepository.Deletar(id);

                    // retorna status code 204 - No content
                    return StatusCode(204);
                }
                catch (Exception codErro)
                {
                    // retorna Bad Request com o código do erro
                    return BadRequest(codErro);
                }
            }

            // retorna um NotFound com um json object com mensagem de erro
            return NotFound(
                    new
                    {
                        mensagem = "Funcionário não encontrado!",
                        erro = true
                    }
                );
        }


        /// <summary>
        /// Atualiza funcionario pelo id passado no corpo da requisição
        /// </summary>
        /// <param name="funcionario">objeto com as novas informações</param>
        /// <returns>status code 200 - Ok</returns>
        [HttpPut]
        public IActionResult PutByIdCorpo(FuncionarioDomain funcionario)
        {
            // verificar se o funcionario existe
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionario.idFuncionario);

            // se existir, executa o try catch
            if (funcionarioBuscado != null)
            {
                try
                {
                    // faz a atualização passando o objeto com as novas informações
                    _funcionarioRepository.AtualizarIdCorpo(funcionario);

                    // retorna um status code 200 - Ok
                    return Ok();
                }
                catch (Exception codErro)
                {
                    // Retorna um BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }

            // Retorna um NotFound com um json object com uma mensagem de erro
            return NotFound(
                    new
                    {
                        mensagem = "Funcionario não encontrado!",
                        erro = true
                    }
                );
        }


        /// <summary>
        /// Busca um funcionario pelo nome
        /// </summary>
        /// <param name="nome">nome do funcionario que será buscado</param>
        /// <returns>objeto funcionario encontrado</returns>
        [HttpGet("Buscar/{nome}")]
        public IActionResult GetByName(string nome)
        {
            // Buscamos ele pelo nome
            FuncionarioDomain funcionario = _funcionarioRepository.BuscarPorNome(nome);

            // Se existir, executamos o try catch
            if (funcionario != null)
            {
                try
                {
                    // retorna um status code 200 - Ok
                    return Ok(funcionario);
                }
                catch (Exception codErro)
                {
                    // retorna um BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }

            // retorna um NotFound com um json object e uma mensagem de erro
            return NotFound(
                    new
                    {
                        mensagem = "Funcionário não encontrado",
                        erro = true
                    }
                );
        }


        /// <summary>
        /// retorna o nome completo de todos os funcionários
        /// </summary>
        /// <returns>lista de nomes completos ou NotFound </returns>
        [HttpGet("NomesCompletos")]
        public IActionResult ListarNomeCompleto()
        {
            // armazenamos na listaDeFuncionarios todos os funcionarios
            List<FuncionarioDomain> listaDeFuncionarios = _funcionarioRepository.Listar();

            // Se a lista não for vazia, executamos o try catch
            if (listaDeFuncionarios != null)
            {
                try
                {
                    // criamos uma lista de objects e armazenamos a lista de todos os objetos com nome completo dos funcionários passando a lista
                    // de funcionários como parâmetro
                    List<object> listaNomes = _funcionarioRepository.ListarNomesCompletos(listaDeFuncionarios);

                    // retorna um status code 200 - Ok com a lista de nomes
                    return Ok(listaNomes);
                }
                catch (Exception codErro)
                {
                    // retorna um BadRequest com o código do erro
                    return BadRequest(codErro);
                }
                
            }

            // retorna um NotFound com uma mensagem personalizada
            return NotFound("Nenhum funcionário encontrado");
        }

        
        /// <summary>
        /// Lista os funcionarios em ordem crescente ou decrescente
        /// </summary>
        /// <param name="ordem">ordem em que será listado</param>
        /// <returns>lista de funcionarios</returns>
        [HttpGet("ordenacao/{ordem}")]
        public IActionResult GetByOrder(string ordem)
        {
            // se a ordem for desc ou asc, executa o try catch
            if (ordem == "desc" || ordem == "asc")
            {
                try
                {
                    // armazenamos na lista o retorno do método listar por ordem passando a ordem como argumento
                    List<FuncionarioDomain> funcionarios = _funcionarioRepository.ListarPorOrdem(ordem);

                    // retorna um status code 200 - Ok com a lista funcionarios
                    return Ok(funcionarios);
                }
                catch (Exception codErro)
                {
                    // retorna um BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }

            // retorna um BadRequest com uma mensageme personalizada
            return BadRequest("Ordenação incorreta!");

        }

    }
}
