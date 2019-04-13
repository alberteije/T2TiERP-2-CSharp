using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class TalonarioChequeDTO {
        public TalonarioChequeDTO() { }
        public int Id { get; set; }
        public ContaCaixaDTO ContaCaixa { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Talao { get; set; }
        public System.Nullable<int> Numero { get; set; }
        public string StatusTalao { get; set; }
    }
}
