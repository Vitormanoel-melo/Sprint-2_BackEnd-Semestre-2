using Microsoft.EntityFrameworkCore;
using senai_inlock_webApi_DBFirst.Contexts;
using senai_inlock_webApi_DBFirst.Domains;
using senai_inlock_webApi_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi_DBFirst.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos Estúdios
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto contexto
        /// </summary>
        InLockContext ctx = new InLockContext();

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        public void Atualizar(int id, Estudio estudioAtualizado)
        {
            // Busca um estúdio através do seu id
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            // se o nome do estudioAtualizado foi informado
            if (estudioAtualizado.NomeEstudio != null)
            {
                // atribui os novos valores aos campos existestes
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            // atualiza o estúdio que foi buscado
            ctx.Estudios.Update(estudioBuscado);

            // salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um estúdio através de seu id
        /// </summary>
        /// <param name="id">id do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado</returns>
        public Estudio BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        /// <summary>
        /// Cadastra um estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        public void Cadastrar(Estudio novoEstudio)
        {
            // Adiciona esse novo estúdio
            ctx.Estudios.Add(novoEstudio);

            // Salva as informações para serem persistidas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um estúdio através do seu id   
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            // Remove o estúdio que foi buscado
            ctx.Estudios.Remove(estudioBuscado);

            // Salva as alteerações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        public List<Estudio> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }


        /// <summary>
        /// Lista todos os estúdios com a lista de jogos
        /// </summary>
        /// <returns>Lista de estúdios com a lista de jogos</returns>
        public List<Estudio> ListarJogos()
        {
            // Retorna uma lista estúdios com seus jogos
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }


    }
}
