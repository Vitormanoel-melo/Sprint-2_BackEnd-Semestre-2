using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";



        /// <summary>
        /// Atualiza um jogo pelo id
        /// </summary>
        /// <param name="id">id do jogo que será atualizado</param>
        /// <param name="jogo">Objeto com as novas informações</param>
        public void Atualizar(int id, JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE jogos SET nomeJogo = @nome, descricao = @descricao, dataLancamento = @dataLancamento, valor = @valor, idEstudio = @idEstudio WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nome", jogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", jogo.idEstudio);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Busca um jogo pelo id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>Objeto jogo buscado</returns>
        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.IdEstudio, estudios.NomeEstudio FROM jogos INNER JOIN estudios ON estudios.idEstudio = jogos.idEstudio WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
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

                        return jogo;
                    }

                }
            }

            return null;
        }


        /// <summary>
        /// Busca um jogo pelo nome
        /// </summary>
        /// <param name="nome">nome do jogo que será buscado</param>
        /// <returns>jogo encontrado ou null</returns>
        public JogoDomain BuscarPorNome(string nome)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectName = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogos WHERE nomeJogo = @nomeJogo";

                using (SqlCommand cmd = new SqlCommand(querySelectName, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nomeJogo", nome);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            descricao = rdr["descricao"].ToString(),
                            valor = Convert.ToDouble(rdr["valor"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        return jogo;
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// Método que cadastra um jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO jogos (nomeJogo, descricao, valor, dataLancamento, idEstudio) VALUES (@nomeJogo, @descricao, @valor, @dataLancamento, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);

                    cmd.ExecuteNonQuery();
                }
            }

        }


        /// <summary>
        /// Deleta um jogo pelo id
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM jogos WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Método que lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        public List<JogoDomain> Listar()
        {
            List<JogoDomain> lista = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor,  jogos.idEstudio, estudios.idEstudio, nomeEstudio FROM jogos INNER JOIN estudios ON jogos.idEstudio = estudios.idEstudio";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

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
                            estudio = new EstudioDomain{
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
