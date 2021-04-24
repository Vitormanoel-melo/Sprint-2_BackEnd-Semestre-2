using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {

        private ILoginRepository _loginRepository { get; set; }

        public LoginsController()
        {
            _loginRepository = new LoginRepository();
        }


        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="login">Objeto login com email e senha do usuário</param>
        /// <returns>Status code 200 - Ok e um token ou Status code 404 - NotFound caso o usuário não seja encontrado</returns>
        [HttpPost("Login")]
        public IActionResult Logar(LoginDomain login)
        {
            UsuarioDomain usuario = _loginRepository.Logar(login.email, login.senha);

            if (usuario != null)
            {

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.idUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.permissao.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                var token = new JwtSecurityToken(
                    issuer: "peoples.webApi",
                    audience: "peoples.webApi",
                    claims: Claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );


                return Ok(
                    new
                    {
                        token = new  JwtSecurityTokenHandler().WriteToken(token)
                    }    
                );

            }


            return NotFound("E-mail ou senha inválidos!");
        }



    }
}
