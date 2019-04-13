using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfcePosicaoComponentesDTO {
        public NfcePosicaoComponentesDTO() { }
        public int Id { get; set; }
        public int IdNfceResolucao { get; set; }
        public string Nome { get; set; }
        public System.Nullable<int> Altura { get; set; }
        public System.Nullable<int> Largura { get; set; }
        public System.Nullable<int> Topo { get; set; }
        public System.Nullable<int> Esquerda { get; set; }
        public System.Nullable<int> TamanhoFonte { get; set; }
        public string Texto { get; set; }
    }
}
