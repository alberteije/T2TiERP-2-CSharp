using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDetEspecificoVeiculoDTO {
        public NfeDetEspecificoVeiculoDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public string TipoOperacao { get; set; }
        public string Chassi { get; set; }
        public string Cor { get; set; }
        public string DescricaoCor { get; set; }
        public string PotenciaMotor { get; set; }
        public string Cilindradas { get; set; }
        public string PesoLiquido { get; set; }
        public string PesoBruto { get; set; }
        public string NumeroSerie { get; set; }
        public string TipoCombustivel { get; set; }
        public string NumeroMotor { get; set; }
        public string CapacidadeMaximaTracao { get; set; }
        public string DistanciaEixos { get; set; }
        public string AnoModelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string TipoPintura { get; set; }
        public string TipoVeiculo { get; set; }
        public string EspecieVeiculo { get; set; }
        public string CondicaoVin { get; set; }
        public string CondicaoVeiculo { get; set; }
        public string CodigoMarcaModelo { get; set; }
        public string CodigoCor { get; set; }
        public System.Nullable<int> Lotacao { get; set; }
        public string Restricao { get; set; }
    }
}
