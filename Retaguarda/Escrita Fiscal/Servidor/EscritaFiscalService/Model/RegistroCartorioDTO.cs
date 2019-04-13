using System;
using System.Text;
using System.Collections.Generic;


namespace EscritaFiscalService.Model {
    
    public class RegistroCartorioDTO {
        public RegistroCartorioDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string NomeCartorio { get; set; }
        public System.Nullable<System.DateTime> DataRegistro { get; set; }
        public System.Nullable<int> Numero { get; set; }
        public System.Nullable<int> Folha { get; set; }
        public System.Nullable<int> Livro { get; set; }
        public string Nire { get; set; }
    }
}
