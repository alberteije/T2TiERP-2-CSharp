using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoEscalaDTO {
        public PontoEscalaDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Nome { get; set; }
        public string DescontoHoraDia { get; set; }
        public string DescontoDsr { get; set; }
        public string CodigoHorarioDomingo { get; set; }
        public string CodigoHorarioSegunda { get; set; }
        public string CodigoHorarioTerca { get; set; }
        public string CodigoHorarioQuarta { get; set; }
        public string CodigoHorarioQuinta { get; set; }
        public string CodigoHorarioSexta { get; set; }
        public string CodigoHorarioSabado { get; set; }
    }
}
