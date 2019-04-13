using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class BancoDTO {
        public BancoDTO() { }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
    }
}
