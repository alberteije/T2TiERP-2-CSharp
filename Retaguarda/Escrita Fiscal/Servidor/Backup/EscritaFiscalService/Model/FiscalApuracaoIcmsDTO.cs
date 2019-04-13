using System;
using System.Text;
using System.Collections.Generic;


namespace EscritaFiscalService.Model {
    
    public class FiscalApuracaoIcmsDTO {
        public FiscalApuracaoIcmsDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Competencia { get; set; }
        public System.Nullable<decimal> ValorTotalDebito { get; set; }
        public System.Nullable<decimal> ValorAjusteDebito { get; set; }
        public System.Nullable<decimal> ValorTotalAjusteDebito { get; set; }
        public System.Nullable<decimal> ValorEstornoCredito { get; set; }
        public System.Nullable<decimal> ValorTotalCredito { get; set; }
        public System.Nullable<decimal> ValorAjusteCredito { get; set; }
        public System.Nullable<decimal> ValorTotalAjusteCredito { get; set; }
        public System.Nullable<decimal> ValorEstornoDebito { get; set; }
        public System.Nullable<decimal> ValorSaldoCredorAnterior { get; set; }
        public System.Nullable<decimal> ValorSaldoApurado { get; set; }
        public System.Nullable<decimal> ValorTotalDeducao { get; set; }
        public System.Nullable<decimal> ValorIcmsRecolher { get; set; }
        public System.Nullable<decimal> ValorSaldoCredorTransp { get; set; }
        public System.Nullable<decimal> ValorDebitoEspecial { get; set; }
    }
}
