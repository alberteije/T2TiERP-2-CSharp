using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class OrcamentoEmpresarialDTO {
        public OrcamentoEmpresarialDTO() { }
        public int Id { get; set; }
        public OrcamentoPeriodoDTO OrcamentoPeriodo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<System.DateTime> DataInicial { get; set; }
        public System.Nullable<int> NumeroPeriodos { get; set; }
        public System.Nullable<System.DateTime> DataBase { get; set; }
    }
}
