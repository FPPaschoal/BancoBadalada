using System;
using System.Collections.Generic;
using BancoBadalada.Services;
using Microsoft.EntityFrameworkCore;

namespace BancoBadalada.Models;

public partial class AcademicoContext : DbContext
{
    public AcademicoContext(DbContextOptions<AcademicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCurso> TbCursos { get; set; }

    public virtual DbSet<TbCursosOferecido> TbCursosOferecidos { get; set; }

    public virtual DbSet<TbDepartamento> TbDepartamentos { get; set; }

    public virtual DbSet<TbEmpregado> TbEmpregados { get; set; }

    public virtual DbSet<TbGradesSalario> TbGradesSalarios { get; set; }

    public virtual DbSet<TbHistorico> TbHistoricos { get; set; }

    public virtual DbSet<TbMatricula> TbMatriculas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCurso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("pk_tb_cursos_id_curso");

            entity.Property(e => e.Categoria).IsFixedLength();
        });

        modelBuilder.Entity<TbCursosOferecido>(entity =>
        {
            entity.HasKey(e => new { e.IdCurso, e.DtInicio }).HasName("pk_tb_cursos_oferecidos_");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.TbCursosOferecidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_cursos_oferecidos_id_curso");

            entity.HasOne(d => d.IdInstrutorNavigation).WithMany(p => p.TbCursosOferecidos).HasConstraintName("fk_tb_cursos_oferecidos_id_instrutor");
        });

        modelBuilder.Entity<TbDepartamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("pk_tb_departamentos_id_depto");

            entity.Property(e => e.IdDepartamento).ValueGeneratedNever();

            entity.HasOne(d => d.IdGerenteNavigation).WithMany(p => p.TbDepartamentos).HasConstraintName("fk_tb_departamentos_id_gerente");
        });

        modelBuilder.Entity<TbEmpregado>(entity =>
        {
            entity.HasKey(e => e.IdEmpregado).HasName("pk_tb_emp_id_emp");

            entity.Property(e => e.IdEmpregado).ValueGeneratedNever();
            entity.Property(e => e.IdDepartamento).HasDefaultValueSql("((10))");

            entity.HasOne(d => d.IdGerenteNavigation).WithMany(p => p.InverseIdGerenteNavigation).HasConstraintName("fk_tb_emp_id_gerente");
        });

        modelBuilder.Entity<TbGradesSalario>(entity =>
        {
            entity.HasKey(e => e.IdGrade).HasName("pk_tb_grades_id_grade");

            entity.Property(e => e.IdGrade).ValueGeneratedNever();
        });

        modelBuilder.Entity<TbHistorico>(entity =>
        {
            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.TbHistoricos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_historicos_id_depto");

            entity.HasOne(d => d.IdEmpregadoNavigation).WithMany(p => p.TbHistoricos).HasConstraintName("fk_tb_historicos_id_emp");
        });

        modelBuilder.Entity<TbMatricula>(entity =>
        {
            entity.HasKey(e => new { e.IdParticipante, e.IdCurso, e.DtInicio }).HasName("pk_tb_matriculas");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.TbMatriculas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_matriculas_id_participante");

            entity.HasOne(d => d.TbCursosOferecido).WithMany(p => p.TbMatriculas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_matriculas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
