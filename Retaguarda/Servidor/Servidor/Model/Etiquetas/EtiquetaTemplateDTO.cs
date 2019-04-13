using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EtiquetaTemplateDTO {
        public EtiquetaTemplateDTO() { }
        public int Id { get; set; }

        public EtiquetaLayoutDTO EtiquetaLayout { get; set; }

        public string Tabela { get; set; }
        public string Campo { get; set; }
        public System.Nullable<int> Formato { get; set; }
        public System.Nullable<int> QuantidadeRepeticoes { get; set; }
        public string Filtro { get; set; }
    }
}
