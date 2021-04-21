using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Atualiza um usuário peo seu id
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuario">Objeto usuário com as novas informações</param>
        public void Atualizar(int id, UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE usuarios SET email = @email, senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuario.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>Objeto UsuarioDomain encontrado</returns>
        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectPorId = "SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(querySelectPorId, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        return usuario;
                    }
                }
            }

            return null;
        }



        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuario">Objeto UsuarioDomain que será cadastrado</param>
        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastrar = "INSERT INTO usuarios (email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryCadastrar, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuario.idTipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Deleta um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
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
        /// <returns>Lista de usuários</returns>
        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> lista = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        lista.Add(usuario);
                    }
                }
            }

            return lista;
        }


    }
}
