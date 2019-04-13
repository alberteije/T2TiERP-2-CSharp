using System;
using System.Text;
using System.Collections.Generic;


namespace PontoService.Model {
    
    public class PontoAbonoDTO {
        public PontoAbonoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<int> Quantidade { get; set; }
        public System.Nullable<int> Utilizado { get; set; }
        public System.Nullable<int> Saldo { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public System.Nullable<System.DateTime> InicioUtilizacao { get; set; }
        public string Observacao { get; set; }
    }
}
