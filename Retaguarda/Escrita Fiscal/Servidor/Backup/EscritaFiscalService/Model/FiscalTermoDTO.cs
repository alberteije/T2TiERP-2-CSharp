using System;
using System.Text;
using System.Collections.Generic;


namespace EscritaFiscalService.Model {
    
    public class FiscalTermoDTO {
        public FiscalTermoDTO() { }
        public int Id { get; set; }
        public int? IdFiscalLivro { get; set; }
        public string AberturaEncerramento { get; set; }
        public System.Nullable<int> Numero { get; set; }
        public System.Nullable<int> PaginaInicial { get; set; }
        public System.Nullable<int> PaginaFinal { get; set; }
        public string Registrado { get; set; }
        public string NumeroRegistro { get; set; }
        public System.Nullable<System.DateTime> DataDespacho { get; set; }
        public System.Nullable<System.DateTime> DataAbertura { get; set; }
        public System.Nullable<System.DateTime> DataEncerramento { get; set; }
        public System.Nullable<System.DateTime> EscrituracaoInicio { get; set; }
        public System.Nullable<System.DateTime> EscrituracaoFim { get; set; }
        public string Texto { get; set; }
    }
}
