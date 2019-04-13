using System;
using System.Text;
using System.Collections.Generic;


namespace CaixaBancosService.Model {
    
    public class ContabilContaDTO {
        public ContabilContaDTO() { }
        public int Id { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public string Classificacao { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
        public string Situacao { get; set; }
        public string Natureza { get; set; }
        public string PatrimonioResultado { get; set; }
        public string LivroCaixa { get; set; }
        public string Dfc { get; set; }
        public string Ordem { get; set; }
        public string CodigoReduzido { get; set; }
        public string CodigoEfd { get; set; }
    }
}
