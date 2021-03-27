using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{   
    // Interface responsável pelo repositório FilmeRepository
    interface IFilmeRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// Lista de todos os Filmes
        /// </summary>
        /// <returns> Uma lista de filmes </returns>
        List<FilmeDomain> ListarTodos();


        /// <summary>
        /// Busca um filme através de seu id
        /// </summary>
        /// <param name="id"> id do filme que será buscado </param>
        /// <returns> Um objeto filme que foi buscado </returns>
        GeneroDomain BuscarPorId(int id);


        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoGenero"> Objeto novo com as informações que serão cadastradas </param>
        void Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero"> Objeto filme com as novas informações </param>
        void AtualizarIdCorpo(GeneroDomain genero);


        /// <summary>
        /// Atualiza um filme existente passando um id pela url da requisição
        /// </summary>
        /// <param name="id"> id do filme que será atualizado </param>
        /// <param name="novoGenero"> Objeto filme com as novas informações </param>
        void AtualizarIdUrl(int id, GeneroDomain novoGenero);


        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id"> id do filme que será deletado </param>
        void Deletar(int id);
    }
}
