using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{   
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source =  Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// user Id = sa; pwd = senai@132
        /// integrated security=true = Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=Filmes; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Atualiza um gênero passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateId = "UPDATE Generos SET nome = @Nome WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateId, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }


        /// <summary>
        /// Atualiza um gênero passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="novoGenero">Objeto genero com as novas informações</param>
        public void AtualizarIdUrl(int id, GeneroDomain novoGenero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE Generos SET nome = @Nome WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa os valores para ps parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }

            }
        }


        /// <summary>
        /// Busca um gênero através de seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscadp</param>
        /// <returns>retorna um gênero buscado ou null</returns>
        public GeneroDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idGenero, nome FROM Generos WHERE idGenero = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain();

                        // Atribui à propriedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                        generoBuscado.idGenero = Convert.ToInt32(rdr["idGenero"]);

                        // Atribui à propriedade nome o valor da coluna "nome" da tabela do banco de dados
                        generoBuscado.nome = rdr["nome"].ToString();

                        // Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }
                    
                }

            }

            return null;
        }


        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero"> Objeto novoGenero com as informações que serão cadastradas </param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a conexão "con" passando a string de conexão pelo parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // INSERT INTO Generos(nome) VALUES ('Ficção Científica')
                // string queryInsert = "INSERT INTO Generos (Nome) VALUES ('" + novoGenero.nome + "')";
                // Não usar a concatenação dessa forma, pois pode causar o efeito Joana D'Arc
                // Além de permitir o Sql Injection
                // "nome" : " ') DROP TABLE Filmes --
                // Ao tentar cadastrar o comando acima, irá  deletar a tabela filmes do banco de dados

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Generos (Nome) VALUES (@Nome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome,", novoGenero.nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }

            }
        }


        /// <summary>
        /// Deleta um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero ques será deletado</param>
        public void Deletar(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o parâmetro @id
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @id";

                // Declara o SqlCommand cmd passandoa query que será executada e a conexão como parâetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como valor do parâmetro @id
                    cmd.Parameters.AddWithValue("@id", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }

            }
        }


        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> Uma lista de gêneros </returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista chamada listaGenero onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection "con" passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução/query a ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como paramêtros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    // Enquanto houve registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui à propriedade idGenero o valor da primeira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna do banco de dados
                            nome = rdr[1].ToString()
                        };
                        listaGeneros.Add(genero);
                    }

                }

            }
            
            // Retorna a lista de gêneros
            return listaGeneros;
        }


    }
}
