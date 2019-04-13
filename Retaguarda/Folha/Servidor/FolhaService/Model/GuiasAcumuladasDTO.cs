using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class GuiasAcumuladasDTO {
        public GuiasAcumuladasDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string GpsTipo { get; set; }
        public string GpsCompetencia { get; set; }
        public System.Nullable<decimal> GpsValorInss { get; set; }
        public System.Nullable<decimal> GpsValorOutrasEnt { get; set; }
        public System.Nullable<System.DateTime> GpsDataPagamento { get; set; }
        public string IrrfCompetencia { get; set; }
        public System.Nullable<int> IrrfCodigoRecolhimento { get; set; }
        public System.Nullable<decimal> IrrfValorAcumulado { get; set; }
        public System.Nullable<System.DateTime> IrrfDataPagamento { get; set; }
        public string PisCompetencia { get; set; }
        public System.Nullable<decimal> PisValorAcumulado { get; set; }
        public System.Nullable<System.DateTime> PisDataPagamento { get; set; }
    }
}
