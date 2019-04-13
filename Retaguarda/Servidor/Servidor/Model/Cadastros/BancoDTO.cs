using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class BancoDTO {
        public BancoDTO() { }
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
    }
}
