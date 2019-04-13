using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoRelogioDTO {
        public PontoRelogioDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Localizacao { get; set; }
        public string Marca { get; set; }
        public string Fabricante { get; set; }
        public string NumeroSerie { get; set; }
        public string Utilizacao { get; set; }
    }
}
