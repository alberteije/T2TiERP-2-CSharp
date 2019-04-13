using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class PatrimApoliceSeguroDTO {
        public PatrimApoliceSeguroDTO() { }
        public int Id { get; set; }
        public PatrimBemDTO PatrimBem { get; set; }
        public SeguradoraDTO Seguradora { get; set; }
        public string Numero { get; set; }
        public System.Nullable<System.DateTime> DataContratacao { get; set; }
        public System.Nullable<System.DateTime> DataVencimento { get; set; }
        public System.Nullable<decimal> ValorPremio { get; set; }
        public System.Nullable<decimal> ValorSegurado { get; set; }
        public string Observacao { get; set; }
        public string Imagem { get; set; }
    }
}
