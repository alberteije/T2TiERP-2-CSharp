using System;
using System.Text;
using System.Collections.Generic;


namespace ContasReceberService.Model {
    
    public class FinConfiguracaoBoletoDTO {
        public FinConfiguracaoBoletoDTO() { }
        public int Id { get; set; }
        public ContaCaixaDTO ContaCaixa { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Instrucao01 { get; set; }
        public string Instrucao02 { get; set; }
        public string CaminhoArquivoRemessa { get; set; }
        public string CaminhoArquivoRetorno { get; set; }
        public string CaminhoArquivoLogotipo { get; set; }
        public string CaminhoArquivoPdf { get; set; }
        public string Mensagem { get; set; }
        public string LocalPagamento { get; set; }
        public string LayoutRemessa { get; set; }
        public string Aceite { get; set; }
        public string Especie { get; set; }
        public string Carteira { get; set; }
        public string CodigoConvenio { get; set; }
        public string CodigoCedente { get; set; }
        public System.Nullable<decimal> TaxaMulta { get; set; }
    }
}
