using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=T_Peoples; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">Email do usuário que será buscado</param>
        /// <param name="senha">Senha do usuário que será buscado</param>
        /// <returns>Objeto UsuarioDomain que foi encontrado</returns>
        public UsuarioDomain Logar(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectEmailPwd = "SELECT idUsuario, nome, sobrenome, email, senha, permissao FROM usuarios WHERE email = @email AND senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelectEmailPwd, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

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


        public string BuscarPermissao(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idTipoUsuario, descricao FROM tiposUsuarios WHERE idTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string permissao = rdr["descricao"].ToString();

                        return permissao;
                    }
                }
            }

            return null;
        }

    }
}
