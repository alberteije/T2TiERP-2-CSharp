using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class VendaRomaneioEntregaDTO {
        public VendaRomaneioEntregaDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public System.Nullable<System.DateTime> DataPrevista { get; set; }
        public System.Nullable<System.DateTime> DataSaida { get; set; }
        public string Situacao { get; set; }
        public System.Nullable<System.DateTime> DataEncerramento { get; set; }
        public string Observacao { get; set; }
    }
}
