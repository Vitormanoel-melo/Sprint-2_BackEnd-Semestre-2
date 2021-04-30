using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioAtualizado.nome != null)
            {
                usuarioBuscado.nome = usuarioAtualizado.nome;
            }

            if (usuarioAtualizado.sobrenome != null)
            {
                usuarioBuscado.sobrenome = usuarioAtualizado.sobrenome;
            }

            if (usuarioAtualizado.email != null)
            {
                if (BuscarPorEmail(usuarioAtualizado.email) == null)
                {
                    usuarioBuscado.email = usuarioAtualizado.email;
                }
            }

            if (usuarioAtualizado.senha != null)
            {
                usuarioBuscado.senha = usuarioAtualizado.senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public string BuscarPermissao(int id)
        {
            TiposUsuario tipo = ctx.TiposUsuario.Find(id);

            string permissao = tipo.titulo;

            return permissao;
        }

        public Usuario BuscarPorEmail(string email)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.email == email);
        }

        /// <summary>
        /// Busca um usuário existente pelo email e senha
        /// </summary>
        /// <param name="email">E-mail do usuário que será buscado</param>
        /// <param name="senha">Senha do usuário que será buscado</param>
        /// <returns>Um usuário encontrado</returns>
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);
        }

        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>Um usuário encontrado ou null</returns>
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Include(usu => usu.tipoUsuario).Include(us => us.personagens).FirstOrDefault(u => u.idUsuario == id);
        }

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        public void Deletar(int id)
        {
            Usuario usuario = BuscarPorId(id);

            ctx.Usuarios.Remove(usuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuario> Listar()
        {
            //return ctx.Usuarios.Include(u => u.tipoUsuario).Include(us => us.personagens).ToList();

            // Lista todos os usuários sem mostrar suas senhas
            return ctx.Usuarios.Select(u => new Usuario
            {
                idUsuario = u.idUsuario,
                nome = u.nome,
                sobrenome = u.sobrenome,
                email = u.email,
                idTipoUsuario = u.idTipoUsuario,
                tipoUsuario = u.tipoUsuario,
                personagens = u.personagens,
            }).ToList();
        }

    }
}
