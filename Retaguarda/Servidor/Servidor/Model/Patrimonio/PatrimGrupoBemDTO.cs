using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PatrimGrupoBemDTO {
        public PatrimGrupoBemDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ContaAtivoImobilizado { get; set; }
        public string ContaDepreciacaoAcumulada { get; set; }
        public string ContaDespesaDepreciacao { get; set; }
        public System.Nullable<int> CodigoHistorico { get; set; }
    }
}
