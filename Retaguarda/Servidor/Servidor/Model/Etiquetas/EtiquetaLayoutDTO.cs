using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EtiquetaLayoutDTO {
        public EtiquetaLayoutDTO() { }
        public int Id { get; set; }
        public string CodigoFabricante { get; set; }
        public System.Nullable<int> Quantidade { get; set; }
        public System.Nullable<int> QuantidadeHorizontal { get; set; }
        public System.Nullable<int> QuantidadeVertical { get; set; }
        public System.Nullable<int> MargemSuperior { get; set; }
        public System.Nullable<int> MargemInferior { get; set; }
        public System.Nullable<int> MargemEsquerda { get; set; }
        public System.Nullable<int> MargemDireita { get; set; }
        public System.Nullable<int> EspacamentoHorizontal { get; set; }
        public System.Nullable<int> EspacamentoVertical { get; set; }
    }
}
