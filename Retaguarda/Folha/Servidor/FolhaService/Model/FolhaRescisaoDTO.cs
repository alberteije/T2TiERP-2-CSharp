using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaRescisaoDTO {
        public FolhaRescisaoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataDemissao { get; set; }
        public System.Nullable<System.DateTime> DataPagamento { get; set; }
        public string Motivo { get; set; }
        public System.Nullable<System.DateTime> DataAvisoPrevio { get; set; }
        public System.Nullable<int> DiasAvisoPrevio { get; set; }
        public string ComprovouNovoEmprego { get; set; }
        public string DispensouEmpregado { get; set; }
        public System.Nullable<decimal> PensaoAlimenticia { get; set; }
        public System.Nullable<decimal> PensaoAlimenticiaFgts { get; set; }
        public System.Nullable<decimal> FgtsValorRescisao { get; set; }
        public System.Nullable<decimal> FgtsSaldoBanco { get; set; }
        public System.Nullable<decimal> FgtsComplementoSaldo { get; set; }
        public string FgtsCodigoAfastamento { get; set; }
        public string FgtsCodigoSaque { get; set; }
    }
}
