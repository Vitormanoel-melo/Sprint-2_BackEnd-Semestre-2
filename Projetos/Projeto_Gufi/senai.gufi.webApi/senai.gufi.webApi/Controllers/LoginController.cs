using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.gufi.webApi.Domains;
using senai.gufi.webApi.Intefaces;
using senai.gufi.webApi.Repositories;
using senai.gufi.webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.gufi.webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes ao login
    /// </summary>

    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado =_usuarioRepository.Login(login.email, login.senha);

                // Caso não encontre o usuário com o email e senha informados
                if (usuarioBuscado == null)
                {
                    // Retorna um NotFound com uma mensagem personalizada
                    return NotFound("E-mail ou senha inválidos!");
                }

                // Caso o usuário seja encontrado, prossegue para a criação do token

                // Define os dados que serão fornecidos no token - Payload
                var Claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim( JwtRegisteredClaimNames.Email, usuarioBuscado.Email ),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim( JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString() ),

                    // Outra forma, armazenando o título do tipo de usuário
                    // Armazena na Claim o tipo de usuário que foi autenticado ("Administrador")
                    // new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.TituloTipoUsuario)

                    // Armazena na Claim o tipo de usuário que foi autenticado
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    
                    // Armazena na Claim o tipo de usuário que foi autenticado de forma personalizada
                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString())
                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao"));

                // Define as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Definir os dados do token
                var token = new JwtSecurityToken(
                    issuer: "gufi.webApi",                          // emissor do token
                    audience: "gufi.webApi",                        // destinatário do token
                    expires: DateTime.Now.AddMinutes(30),           // tempo de expiração
                    claims: Claims,                                 // dados definidos acima (linha 51)
                    signingCredentials: creds                       // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                );
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
