using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaInssRetencaoDTO {
        public FolhaInssRetencaoDTO() { }
        public int Id { get; set; }
        public FolhaInssDTO FolhaInss { get; set; }
        public FolhaInssServicoDTO FolhaInssServico { get; set; }
        public System.Nullable<decimal> ValorMensal { get; set; }
        public System.Nullable<decimal> Valor13 { get; set; }
    }
}
