using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">Id do usuário que será cadastrado</param>
        /// <param name="personagemAtualizado">Objeto personagemAtualizado com as novas informações</param>
        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = BuscarPorId(id);

            if (personagemAtualizado.nome != null)
            {
                Personagem buscarPorNome = ctx.Personagens.FirstOrDefault(p => p.nome == personagemAtualizado.nome);

                if (buscarPorNome == null)
                {
                    personagemBuscado.nome = personagemAtualizado.nome;
                }
            }

            if (personagemAtualizado.MaxVida >= 10 && personagemAtualizado.MaxVida <= 100)
            {
                personagemBuscado.MaxVida = personagemAtualizado.MaxVida;
            }

            if (personagemAtualizado.MaxMana >= 10 && personagemAtualizado.MaxMana <= 100)
            {
                personagemBuscado.MaxMana = personagemAtualizado.MaxMana;
            }

            if (ctx.Classes.Find(personagemAtualizado.idClasse) != null)
            {
                personagemBuscado.idClasse = personagemAtualizado.idClasse;
            }

            personagemBuscado.dataAtualização = DateTime.Now;

            ctx.Personagens.Update(personagemBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um personagem pelo id
        /// </summary>
        /// <param name="id">Id do personagem que será buscado</param>
        /// <returns>Um Personagem encontrado</returns>
        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagens.Include(p => p.classe).FirstOrDefault(p => p.idPersonagem == id);
        }

        public Personagem BuscarPorNome(string nome)
        {
            return ctx.Personagens.FirstOrDefault(p => p.nome == nome);
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com as informações para cadastro</param>
        public void Cadastrar(Personagem novoPersonagem)
        {
            novoPersonagem.dataCriacao = DateTime.Now;
            novoPersonagem.dataAtualização = DateTime.Now;

            switch (novoPersonagem.MaxVida)
            {
                case > 100:
                    novoPersonagem.MaxVida = 100;
                    break;

                case < 10:
                    novoPersonagem.MaxVida = 10;
                    break;

                default:
                    novoPersonagem.MaxVida= 50;
                    break;
            }

            switch (novoPersonagem.MaxMana)
            {
                case > 100:
                    novoPersonagem.MaxMana = 100;
                    break;

                case < 10:
                    novoPersonagem.MaxMana = 10;
                    break;

                default:
                    novoPersonagem.MaxMana = 50;
                    break;
            }

            ctx.Personagens.Add(novoPersonagem);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um personagem pelo id
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        public void Deletar(int id)
        {
            Personagem personagem = BuscarPorId(id);

            ctx.Personagens.Remove(personagem);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        public List<Personagem> Listar()
        {
            return ctx.Personagens.Include(p => p.classe).OrderBy(p => p.classe.nomeClasse).ToList();
        }

    }
}
