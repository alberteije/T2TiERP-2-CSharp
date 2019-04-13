using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class VendaCondicoesPagamentoDTO {
        public VendaCondicoesPagamentoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<decimal> FaturamentoMinimo { get; set; }
        public System.Nullable<decimal> FaturamentoMaximo { get; set; }
        public System.Nullable<decimal> IndiceCorrecao { get; set; }
        public System.Nullable<int> DiasTolerancia { get; set; }
        public System.Nullable<decimal> ValorTolerancia { get; set; }
        public System.Nullable<int> PrazoMedio { get; set; }
        public string VistaPrazo { get; set; }
    }
}
