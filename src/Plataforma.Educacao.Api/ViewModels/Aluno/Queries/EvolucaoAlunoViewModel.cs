﻿namespace Plataforma.Educacao.Api.ViewModels.Aluno.Queries;
public class EvolucaoAlunoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }

    public ICollection<EvolucaoMatriculaCursoViewModel> MatriculasCursos { get; set; }
}
