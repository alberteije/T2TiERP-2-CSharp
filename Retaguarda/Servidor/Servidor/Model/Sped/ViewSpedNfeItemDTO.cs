using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedNfeItemDTO {
        public ViewSpedNfeItemDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Gtin { get; set; }
        public int IdUnidadeProduto { get; set; }
        public string Sigla { get; set; }
        public string TipoItemSped { get; set; }
        public string Ncm { get; set; }
        public string ExTipi { get; set; }
        public string CodigoLst { get; set; }
        public decimal AliquotaIcmsPaf { get; set; }
    }
}
