using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoBancoHorasDTO {
        public PontoBancoHorasDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataTrabalho { get; set; }
        public string Quantidade { get; set; }
        public string Situacao { get; set; }
    }
}
