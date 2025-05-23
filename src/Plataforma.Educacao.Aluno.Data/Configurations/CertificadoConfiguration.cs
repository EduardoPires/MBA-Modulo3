﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Plataforma.Educacao.Aluno.Domain.Entities;
using Plataforma.Educacao.Core.Data.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Plataforma.Educacao.Aluno.Data.Configurations;

[ExcludeFromCodeCoverage]
public class CertificadoConfiguration : IEntityTypeConfiguration<Certificado>
{
    public void Configure(EntityTypeBuilder<Certificado> builder)
    {
        #region Mapping columns
        builder.ToTable("Certificados");

        builder.HasKey(x => x.Id)
                .HasName("CertificadosPK");

        builder.Property(x => x.Id)
            .HasColumnName("CertificadoId")
            .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
            .IsRequired();

        builder.Property(x => x.MatriculaCursoId)
            .HasColumnName("MatriculaCursoId")
            .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
            .IsRequired();

        builder.Property(x => x.DataSolicitacao)
            .HasColumnName("DataSolicitacao")
            .HasColumnType(DatabaseTypeConstant.SmallDateTime)
            .IsRequired();

        builder.Property(x => x.PathCertificado)
            .HasColumnName("PathCertificado")
            .HasColumnType(DatabaseTypeConstant.Varchar)
            .HasMaxLength(1024)
            .UseCollation(DatabaseTypeConstant.Collate)
            .IsRequired();
        #endregion Mapping columns

        #region Indexes
        builder.HasIndex(x => x.MatriculaCursoId).HasDatabaseName("CertificadosMatriculaCursoIdIDX");
        #endregion Indexes

        #region Relationships

        builder.HasOne(x => x.MatriculaCurso)
           .WithOne(x => x.Certificado)
           .HasForeignKey<Certificado>(x => x.MatriculaCursoId)
           .HasConstraintName("CertificadoMatriculaCursoFK")
           .OnDelete(DeleteBehavior.Cascade);

        #endregion Relationships
    }
}
