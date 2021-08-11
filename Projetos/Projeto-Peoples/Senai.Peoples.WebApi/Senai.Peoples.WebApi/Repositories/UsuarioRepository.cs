using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=T_Peoples; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Atualiza um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuario">Objeto UsuarioDomain com as novas informações</param>
        public void Atualizar(int id, UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE usuarios SET nome = @nome, sobrenome = @sobrenome, email = @email, senha = @senha, permissao = @permissão WHERE idUsuario = @idUsuario";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nome", usuario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", usuario.sobrenome);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);
                    cmd.Parameters.AddWithValue("@permissao", usuario.permissao);
                    cmd.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>Um objeto UsuarioDomainEncontrado ou null</returns>
        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, nome, sobrenome, email, senha, permissao FROM usuarios WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString(),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            permissao = Convert.ToInt32(rdr["permissao"])
                        };

                        return usuario;
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// Método que cadastra um usuário
        /// </summary>
        /// <param name="usuario">Objeto UsuarioDomain que será cadastrado</param>
        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO usuarios(nome, sobrenome, email, senha, permissao) VALUES (@nome, @sobrenome, @email, @senha, @permissao)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nome", usuario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", usuario.sobrenome);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);
                    cmd.Parameters.AddWithValue("@permissao", usuario.permissao);

                    cmd.ExecuteNonQuery();
                }
            }

        }


        /// <summary>
        /// Deleta um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuario que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM usuarios WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> lista = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, nome, sobrenome, email, senha, permissao FROM usuarios";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString(),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            permissao = Convert.ToInt32(rdr["permissao"])
                        };

                        lista.Add(usuario);
                    }
                }
            }

            return lista;
        }


    }
}
