using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO
{
    
    public class IbptDTO {
        public IbptDTO() { }
        public int Id { get; set; }
        public string Ncm { get; set; }
        public string Ex { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<decimal> NacionalFederal { get; set; }
        public System.Nullable<decimal> ImportadosFederal { get; set; }
        public System.Nullable<decimal> Estadual { get; set; }
        public System.Nullable<decimal> Municipal { get; set; }
        public System.Nullable<System.DateTime> VigenciaInicio { get; set; }
        public System.Nullable<System.DateTime> VigenciaFim { get; set; }
        public string Chave { get; set; }
        public string Versao { get; set; }
        public string Fonte { get; set; }
    }
}
