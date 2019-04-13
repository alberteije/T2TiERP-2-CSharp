using System;
using System.Text;
using System.Collections.Generic;


namespace EscritaFiscalService.Model {
    
    public class FiscalParametroDTO {
        public FiscalParametroDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Vigencia { get; set; }
        public string DescricaoVigencia { get; set; }
        public string CriterioLancamento { get; set; }
        public string Apuracao { get; set; }
        public string MicroempreeIndividual { get; set; }
        public string CalcPisCofinsEfd { get; set; }
        public string SimplesCodigoAcesso { get; set; }
        public string SimplesTabela { get; set; }
        public string SimplesAtividade { get; set; }
        public string PerfilSped { get; set; }
        public string ApuracaoConsolidada { get; set; }
        public string SubstituicaoTributaria { get; set; }
        public string FormaCalculoIss { get; set; }
    }
}
