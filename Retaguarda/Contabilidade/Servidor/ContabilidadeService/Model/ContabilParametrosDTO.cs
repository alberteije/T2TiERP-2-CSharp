using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class ContabilParametrosDTO {
        public ContabilParametrosDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Mascara { get; set; }
        public System.Nullable<int> Niveis { get; set; }
        public string InformarContaPor { get; set; }
        public string CompartilhaPlanoConta { get; set; }
        public string CompartilhaHistoricos { get; set; }
        public string AlteraLancamentoOutro { get; set; }
        public string HistoricoObrigatorio { get; set; }
        public string PermiteLancamentoZerado { get; set; }
        public string GeraInformativoSped { get; set; }
        public string SpedFormaEscritDiario { get; set; }
        public string SpedNomeLivroDiario { get; set; }
        public string AssinaturaDireita { get; set; }
        public string AssinaturaEsquerda { get; set; }
        public string ContaAtivo { get; set; }
        public string ContaPassivo { get; set; }
        public string ContaPatrimonioLiquido { get; set; }
        public string ContaDepreciacaoAcumulada { get; set; }
        public string ContaCapitalSocial { get; set; }
        public string ContaResultadoExercicio { get; set; }
        public string ContaPrejuizoAcumulado { get; set; }
        public string ContaLucroAcumulado { get; set; }
        public string ContaTituloPagar { get; set; }
        public string ContaTituloReceber { get; set; }
        public string ContaJurosPassivo { get; set; }
        public string ContaJurosAtivo { get; set; }
        public string ContaDescontoObtido { get; set; }
        public string ContaDescontoConcedido { get; set; }
        public string ContaCmv { get; set; }
        public string ContaVenda { get; set; }
        public string ContaVendaServico { get; set; }
        public string ContaEstoque { get; set; }
        public string ContaApuraResultado { get; set; }
        public string ContaJurosApropriar { get; set; }
        public System.Nullable<int> IdHistPadraoResultado { get; set; }
        public System.Nullable<int> IdHistPadraoLucro { get; set; }
        public System.Nullable<int> IdHistPadraoPrejuizo { get; set; }
    }
}
