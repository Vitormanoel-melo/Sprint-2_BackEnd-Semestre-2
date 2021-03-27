using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source =  Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// user Id = sa; pwd = senai@132
        /// integrated security=true = Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>
        private string stringDeConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=Filmes; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                con.Open();

                string querySelect = "SELECT idFilme, Generos.idGenero, titulo FROM Filmes INNER JOIN Generos ON Filmes.idGenero = Generos.idGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme     = Convert.ToInt32(rdr[0]),
                            idGenero    = Convert.ToInt32(rdr[1]),
                            titulo      = rdr[2].ToString()
                        };

                        listaFilme.Add(filme);
                        
                    }

                }

            }

            return listaFilme;
        }

    }
}
