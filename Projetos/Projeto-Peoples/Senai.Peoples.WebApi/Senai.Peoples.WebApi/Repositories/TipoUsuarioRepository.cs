using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=T_Peoples; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Atualiza um tipoUsuario existente
        /// </summary>
        /// <param name="id">id do tipoUsuario que será deletado</param>
        /// <param name="tipoUsuario">Objeto tipoUsuario com as novas informações</param>
        public void Atualizar(int id, TipoUsuarioDomain tipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE tiposUsuarios SET descricao = @descricao WHERE idTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@descricao", tipoUsuario.descricao);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }

        }


        /// <summary>
        /// Busca um tipoUsuario pelo id
        /// </summary>
        /// <param name="id">id do tipoUsuario que será buscado</param>
        /// <returns>Um objeto tipoUsuario buscado</returns>
        public TipoUsuarioDomain BuscarPorId(int id)
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
                        TipoUsuarioDomain tipo = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            descricao = rdr["descricao"].ToString()
                        };

                        return tipo;
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// Deleta um tipoUsuario existente
        /// </summary>
        /// <param name="id">id do tipoUsuario que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM tiposUsuarios WHERE idTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Lista todos os tiposUsuario
        /// </summary>
        /// <returns>Uma lista de tipoUsuario</returns>
        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> lista = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idTipoUsuario, descricao FROM tiposUsuarios";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipo = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            descricao = rdr["descricao"].ToString()
                        };

                        lista.Add(tipo);
                    }
                }
            }

            return lista;
        }


    }
}
