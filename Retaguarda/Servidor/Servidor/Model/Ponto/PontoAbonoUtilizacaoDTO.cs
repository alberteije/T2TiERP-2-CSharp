using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoAbonoUtilizacaoDTO {
        public PontoAbonoUtilizacaoDTO() { }
        public int Id { get; set; }
        public PontoAbonoDTO PontoAbono { get; set; }
        public System.Nullable<System.DateTime> DataUtilizacao { get; set; }
        public string Observacao { get; set; }
    }
}
