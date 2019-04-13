using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContabilDreCabecalhoDTO {
        public ContabilDreCabecalhoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Descricao { get; set; }
        public string Padrao { get; set; }
        public string PeriodoInicial { get; set; }
        public string PeriodoFinal { get; set; }
    }
}
