using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaAfastamentoDTO {
        public FolhaAfastamentoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public FolhaTipoAfastamentoDTO FolhaTipoAfastamento { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public System.Nullable<int> DiasAfastado { get; set; }
    }
}
