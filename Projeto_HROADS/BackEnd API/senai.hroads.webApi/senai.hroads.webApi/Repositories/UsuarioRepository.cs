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
        public void Atualizar(int id, Usuarios usuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public string BuscarPermissao(int id)
        {
            TiposUsuario tipo = ctx.TiposUsuario.Find(id);

            string permissao = tipo.titulo;

            return permissao;
        }

        public Usuarios BuscarPorEmail(string email)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.email == email);
        }

        /// <summary>
        /// Busca um usuário existente pelo email e senha
        /// </summary>
        /// <param name="email">E-mail do usuário que será buscado</param>
        /// <param name="senha">Senha do usuário que será buscado</param>
        /// <returns>Um usuário encontrado</returns>
        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);
        }

        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>Um usuário encontrado ou null</returns>
        public Usuarios BuscarPorId(int id)
        {
            return ctx.Usuarios.Include(usu => usu.tipoUsuario).Include(us => us.personagens).FirstOrDefault(u => u.idUsuario == id);
        }

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(Usuarios novoUsuario)
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
            Usuarios usuario = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuarios> Listar()
        {
            //return ctx.Usuarios.Include(u => u.tipoUsuario).Include(us => us.personagens).ToList();

            // Lista todos os usuários sem mostrar suas senhas
            return ctx.Usuarios.Select(u => new Usuarios
            {
                idUsuario = u.idUsuario,
                nome = u.nome,
                sobrenome = u.sobrenome,
                email = u.email,
                idTipoUsuario = u.idTipoUsuario,
                tipoUsuario = u.tipoUsuario,
                personagens = u.personagens
            }).ToList();
        }

    }
}
