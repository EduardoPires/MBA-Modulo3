@echo off
setlocal

echo === Limpando relatorios antigos ===
if exist coverage-report rmdir /s /q coverage-report

echo === Limpando testes antigos ===
set "testesCaminho=."
for /d /r %testesCaminho% %%d in (TestResults) do (
    if exist "%%d" (
        echo Excluindo pasta: %%d
        rd /s /q "%%d"
    )
)

echo === Executando testes Plataforma.Educacao.Conteudo.Tests ===
dotnet test Plataforma.Educacao.Conteudo.Tests --collect:"XPlat Code Coverage"

echo === Executando testes Plataforma.Educacao.Aluno.Tests ===
dotnet test Plataforma.Educacao.Aluno.Tests --collect:"XPlat Code Coverage"

echo === Executando testes Plataforma.Educacao.Faturamento.Tests ===
dotnet test Plataforma.Educacao.Faturamento.Tests --collect:"XPlat Code Coverage"

echo === Gerando Relat�rio de Cobertura ===
reportgenerator -reports:\**\coverage.cobertura.xml -targetdir:tests\coverage-report -reporttypes:Html

echo === Abrindo o Relat�rio ===
if exist coverage-report\index.html (
    start coverage-report\index.html
) else (
    echo !!! ERRO: Relat�rio HTML n�o foi gerado !!!
)

endlocal

