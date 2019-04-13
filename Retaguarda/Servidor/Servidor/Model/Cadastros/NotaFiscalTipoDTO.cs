using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NotaFiscalTipoDTO {
        public NotaFiscalTipoDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Serie { get; set; }
        public string SerieScan { get; set; }
        public System.Nullable<int> UltimoNumero { get; set; }
    }
}
