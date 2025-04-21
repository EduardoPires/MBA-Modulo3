﻿using System.ComponentModel;

namespace Plataforma.Educacao.Faturamento.Domain.Enumerators;
public enum StatusPagamentoEnum
{
    [Description("Pendente de Pagamento")]
    Pendente = 1,
    [Description("Pagamento Realizado")]
    Aprovado = 2,
    [Description("Pagamento Não Concluído")]
    Recusado = 3
}
