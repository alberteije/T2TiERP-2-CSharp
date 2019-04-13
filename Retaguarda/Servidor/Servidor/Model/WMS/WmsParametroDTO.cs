using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsParametroDTO {
        public WmsParametroDTO() { }
        public int Id { get; set; }

        public EmpresaDTO Empresa { get; set; }

        public System.Nullable<int> HoraPorVolume { get; set; }
        public System.Nullable<int> PessoaPorVolume { get; set; }
        public System.Nullable<int> HoraPorPeso { get; set; }
        public System.Nullable<int> PessoaPorPeso { get; set; }
        public string ItemDiferenteCaixa { get; set; }
    }
}
