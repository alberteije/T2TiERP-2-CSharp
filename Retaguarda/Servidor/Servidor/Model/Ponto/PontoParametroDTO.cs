using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoParametroDTO {
        public PontoParametroDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string MesAno { get; set; }
        public System.Nullable<int> DiaInicialApuracao { get; set; }
        public string HoraNoturnaInicio { get; set; }
        public string HoraNoturnaFim { get; set; }
        public string PeriodoMinimoInterjornada { get; set; }
        public System.Nullable<decimal> PercentualHeDiurna { get; set; }
        public System.Nullable<decimal> PercentualHeNoturna { get; set; }
        public string DuracaoHoraNoturna { get; set; }
        public string TratamentoHoraMais { get; set; }
        public string TratamentoHoraMenos { get; set; }
    }
}
