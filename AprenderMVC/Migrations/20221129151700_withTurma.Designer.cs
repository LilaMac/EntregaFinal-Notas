﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AprenderMVC.Migrations
{
    [DbContext(typeof(AprenderMVCContext))]
    [Migration("20221129151700_withTurma")]
    partial class withTurma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AprenderMVC.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("AprenderMVC.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cargahoraria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdArea")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IdArea");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("AprenderMVC.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdTipo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Tel")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdTipo");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("AprenderMVC.Models.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("AprenderMVC.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DtFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCurso");

                    b.HasIndex("IdPessoa");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("AprenderMVC.Models.Curso", b =>
                {
                    b.HasOne("AprenderMVC.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("AprenderMVC.Models.Pessoa", b =>
                {
                    b.HasOne("AprenderMVC.Models.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("IdTipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("AprenderMVC.Models.Turma", b =>
                {
                    b.HasOne("AprenderMVC.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("IdCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprenderMVC.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
