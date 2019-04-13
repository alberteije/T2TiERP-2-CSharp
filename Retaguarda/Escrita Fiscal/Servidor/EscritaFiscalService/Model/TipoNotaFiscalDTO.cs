using System;
using System.Text;
using System.Collections.Generic;


namespace EscritaFiscalService.Model {
    
    public class TipoNotaFiscalDTO {
        public TipoNotaFiscalDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Template { get; set; }
        public System.Nullable<int> NumeroItens { get; set; }
        public System.Nullable<int> UltimoImpresso { get; set; }
    }
}
