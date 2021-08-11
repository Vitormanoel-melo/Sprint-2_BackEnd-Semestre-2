using Microsoft.EntityFrameworkCore;
using senai_inlock_webApi_CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi_CodeFirst.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto 
    /// O contexto faz a comunicação entre a API e o Banco de dados
    /// </summary>
    public class InLockContext : DbContext
    {
        // Define as entidades do banco de dados
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estudios> Estudios { get; set; }
        public DbSet<Jogos> Jogos { get; set; }

        /// <summary>
        /// Define as opções de construção do banco de dados
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-70KR9CNR; Database=InLock_Games_CodeFirst; user Id=sa; pwd=senai@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define as entidades já com dados
            modelBuilder.Entity<TiposUsuario>().HasData(
                    new TiposUsuario
                    {
                        idTipoUsuario = 1,
                        titulo = "Admininistrador"
                    },
                    new TiposUsuario
                    {
                        idTipoUsuario = 2,
                        titulo = "Cliente"
                    }
                );

            modelBuilder.Entity<Usuarios>(entity => 
            {
                entity.HasData(
                    new Usuarios
                    {
                        idUsuario = 1,
                        email = "admin@admin.com",
                        senha = "admin",
                        idTipoUsuario = 1
                    },
                    new Usuarios
                    {
                        idUsuario = 2,
                        email = "cliente@cliente.com",
                        senha = "cliente",
                        idTipoUsuario = 2
                    });

                // Cria um índice que define que o campo e-mail é único
                entity.HasIndex(u => u.email).IsUnique();
            });


            modelBuilder.Entity<Estudios>(entity => 
            {
                entity.HasData(
                    new Estudios { idEstudio = 1, nomeEstudio = "Blizzard" },
                    new Estudios { idEstudio = 2, nomeEstudio = "Rockstar Games" },
                    new Estudios { idEstudio = 3, nomeEstudio = "Square Enix" });

                entity.HasIndex(e => e.nomeEstudio).IsUnique();
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.HasData(
                        new Jogos
                        {
                            idJogo = 1,
                            nomeJogo = "Diablo 3",
                            dataLancamento = Convert.ToDateTime("15/05/2012"),
                            descricao = "Jogo que contém bastante ação!",
                            valor = Convert.ToDecimal("99,00"),
                            idEstudio = 1
                        },
                        new Jogos
                        {
                            idJogo = 2,
                            nomeJogo = "Read Dead Redemption II",
                            dataLancamento = Convert.ToDateTime("26/10/2018"),
                            descricao = "Jogo que contém bastante ação e avertura western",
                            valor = Convert.ToDecimal("120,00"),
                            idEstudio = 3
                        }
                    );

                entity.HasIndex(j => j.nomeJogo).IsUnique();
            });


            base.OnModelCreating(modelBuilder);
        }


    }
}
