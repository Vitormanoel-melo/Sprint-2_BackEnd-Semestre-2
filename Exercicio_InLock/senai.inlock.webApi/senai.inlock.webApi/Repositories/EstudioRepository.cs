using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Atualiza um estúdio pelo seu id
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <param name="estudio">Objeto estudio com as novas informações</param>
        public void Atualizar(int id, EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE estudios SET nomeEstudio = @nomeEstudio WHERE idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nomeEstudio", estudio.nomeEstudio);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Busca um estudio pelo id
        /// </summary>
        /// <param name="id">id do estudio que será buscado</param>
        /// <returns>Um objeto EstudioDomain ou null</returns>
        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idEstudio, nomeEstudio FROM estudios WHERE idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };

                        return estudio;
                    }
                }
            }

            return null;
        }



        /// <summary>
        /// Cadastra um estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO estudios (nomeEstudio) VALUES (@nomeEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);

                    cmd.ExecuteNonQuery();
                }
            }

        }



        /// <summary>
        /// Deleta um estúdio pelo seu id
        /// </summary>
        /// <param name="id">id do estúdio que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM estudios WHERE idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Lista todos os estúios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> lista = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM estudios";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString(),
                        };

                        lista.Add(estudio);
                    }
                }
            }

            return lista;
        }


        /// <summary>
        /// Lista os jogos de acordo com o id do estúdio
        /// </summary>
        /// <param name="id">id do estúdio do jogo</param>
        /// <returns>Uma lista de jogos</returns>
        public List<JogoDomain> ListarJogos(int id)
        {
            List<JogoDomain> lista = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.idEstudio, nomeEstudio FROM jogos INNER JOIN estudios ON jogos.idEstudio = estudios.idEstudio WHERE jogos.idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = Convert.ToDouble(rdr["valor"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                                nomeEstudio = rdr["nomeEstudio"].ToString()
                            }
                        };

                        lista.Add(jogo);
                    }
                }
            }

            return lista;
        }

    }
}
