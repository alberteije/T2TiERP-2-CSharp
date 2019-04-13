using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceConfiguracaoDTO {
        public NfceConfiguracaoDTO() 
        {
            NfceConfiguracaoBalanca = new NfceConfiguracaoBalancaDTO();
            NfceConfiguracaoLeitorSer = new NfceConfiguracaoLeitorSerDTO();
        }
        public int Id { get; set; }
        public string MensagemCupom { get; set; }
        public string TituloTelaCaixa { get; set; }
        public string CaminhoImagensProdutos { get; set; }
        public string CaminhoImagensMarketing { get; set; }
        public string CaminhoImagensLayout { get; set; }
        public string CorJanelasInternas { get; set; }
        public string MarketingAtivo { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public System.Nullable<int> DecimaisQuantidade { get; set; }
        public System.Nullable<int> DecimaisValor { get; set; }
        public System.Nullable<int> QuantidadeMaximaParcela { get; set; }
        public string ImprimeParcela { get; set; }

        public NfceResolucaoDTO NfceResolucao { get; set; }
        public NfceCaixaDTO NfceCaixa { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public NfceConfiguracaoBalancaDTO NfceConfiguracaoBalanca { get; set; }
        public NfceConfiguracaoLeitorSerDTO NfceConfiguracaoLeitorSer { get; set; }
    }
}
