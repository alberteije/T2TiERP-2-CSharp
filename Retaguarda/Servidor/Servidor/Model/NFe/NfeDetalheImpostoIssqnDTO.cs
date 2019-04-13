using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDetalheImpostoIssqnDTO {
        public NfeDetalheImpostoIssqnDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public System.Nullable<decimal> BaseCalculoIssqn { get; set; }
        public System.Nullable<decimal> AliquotaIssqn { get; set; }
        public System.Nullable<decimal> ValorIssqn { get; set; }
        public System.Nullable<int> MunicipioIssqn { get; set; }
        public System.Nullable<int> ItemListaServicos { get; set; }
        public System.Nullable<decimal> ValorDeducao { get; set; }
        public System.Nullable<decimal> ValorOutrasRetencoes { get; set; }
        public System.Nullable<decimal> ValorDescontoIncondicionado { get; set; }
        public System.Nullable<decimal> ValorDescontoCondicionado { get; set; }
        public System.Nullable<decimal> ValorRetencaoIss { get; set; }
        public System.Nullable<int> IndicadorExigibilidadeIss { get; set; }
        public string CodigoServico { get; set; }
        public System.Nullable<int> MunicipioIncidencia { get; set; }
        public System.Nullable<int> PaisSevicoPrestado { get; set; }
        public string NumeroProcesso { get; set; }
        public System.Nullable<int> IndicadorIncentivoFiscal { get; set; }
    }
}
