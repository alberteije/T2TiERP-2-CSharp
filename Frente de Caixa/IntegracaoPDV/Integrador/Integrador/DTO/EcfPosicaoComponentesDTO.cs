using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class EcfPosicaoComponentesDTO {
        public EcfPosicaoComponentesDTO() { }
        public int Id { get; set; }
        public int IdEcfResolucao { get; set; }
        public string Nome { get; set; }
        public System.Nullable<int> Altura { get; set; }
        public System.Nullable<int> Largura { get; set; }
        public System.Nullable<int> Topo { get; set; }
        public System.Nullable<int> Esquerda { get; set; }
        public System.Nullable<int> TamanhoFonte { get; set; }
        public string Texto { get; set; }
    }
}
