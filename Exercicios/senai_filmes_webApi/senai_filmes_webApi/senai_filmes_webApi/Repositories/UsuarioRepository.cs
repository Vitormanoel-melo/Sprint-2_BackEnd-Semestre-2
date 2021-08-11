using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=Filmes; user Id=sa; pwd=senai@132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, senha, permissao FROM Usuarios WHERE email = @email AND senha = @senha";

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
                            permissao = rdr["permissao"].ToString()
                        };

                        return usuario;
                    }
                }

            }

            return null;
        }



    }
}
