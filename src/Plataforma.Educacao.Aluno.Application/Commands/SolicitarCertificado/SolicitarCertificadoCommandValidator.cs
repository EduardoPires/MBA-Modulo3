﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Educacao.Aluno.Application.Commands.SolicitarCertificado;
public class SolicitarCertificadoCommandValidator : AbstractValidator<SolicitarCertificadoCommand>
{
    public SolicitarCertificadoCommandValidator()
    {
        RuleFor(c => c.AlunoId).NotEqual(Guid.Empty).WithMessage("Id do aluno inválido.");
        RuleFor(c => c.MatriculaCursoId).NotEqual(Guid.Empty).WithMessage("Id da matrícula inválido.");
        RuleFor(c => c.PathCertificado).NotEmpty().WithMessage("O caminho do certificado é obrigatório.");
    }
}
