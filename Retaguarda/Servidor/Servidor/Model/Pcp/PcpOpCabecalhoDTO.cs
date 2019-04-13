using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PcpOpCabecalhoDTO {
        public PcpOpCabecalhoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public System.Nullable<System.DateTime> Inicio { get; set; }
        public System.Nullable<System.DateTime> PrevisaoEntrega { get; set; }
        public System.Nullable<System.DateTime> Termino { get; set; }
        public System.Nullable<decimal> CustoTotalPrevisto { get; set; }
        public System.Nullable<decimal> CustoTotalRealizado { get; set; }
        public System.Nullable<decimal> PorcentoVenda { get; set; }
        public System.Nullable<decimal> PorcentoEstoque { get; set; }
    }
}
