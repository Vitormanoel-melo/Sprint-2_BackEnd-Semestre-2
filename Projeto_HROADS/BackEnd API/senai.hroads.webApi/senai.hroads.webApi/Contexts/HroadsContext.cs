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
        public DbSet<Classes> Classes { get; set; }
        public DbSet<TiposHabilidade> TiposHabilidade { get; set; }
        public DbSet<Habilidades> Habilidades { get; set; }
        public DbSet<ClassesHabilidade> ClasseHabilidade { get; set; }
        public DbSet<Personagens> Personagens { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-70KR9CNR; Database=HROADS_SENAI_TARDE; user Id=sa; pwd=senai@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasData(
                    new Classes { idClasse = 1, nomeClasse = "Bárbaro" },
                    new Classes { idClasse = 2, nomeClasse = "Cruzado" },
                    new Classes { idClasse = 3, nomeClasse = "Caçadora" },
                    new Classes { idClasse = 4, nomeClasse = "Monge" },
                    new Classes { idClasse = 5, nomeClasse = "Necromante" },
                    new Classes { idClasse = 6, nomeClasse = "Feiticeiro" },
                    new Classes { idClasse = 7, nomeClasse = "Arcanista" });

                entity.HasIndex(c => c.nomeClasse).IsUnique();
            });


            modelBuilder.Entity<TiposHabilidade>().HasData(
               new TiposHabilidade { idTipoHabilidade = 1, titulo = "Ataque" },
               new TiposHabilidade { idTipoHabilidade = 2, titulo = "Defesa", },
               new TiposHabilidade { idTipoHabilidade = 3, titulo = "Cura", },
               new TiposHabilidade { idTipoHabilidade = 4, titulo = "Magia", });

            modelBuilder.Entity<Habilidades>().HasData(
               new Habilidades { idHabilidade = 1, nome = "Lança Mortal", idTipoHabilidade = 1 },
               new Habilidades { idHabilidade = 2, nome = "Escudo Supremo", idTipoHabilidade = 2 },
               new Habilidades { idHabilidade = 3, nome = "Recuperar Vida", idTipoHabilidade = 3 });


            modelBuilder.Entity<Personagens>(entity =>
            {
                entity.HasData(
                    new Personagens { idPersonagem = 1, idClasse = 1, nome = "DeuBug", MaxVida = 100, MaxMana = 80, dataAtualização = Convert.ToDateTime("02/03/2021"), dataCriacao = Convert.ToDateTime("18/01/2019") },
                    new Personagens { idPersonagem = 2, idClasse = 4, nome = "BitBug", MaxVida = 70, MaxMana = 100, dataAtualização = Convert.ToDateTime("02/03/2021"), dataCriacao = Convert.ToDateTime("17/03/2016") },
                    new Personagens { idPersonagem = 3, idClasse = 7, nome = "Fer8", MaxVida = 75, MaxMana = 60, dataAtualização = Convert.ToDateTime("02/03/2021"), dataCriacao = Convert.ToDateTime("18/03/2018") });

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
