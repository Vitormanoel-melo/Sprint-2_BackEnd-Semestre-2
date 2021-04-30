using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Contexts
{
    public class HroadsContext : DbContext
    {
        public DbSet<Classe> Classes { get; set; }
        public DbSet<TipoHabilidadeDomain> TiposHabilidade { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<ClassesHabilidade> ClasseHabilidade { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-70KR9CNR; Database=HROADS_SENAI_TARDE; user Id=sa; pwd=senai@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasData(
                    new Classe { idClasse = 1, nomeClasse = "Bárbaro" },
                    new Classe { idClasse = 2, nomeClasse = "Cruzado" },
                    new Classe { idClasse = 3, nomeClasse = "Caçadora" },
                    new Classe { idClasse = 4, nomeClasse = "Monge" },
                    new Classe { idClasse = 5, nomeClasse = "Necromante" },
                    new Classe { idClasse = 6, nomeClasse = "Feiticeiro" },
                    new Classe { idClasse = 7, nomeClasse = "Arcanista" });

                entity.HasIndex(c => c.nomeClasse).IsUnique();
            });


            modelBuilder.Entity<TipoHabilidadeDomain>().HasData(
               new TipoHabilidadeDomain { idTipoHabilidade = 1, titulo = "Ataque" },
               new TipoHabilidadeDomain { idTipoHabilidade = 2, titulo = "Defesa", },
               new TipoHabilidadeDomain { idTipoHabilidade = 3, titulo = "Cura", },
               new TipoHabilidadeDomain { idTipoHabilidade = 4, titulo = "Magia", });

            modelBuilder.Entity<Habilidade>().HasData(
               new Habilidade { idHabilidade = 1, nome = "Lança Mortal", idTipoHabilidade = 1 },
               new Habilidade { idHabilidade = 2, nome = "Escudo Supremo", idTipoHabilidade = 2 },
               new Habilidade { idHabilidade = 3, nome = "Recuperar Vida", idTipoHabilidade = 3 });


            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasData(
                    new Personagem { idPersonagem = 1, idClasse = 1, nome = "DeuBug", MaxVida = 100, MaxMana = 80, dataAtualização = Convert.ToDateTime("02/03/2021"), dataCriacao = Convert.ToDateTime("18/01/2019") },
                    new Personagem { idPersonagem = 2, idClasse = 4, nome = "BitBug", MaxVida = 70, MaxMana = 100, dataAtualização = Convert.ToDateTime("02/03/2021"), dataCriacao = Convert.ToDateTime("17/03/2016") },
                    new Personagem { idPersonagem = 3, idClasse = 7, nome = "Fer8", MaxVida = 75, MaxMana = 60, dataAtualização = Convert.ToDateTime("02/03/2021"), dataCriacao = Convert.ToDateTime("18/03/2018") });

                entity.HasIndex(p => p.nome).IsUnique();
            });


            modelBuilder.Entity<TiposUsuario>().HasData(
                new TiposUsuario { idTipoUsuario = 1, titulo = "administrador" },
                new TiposUsuario { idTipoUsuario = 2, titulo = "jogador" });


            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasData(
                    new Usuarios
                    {
                        idUsuario = 1,
                        nome = "Admin",
                        sobrenome = "adm",
                        email = "admin@admin.com",
                        senha = "admin",
                        idTipoUsuario = 1
                    },
                    new Usuarios
                    {
                        idUsuario = 2,
                        nome = "Jogador",
                        sobrenome = "2",
                        email = "jogador@gmail.com",
                        senha = "jogador",
                        idTipoUsuario = 2
                    }

                    );
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
