using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">email do usuário buscado</param>
        /// <param name="senha">senha do usuário buscado</param>
        /// <returns>Usuário buscado</returns>
        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios WHERE email = @email AND senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
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

    }
}
