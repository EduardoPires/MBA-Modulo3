﻿using FluentAssertions;
using Plataforma.Educacao.Conteudo.Domain.ValueObjects;
using Plataforma.Educacao.Core.Exceptions;

namespace Plataforma.Educacao.Conteudo.Domain.Tests;
public class ConteudoProgramaticoTests
{
    #region Helpers
    private const string _finalidadeValida = "Formar o aluno em conceitos de DDD";
    private const string _ementaValida = "Conceitos básicos e avançados de Domain Driven Design, com suporte a CQRS e mais um monte de coisas que você não pode perder";

    private ConteudoProgramatico CriarInstanciaConteudo(string finalidade = _finalidadeValida, 
        string ementa = _ementaValida)
    {
        return new ConteudoProgramatico(finalidade, ementa);
    }
    #endregion

    #region Construtores
    [Fact]
    public void Deve_criar_conteudo_programatico_valido()
    {
        // Arrange

        // Act
        var conteudo = CriarInstanciaConteudo(_finalidadeValida, _ementaValida);

        // Assert
        conteudo.Should().NotBeNull();
        conteudo.Finalidade.Should().Be(_finalidadeValida);
        conteudo.Ementa.Should().Be(_ementaValida);
    }

    [Theory]
    [InlineData("", _ementaValida, "*Finalidade não pode ser vazia ou nula*")]
    [InlineData("abc", _ementaValida, "*Finalidade do conteúdo programático deve ter entre 10 e 100 caracteres*")]
    [InlineData(_finalidadeValida, "", "*Ementa do conteúdo programático não pode ser vazia ou nula*")]
    [InlineData(_finalidadeValida, "abc", "*Ementa do conteúdo programático deve ter entre 50 e 4000 caracteres*")]
    public void Nao_deve_criar_conteudo_invalido(string finalidade, string ementa, string mensagemErro)
    {
        Action act = () => CriarInstanciaConteudo(finalidade, ementa);

        act.Should().Throw<DomainException>()
           .WithMessage(mensagemErro);
    }
    #endregion

    #region Setters
    [Theory]
    [InlineData("", "*Finalidade não pode ser vazia ou nula*")]
    [InlineData("abc", "*Finalidade do conteúdo programático deve ter entre 10 e 100 caracteres*")]
    public void Nao_deve_alterar_finalidade_invalida(string finalidade, string mensagemErro)
    {
        // Arrange
        var conteudo = CriarInstanciaConteudo();

        // Act
        Action act = () => conteudo.AlterarFinalidade(finalidade);

        // Assert
        act.Should().Throw<DomainException>()
           .WithMessage(mensagemErro);
    }

    [Fact]
    public void Deve_alterar_finalidade_valida()
    {
        // Arrange
        var novaFinalidade = "Curso atualizado de DDD";
        var conteudo = CriarInstanciaConteudo();

        // Act
        conteudo.AlterarFinalidade(novaFinalidade);

        // Assert
        conteudo.Finalidade.Should().Be(novaFinalidade);
    }

    [Theory]
    [InlineData("", "*Ementa do conteúdo programático não pode ser vazia ou nula*")]
    [InlineData("abc", "*Ementa do conteúdo programático deve ter entre 50 e 4000 caracteres*")]
    public void Nao_deve_alterar_ementa_invalida(string ementa, string mensagemErro)
    {
        // Arrange
        var conteudo = CriarInstanciaConteudo();

        // Act
        Action act = () => conteudo.AlterarEmenta(ementa);

        // Assert
        act.Should().Throw<DomainException>()
           .WithMessage(mensagemErro);
    }

    [Fact]
    public void Deve_alterar_ementa_valida()
    {
        // Arrange
        var novaEmenta = "Conceitos básicos, intermediários e avançados de Domain Driven Design, com suporte a CQRS e mais um monte de coisas que você não pode perder";
        var conteudo = CriarInstanciaConteudo();

        // Act
        conteudo.AlterarEmenta(novaEmenta);

        // Assert
        conteudo.Ementa.Should().Be(novaEmenta);
    }
    #endregion

    #region Comparações
    [Fact]
    public void Conteudos_programaticos_iguais_devem_ser_tratados_como_iguais()
    {
        // Arrange
        var conteudo1 = CriarInstanciaConteudo();
        var conteudo2 = CriarInstanciaConteudo();

        // Assert
        conteudo1.Should().Be(conteudo2);
        conteudo1.GetHashCode().Should().Be(conteudo2.GetHashCode());
    }

    [Fact]
    public void Conteudos_programaticos_diferentes_nao_devem_ser_iguais()
    {
        // Arrange
        var conteudo1 = CriarInstanciaConteudo();
        var conteudo2 = CriarInstanciaConteudo("Nova finalidade", _ementaValida);

        // Assert
        conteudo1.Should().NotBe(conteudo2);
    }
    #endregion
}