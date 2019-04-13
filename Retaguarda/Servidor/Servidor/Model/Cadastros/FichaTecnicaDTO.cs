using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FichaTecnicaDTO {
        public FichaTecnicaDTO() { }
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<int> IdProdutoFilho { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<int> SequenciaProducao { get; set; }
    }
}
