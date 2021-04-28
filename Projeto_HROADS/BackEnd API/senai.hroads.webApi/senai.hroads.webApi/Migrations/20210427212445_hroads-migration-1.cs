using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace senai.hroads.webApi.Migrations
{
    public partial class hroadsmigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposHabilidade",
                columns: table => new
                {
                    idTipoHabilidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHabilidade", x => x.idTipoHabilidade);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    sobrenome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TiposUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassesHabilidade",
                columns: table => new
                {
                    idClasseHabilidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idClasse = table.Column<int>(type: "int", nullable: false),
                    idHabilidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesHabilidade", x => x.idClasseHabilidade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    idClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    ClassesHabilidadeidClasseHabilidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.idClasse);
                    table.ForeignKey(
                        name: "FK_Classes_ClassesHabilidade_ClassesHabilidadeidClasseHabilidade",
                        column: x => x.ClassesHabilidadeidClasseHabilidade,
                        principalTable: "ClassesHabilidade",
                        principalColumn: "idClasseHabilidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    idHabilidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    idTipoHabilidade = table.Column<int>(type: "int", nullable: false),
                    ClassesHabilidadeidClasseHabilidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.idHabilidade);
                    table.ForeignKey(
                        name: "FK_Habilidades_ClassesHabilidade_ClassesHabilidadeidClasseHabilidade",
                        column: x => x.ClassesHabilidadeidClasseHabilidade,
                        principalTable: "ClassesHabilidade",
                        principalColumn: "idClasseHabilidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Habilidades_TiposHabilidade_idTipoHabilidade",
                        column: x => x.idTipoHabilidade,
                        principalTable: "TiposHabilidade",
                        principalColumn: "idTipoHabilidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    idPersonagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    MaxVida = table.Column<int>(type: "int", nullable: false),
                    MaxMana = table.Column<int>(type: "int", nullable: false),
                    dataAtualização = table.Column<DateTime>(type: "DATE", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "DATE", nullable: false),
                    idClasse = table.Column<int>(type: "int", nullable: false),
                    UsuariosidUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.idPersonagem);
                    table.ForeignKey(
                        name: "FK_Personagens_Classes_idClasse",
                        column: x => x.idClasse,
                        principalTable: "Classes",
                        principalColumn: "idClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personagens_Usuarios_UsuariosidUsuario",
                        column: x => x.UsuariosidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "idClasse", "ClassesHabilidadeidClasseHabilidade", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Bárbaro" },
                    { 2, null, "Cruzado" },
                    { 3, null, "Caçadora de Demônios" },
                    { 4, null, "Monge" },
                    { 5, null, "Necromancer" },
                    { 6, null, "Feiticeiro" },
                    { 7, null, "Arcanista" }
                });

            migrationBuilder.InsertData(
                table: "TiposHabilidade",
                columns: new[] { "idTipoHabilidade", "titulo" },
                values: new object[,]
                {
                    { 1, "Ataque" },
                    { 2, "Defesa" },
                    { 3, "Cura" },
                    { 4, "Magia" }
                });

            migrationBuilder.InsertData(
                table: "TiposUsuario",
                columns: new[] { "idTipoUsuario", "titulo" },
                values: new object[,]
                {
                    { 1, "ADMINISTRADOR" },
                    { 2, "JOGADOR" }
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "idHabilidade", "ClassesHabilidadeidClasseHabilidade", "idTipoHabilidade", "nome" },
                values: new object[,]
                {
                    { 1, null, 1, "Lança Mortal" },
                    { 2, null, 2, "Escudo Supremo" },
                    { 3, null, 3, "Recuperar Vida" }
                });

            migrationBuilder.InsertData(
                table: "Personagens",
                columns: new[] { "idPersonagem", "MaxMana", "MaxVida", "UsuariosidUsuario", "dataAtualização", "dataCriacao", "idClasse", "nome" },
                values: new object[,]
                {
                    { 1, 80, 100, null, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DeuBug" },
                    { 2, 100, 70, null, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "BitBug" },
                    { 3, 60, 75, null, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Fer7" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "nome", "senha", "sobrenome" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", 1, "Admin", "admin", "Adm" },
                    { 2, "jogador@jogador.com", 2, "Jogador", "jogador", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassesHabilidadeidClasseHabilidade",
                table: "Classes",
                column: "ClassesHabilidadeidClasseHabilidade");

            migrationBuilder.CreateIndex(
                name: "IX_ClassesHabilidade_idClasse",
                table: "ClassesHabilidade",
                column: "idClasse");

            migrationBuilder.CreateIndex(
                name: "IX_ClassesHabilidade_idHabilidade",
                table: "ClassesHabilidade",
                column: "idHabilidade");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_ClassesHabilidadeidClasseHabilidade",
                table: "Habilidades",
                column: "ClassesHabilidadeidClasseHabilidade");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_idTipoHabilidade",
                table: "Habilidades",
                column: "idTipoHabilidade");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_idClasse",
                table: "Personagens",
                column: "idClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_UsuariosidUsuario",
                table: "Personagens",
                column: "UsuariosidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TiposUsuario_titulo",
                table: "TiposUsuario",
                column: "titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_email",
                table: "Usuarios",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idTipoUsuario",
                table: "Usuarios",
                column: "idTipoUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesHabilidade_Classes_idClasse",
                table: "ClassesHabilidade",
                column: "idClasse",
                principalTable: "Classes",
                principalColumn: "idClasse",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesHabilidade_Habilidades_idHabilidade",
                table: "ClassesHabilidade",
                column: "idHabilidade",
                principalTable: "Habilidades",
                principalColumn: "idHabilidade",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_ClassesHabilidade_ClassesHabilidadeidClasseHabilidade",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_ClassesHabilidade_ClassesHabilidadeidClasseHabilidade",
                table: "Habilidades");

            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposUsuario");

            migrationBuilder.DropTable(
                name: "ClassesHabilidade");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "TiposHabilidade");
        }
    }
}
