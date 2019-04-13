using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaInssRetencaoDTO {
        public FolhaInssRetencaoDTO() { }
        public int Id { get; set; }
        public int? IdFolhaInss { get; set; }
        public FolhaInssServicoDTO FolhaInssServico { get; set; }
        public System.Nullable<decimal> ValorMensal { get; set; }
        public System.Nullable<decimal> Valor13 { get; set; }
    }
}
