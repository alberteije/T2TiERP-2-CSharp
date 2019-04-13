using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDeclaracaoImportacaoDTO {
        public NfeDeclaracaoImportacaoDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public string NumeroDocumento { get; set; }
        public System.Nullable<System.DateTime> DataRegistro { get; set; }
        public string LocalDesembaraco { get; set; }
        public string UfDesembaraco { get; set; }
        public System.Nullable<System.DateTime> DataDesembaraco { get; set; }
        public string CodigoExportador { get; set; }
        public System.Nullable<int> ViaTransporte { get; set; }
        public System.Nullable<decimal> ValorAfrmm { get; set; }
        public System.Nullable<int> FormaIntermediacao { get; set; }
        public string Cnpj { get; set; }
        public string UfTerceiro { get; set; }


    }
}
