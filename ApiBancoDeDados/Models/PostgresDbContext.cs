using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiBancoDeDados.Models
{
    public partial class PostgresDbContext : DbContext
    {

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options): base(options)
        {
        }

        public virtual DbSet<Alimentos> Alimentos { get; set; } = null!;
        public virtual DbSet<AlimentoDieta> AlimentoDieta { get; set; } = null!;
        public virtual DbSet<Animais> Animais { get; set; } = null!;
        public virtual DbSet<ConsultasVeterinarias> ConsultasVeterinarias { get; set; } = null!;
        public virtual DbSet<Dieta> Dieta { get; set; } = null!;
        public virtual DbSet<Especies> Especies { get; set; } = null!;
        public virtual DbSet<Funcionarios> Funcionarios { get; set; } = null!;
        public virtual DbSet<Funcoes> Funcoes { get; set; } = null!;
        public virtual DbSet<Habitats> Habitats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum("grupos_alimentares", new[] { "CEREAIS", " PAES E TUBERCULOS", "HORTALICAS", "FRUTAS", "LEGUMINOSAS", "CARNES E OVOS", "LEITE E DERIVADOS", "OLEOS E GORDURAS", "ACUCARES E DOCES" })
                .HasPostgresEnum("sexo_biologico", new[] { "M", "F" });

            modelBuilder.Entity<Alimentos>(entity =>
            {
                entity.ToTable("alimento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<AlimentoDieta>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("alimento_dieta");

                entity.Property(e => e.IdAlimento).HasColumnName("id_alimento");

                entity.Property(e => e.IdDieta).HasColumnName("id_dieta");

                entity.HasOne(d => d.IdAlimentoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAlimento)
                    .HasConstraintName("fk_alimento");

                entity.HasOne(d => d.IdDietaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdDieta)
                    .HasConstraintName("fk_dieta");
            });

            modelBuilder.Entity<Animais>(entity =>
            {
                entity.ToTable("animais");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EspecieId).HasColumnName("especie_id");

                entity.Property(e => e.HistoricoSaude)
                    .HasMaxLength(255)
                    .HasColumnName("historico_saude");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.HasOne(d => d.Especie)
                    .WithMany(p => p.Animais)
                    .HasForeignKey(d => d.EspecieId)
                    .HasConstraintName("fk_especie");
            });

            modelBuilder.Entity<ConsultasVeterinarias>(entity =>
            {
                entity.ToTable("consultas_veterinarias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataConsulta).HasColumnName("data_consulta");

                entity.Property(e => e.Diagnostico)
                    .HasMaxLength(100)
                    .HasColumnName("diagnostico");

                entity.Property(e => e.IdAnimal).HasColumnName("id_animal");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.Prognostico)
                    .HasMaxLength(100)
                    .HasColumnName("prognostico");

                entity.Property(e => e.Tratamento)
                    .HasMaxLength(255)
                    .HasColumnName("tratamento");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.ConsultasVeterinaria)
                    .HasForeignKey(d => d.IdAnimal)
                    .HasConstraintName("fk_animal");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.ConsultasVeterinaria)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("fk_funcionario");
            });

            modelBuilder.Entity<Dieta>(entity =>
            {
                entity.ToTable("dieta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            });

            modelBuilder.Entity<Especies>(entity =>
            {
                entity.ToTable("especies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alimentacao)
                    .HasMaxLength(255)
                    .HasColumnName("alimentacao");

                entity.Property(e => e.ExpectativaDeVidaEmMeses).HasColumnName("expectativa_de_vida_em_meses");

                entity.Property(e => e.IdHabitat).HasColumnName("id_habitat");

                entity.Property(e => e.NomeCientifico)
                    .HasMaxLength(75)
                    .HasColumnName("nome_cientifico");

                entity.HasOne(d => d.IdHabitatNavigation)
                    .WithMany(p => p.Especies)
                    .HasForeignKey(d => d.IdHabitat)
                    .HasConstraintName("fk_habitat");
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.ToTable("funcionarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");

                entity.Property(e => e.Escala)
                    .HasMaxLength(255)
                    .HasColumnName("escala");

                entity.Property(e => e.IdFuncao).HasColumnName("id_funcao");

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.HasOne(d => d.IdFuncaoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdFuncao)
                    .HasConstraintName("fk_funcao");
            });

            modelBuilder.Entity<Funcoes>(entity =>
            {
                entity.ToTable("funcoes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Habitats>(entity =>
            {
                entity.ToTable("habitats");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CondicoesClimaticas)
                    .HasMaxLength(200)
                    .HasColumnName("condicoes_climaticas");

                entity.Property(e => e.FrequenciaLimpezaEmDias).HasColumnName("frequencia_limpeza_em_dias");

                entity.Property(e => e.Temperatura).HasColumnName("temperatura");

                entity.Property(e => e.TipoAmbiente)
                    .HasMaxLength(70)
                    .HasColumnName("tipo_ambiente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
