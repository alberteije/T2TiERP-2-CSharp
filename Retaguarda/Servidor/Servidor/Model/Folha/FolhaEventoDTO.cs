using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaEventoDTO {
        public FolhaEventoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Unidade { get; set; }
        public string BaseCalculo { get; set; }
        public System.Nullable<decimal> Taxa { get; set; }
        public string RubricaEsocial { get; set; }
        public string CodIncidenciaPrevidencia { get; set; }
        public string CodIncidenciaIrrf { get; set; }
        public string CodIncidenciaFgts { get; set; }
        public string CodIncidenciaSindicato { get; set; }
        public string RepercuteDsr { get; set; }
        public string Repercute13 { get; set; }
        public string RepercuteFerias { get; set; }
        public string RepercuteAviso { get; set; }
    }
}
