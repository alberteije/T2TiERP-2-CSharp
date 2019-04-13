using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaParametroDTO {
        public FolhaParametroDTO() { }
        public int Id { get; set; }
        public string Competencia { get; set; }
        public string ContribuiPis { get; set; }
        public System.Nullable<decimal> AliquotaPis { get; set; }
        public string DiscriminarDsr { get; set; }
        public string DiaPagamento { get; set; }
        public string CalculoProporcionalidade { get; set; }
        public string DescontarFaltas13 { get; set; }
        public string PagarAdicionais13 { get; set; }
        public string PagarEstagiarios13 { get; set; }
        public string MesAdiantamento13 { get; set; }
        public System.Nullable<decimal> PercentualAdiantam13 { get; set; }
        public string FeriasDescontarFaltas { get; set; }
        public string FeriasPagarAdicionais { get; set; }
        public string FeriasAdiantar13 { get; set; }
        public string FeriasPagarEstagiarios { get; set; }
        public string FeriasCalcJustaCausa { get; set; }
        public string FeriasMovimentoMensal { get; set; }
    }
}
