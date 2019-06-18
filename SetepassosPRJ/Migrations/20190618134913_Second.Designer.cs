﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SetepassosPRJ.Models;

namespace SetepassosPRJ.Migrations
{
    [DbContext(typeof(SetePassosDbContext))]
    [Migration("20190618134913_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SetepassosPRJ.Models.HighScore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Chave");

                    b.Property<int>("FugasInimigos");

                    b.Property<int>("InimigosVencidos");

                    b.Property<int>("IntensEcontrados");

                    b.Property<int>("InvestigacoesArea");

                    b.Property<string>("Nome");

                    b.Property<int>("PocoesTotal");

                    b.Property<int>("PocoesUsadas");

                    b.Property<int>("ResultadoFinal");

                    b.Property<int>("Score");

                    b.HasKey("ID");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("SetepassosPRJ.Models.TeamMember", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEquipa");

                    b.Property<string>("NomeMembroEquipa");

                    b.Property<int>("NrAlunoMembroEquipa");

                    b.HasKey("ID");

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
