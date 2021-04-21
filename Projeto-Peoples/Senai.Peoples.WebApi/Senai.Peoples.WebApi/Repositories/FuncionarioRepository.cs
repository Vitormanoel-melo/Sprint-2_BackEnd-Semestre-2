using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        /// <summary>
        /// string que define a nossa conexão
        /// Data Source = Servidor
        /// initial catalog = banco de dados
        /// user Id = logon
        /// pwd = senha
        /// </summary>
        private string stringConexao = "Data Source=LAPTOP-70KR9CNR; initial catalog=T_Peoples; user Id=sa; pwd=senai@132";


        /// <summary>
        /// Atualiza funcionário passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="novoFuncionario">Dados do funcionario para a atualização</param>
        public void AtualizarIdCorpo(FuncionarioDomain novoFuncionario)
        {
            // define a conexão con passando a string de conexão pelo parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // query que será executada
                string queryAtualizar = "UPDATE funcionarios SET nome = @nome, sobrenome = @sobrenome, dataNascimento = @dataNascimento WHERE idFuncionario = @ID";

                // declara o SqlCommand cmd, passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    // abre a conexão com o banco de dados
                    con.Open();

                    // Define valores aos parâmetros @nome, @sobrenome, @ID e @dataNascimento
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobreNome);
                    cmd.Parameters.AddWithValue("@ID", novoFuncionario.idFuncionario);
                    cmd.Parameters.AddWithValue("@dataNascimento", novoFuncionario.dataNascimento);

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Método que cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Funcionário que será cadastrado </param>
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            // define a conexão con passando a string de conexão pelo parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // query a ser executada
                string queryCadastrar = "INSERT INTO funcionarios(nome, sobrenome, dataNascimento) VALUES (@nome, @sobrenome, @dataNascimento)";

                // Define SqlCommand cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryCadastrar, con))
                {
                    // abre a conexão com o banco de dados
                    con.Open();

                    // define valores às variáveis @nome, @sobrenome, @dataNascimento
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobreNome);
                    cmd.Parameters.AddWithValue("@dataNascimento", novoFuncionario.dataNascimento);

                    // executa a query
                    cmd.ExecuteNonQuery();
                }

            }

        }



        /// <summary>
        /// Deleta um funcionário pelo seu id
        /// </summary>
        /// <param name="id">id do funcionário que será deletado</param>
        public void Deletar(int id)
        {
            // define a conexão con passando a string de conexão pelo parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // query a ser executada
                string queryDelete = "DELETE FROM funcionarios WHERE idFuncionario = @ID";

                // Define SqlCommand cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // abre a conexão com o banco de dados
                    con.Open();

                    // define valor ao @id
                    cmd.Parameters.AddWithValue("@ID", id);

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Busca funcionário pelo seu id
        /// </summary>
        /// <param name="id">id do funcionário que será buscado</param>
        /// <returns>Um objeto funcionário encontrado ou null</returns>
        public FuncionarioDomain BuscarPorId(int id)
        {
            // define a conexão con passando a string de conexão pelo parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // query a ser executada
                string querySelectId = "SELECT * FROM funcionarios WHERE idFuncionario = @ID";

                // Define SqlCommand cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {
                    // abre a conexão com o banco de dados
                    con.Open();

                    // define valor a variável @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // armazena dados vindos do banco de dados
                    SqlDataReader rdr;

                    // executa a query e armazena o valor retornado na rdr
                    rdr = cmd.ExecuteReader();

                    // se tiver linhas para ler no rdr
                    if (rdr.Read())
                    {
                        // instancia um funcionário e adiciona os dados da rdr nele
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobreNome = rdr["sobrenome"].ToString(),
                            dataNascimento = Convert.ToDateTime(rdr["dataNascimento"])
                        };

                        // retorna funcionario
                        return funcionario;
                    }

                }
            }
            
            // retorna null
            return null;
        }


        /// <summary>
        /// Método que retorna uma lista de todos os funcionários
        /// </summary>
        /// <returns>Uma lista de funcionários</returns>
        public List<FuncionarioDomain> Listar()
        {   
            // Uma lista foi criada
            List<FuncionarioDomain> listaFuncionario = new List<FuncionarioDomain>();

            // define a conexão con passando a string de conexão pelo parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Query a ser executada
                string querySelect = "SELECT * FROM funcionarios";

                // Variável que armazena dados do banco de dados
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // abre a conexão com o banco
                    con.Open();

                    // executa a query e armazena os dados retornados na variável rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto existir linhas para ler no rdr, pegamos o índice de cada valor e adicionamos em um objeto
                    // em seus respectivos campos
                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobreNome = rdr["sobrenome"].ToString(),
                            dataNascimento = Convert.ToDateTime(rdr["dataNascimento"])
                        };

                        // adiciona o objeto na lista
                        listaFuncionario.Add(funcionario);
                    }

                }

            }

            // retorna a lista de funcionários
            return listaFuncionario;
        }

        

        /// <summary>
        /// Busca funcionario pelo nome
        /// </summary>
        /// <param name="nome">Nome do funcionario que será buscado</param>
        /// <returns>um objeto funcionario ou null</returns>
        public FuncionarioDomain BuscarPorNome(string nome)
        {
            // define a conexão con passando a string de conexão pelo parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // define a query a ser executada
                string querySelectNome = "SELECT * FROM funcionarios WHERE nome = @Nome";

                // Define SqlCommand cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectNome, con))
                {
                    // abre a conexão com o banco de dados
                    con.Open();

                    // define valor a variável @Nome
                    cmd.Parameters.AddWithValue("@Nome", nome);

                    // armazena dados do banco de dados
                    SqlDataReader rdr;
                        
                    // executa a query e armazena os dados retornados no rdr
                    rdr = cmd.ExecuteReader();
                    
                    // se tiver linhas para ler
                    if (rdr.Read())
                    {
                        // instancia um funcionário e adiciona os dados da rdr nele
                        FuncionarioDomain funcionarioEncontrado = new FuncionarioDomain()
                        {
                            idFuncionario   = Convert.ToInt32(rdr["idFuncionario"]),
                            nome            = rdr["nome"].ToString(),
                            sobreNome       = rdr["sobrenome"].ToString(),
                            dataNascimento  = Convert.ToDateTime(rdr["dataNascimento"])
                        };

                        // retorna o objeto funcionario encontrado
                        return funcionarioEncontrado;
                    }

                }

            }

            // retorna null
            return null;
        }


        public List<FuncionarioDomain> ListarPorOrdem(string ordem)
        {
            // Uma lista foi criada
            List<FuncionarioDomain> listaFuncionario = new List<FuncionarioDomain>();

            // define a conexão con passando a string de conexão pelo parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect;

                // Query a ser executada
                // Se ordem for desc, a query vai ser a que traz os dados em ordem decrescente
                // Senão, a ordem vai ser asc, que traz is dados em ordem crescente
                if (ordem == "desc")
                {
                    querySelect = "SELECT * FROM funcionarios ORDER BY idFuncionario DESC";
                }else
                {
                    querySelect = "SELECT * FROM funcionarios ORDER BY idFuncionario ASC";
                }


                // Variável que armazena dados do banco de dados
                SqlDataReader rdr;

                // Define a SqlCommand cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // abre a conexão com o banco
                    con.Open();

                    // executa a query e armazena os dados retornados na variável rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto existir linhas para ler no rdr, pegamos o índice de cada valor e adicionamos em um objeto
                    // em seus respectivos campos
                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobreNome = rdr["sobrenome"].ToString(),
                            dataNascimento = Convert.ToDateTime(rdr["dataNascimento"])
                        };

                        // adiciona o objeto na lista
                        listaFuncionario.Add(funcionario);
                    }

                }

            }

            // retorna a listaFuncionario
            return listaFuncionario;
        }



        /// <summary>
        /// Define objetos com nome completo dos funcionários
        /// </summary>
        /// <param name="listaFunc">lista de funcionarios</param>
        /// <returns>Lista de objects</returns>
        public List<object> ListarNomesCompletos(List<FuncionarioDomain> listaFunc)
        {
            // Instancia uma lista de objects
            List<object> lista = new List<object>();

            // percore a lista de funcionários
            foreach (var item in listaFunc)
            {
                // armazena na variável obj um json object que sua chave é nomeCompleto e seu valor é o nome completo do funcionário
                object obj = new { nomeCompleto = item.nome + " " + item.sobreNome };

                // adiciona a obj na lista
                lista.Add(obj);
            }

            // retorna a lista de objects
            return lista;
        }



    }
}
