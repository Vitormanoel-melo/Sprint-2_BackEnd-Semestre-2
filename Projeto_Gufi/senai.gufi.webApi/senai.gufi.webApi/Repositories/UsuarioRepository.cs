using senai.gufi.webApi.Contexts;
using senai.gufi.webApi.Domains;
using senai.gufi.webApi.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.gufi.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="email">email do usuário que será logado</param>
        /// <param name="senha">senha do usuário que será logado</param>
        /// <returns>Um usuário encontrado</returns>
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

    }
}
