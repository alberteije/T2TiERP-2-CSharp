using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeProdRuralReferenciadaDTO {
        public NfeProdRuralReferenciadaDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public System.Nullable<int> CodigoUf { get; set; }
        public string AnoMes { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public System.Nullable<int> NumeroNf { get; set; }
    }
}
