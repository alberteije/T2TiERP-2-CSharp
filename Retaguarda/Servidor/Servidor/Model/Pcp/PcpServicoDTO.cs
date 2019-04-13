using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PcpServicoDTO {
        public PcpServicoDTO() { }
        public int Id { get; set; }
        public PcpOpDetalheDTO PcpOpDetalhe { get; set; }
        public System.Nullable<System.DateTime> InicioRealizado { get; set; }
        public System.Nullable<System.DateTime> TerminoRealizado { get; set; }
        public System.Nullable<int> HorasRealizado { get; set; }
        public System.Nullable<int> MinutosRealizado { get; set; }
        public System.Nullable<int> SegundosRealizado { get; set; }
        public System.Nullable<decimal> CustoRealizado { get; set; }
        public System.Nullable<System.DateTime> InicioPrevisto { get; set; }
        public System.Nullable<System.DateTime> TerminoPrevisto { get; set; }
        public System.Nullable<int> HorasPrevisto { get; set; }
        public System.Nullable<int> MinutosPrevisto { get; set; }
        public System.Nullable<int> SegundosPrevisto { get; set; }
        public System.Nullable<decimal> CustoPrevisto { get; set; }
    }
}
