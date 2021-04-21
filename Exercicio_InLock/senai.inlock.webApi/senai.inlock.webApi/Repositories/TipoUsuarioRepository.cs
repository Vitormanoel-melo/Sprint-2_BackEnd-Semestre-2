using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Busca um tipoUsuario pelo id
        /// </summary>
        /// <param name="id">id do tipo que será buscado</param>
        /// <returns>Objeto TipoUsuarioDomain com as informações</returns>
        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idTipoUsuario, titulo FROM tiposUsuarios WHERE idTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipo = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };

                        return tipo;
                    }

                }
            }

            return null;
        }



        /// <summary>
        /// Listar todos os tipos de usuario
        /// </summary>
        /// <returns>Lista de tipos de usuário</returns>
        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> lista = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idTipoUsuario, titulo FROM tiposUsuarios";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };

                        lista.Add(tipoUsuario);
                    }
                }
            }

            return lista;
        }



    }
}
