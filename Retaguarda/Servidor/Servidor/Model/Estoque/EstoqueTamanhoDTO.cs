using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EstoqueTamanhoDTO {
        public EstoqueTamanhoDTO() { }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public System.Nullable<decimal> Altura { get; set; }
        public System.Nullable<decimal> Comprimento { get; set; }
        public System.Nullable<decimal> Largura { get; set; }
    }
}
