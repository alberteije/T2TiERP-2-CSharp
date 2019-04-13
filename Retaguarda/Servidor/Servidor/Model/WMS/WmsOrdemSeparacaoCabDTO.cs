using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsOrdemSeparacaoCabDTO {
        public WmsOrdemSeparacaoCabDTO() { }
        public int Id { get; set; }

        public EmpresaDTO Empresa { get; set; }

        public string Origem { get; set; }
        public System.Nullable<System.DateTime> DataSolicitacao { get; set; }
        public System.Nullable<System.DateTime> DataLimite { get; set; }
    }
}
