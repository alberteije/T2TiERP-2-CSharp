using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfConfiguracaoDTO {
        public EcfConfiguracaoDTO() { }
        public int Id { get; set; }
        public EcfImpressoraDTO EcfImpressora { get; set; }
        public EcfResolucaoDTO EcfResolucao { get; set; }
        public EcfCaixaDTO EcfCaixa { get; set; }
        public EcfEmpresaDTO EcfEmpresa { get; set; }
        public EcfConfiguracaoBalancaDTO EcfConfiguracaoBalanca { get; set; }
        public EcfRelatorioGerencialDTO EcfRelatorioGerencial { get; set; }
        public EcfConfiguracaoLeitorSerDTO EcfConfiguracaoLeitorSer { get; set; }
        public string MensagemCupom { get; set; }
        public string PortaEcf { get; set; }
        public string IpServidor { get; set; }
        public string IpSitef { get; set; }
        public string TipoTef { get; set; }
        public string TituloTelaCaixa { get; set; }
        public string CaminhoImagensProdutos { get; set; }
        public string CaminhoImagensMarketing { get; set; }
        public string CaminhoImagensLayout { get; set; }
        public string CorJanelasInternas { get; set; }
        public string MarketingAtivo { get; set; }
        public System.Nullable<int> CfopEcf { get; set; }
        public System.Nullable<int> CfopNf2 { get; set; }
        public System.Nullable<int> TimeoutEcf { get; set; }
        public System.Nullable<int> IntervaloEcf { get; set; }
        public string DescricaoSuprimento { get; set; }
        public string DescricaoSangria { get; set; }
        public System.Nullable<int> TefTipoGp { get; set; }
        public System.Nullable<int> TefTempoEspera { get; set; }
        public System.Nullable<int> TefEsperaSts { get; set; }
        public System.Nullable<int> TefNumeroVias { get; set; }
        public System.Nullable<int> DecimaisQuantidade { get; set; }
        public System.Nullable<int> DecimaisValor { get; set; }
        public System.Nullable<int> BitsPorSegundo { get; set; }
        public System.Nullable<int> QuantidadeMaximaCartoes { get; set; }
        public string PesquisaParte { get; set; }
        public System.Nullable<int> UltimaExclusao { get; set; }
        public string Laudo { get; set; }
        public System.Nullable<System.DateTime> DataAtualizacaoEstoque { get; set; }
        public string PedeCpfCupom { get; set; }
        public System.Nullable<int> TipoIntegracao { get; set; }
        public System.Nullable<int> TimerIntegracao { get; set; }
        public string GavetaSinalInvertido { get; set; }
        public System.Nullable<int> GavetaUtilizacao { get; set; }
        public System.Nullable<int> QuantidadeMaximaParcela { get; set; }
        public string ImprimeParcela { get; set; }
        public string UsaTecladoReduzido { get; set; }
        public string PermiteLancarNfManual { get; set; }
    }
}
