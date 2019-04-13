using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model
{
    
    public class EmpresaDTO {
        public EmpresaDTO() {
        }
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoEstadualSt { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoJuntaComercial { get; set; }
        public System.Nullable<System.DateTime> DataInscJuntaComercial { get; set; }
        public string Tipo { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public System.Nullable<System.DateTime> DataInicioAtividades { get; set; }
        public string Suframa { get; set; }
        public string Email { get; set; }
        public string ImagemLogotipo { get; set; }
        public string Crt { get; set; }
        public string TipoRegime { get; set; }
        public string AliquotaPis { get; set; }
        public string Contato { get; set; }
        public string AliquotaCofins { get; set; }
        public System.Nullable<int> CodigoIbgeCidade { get; set; }
        public System.Nullable<int> CodigoIbgeUf { get; set; }
        public string CodigoTerceiros { get; set; }
        public System.Nullable<int> CodigoGps { get; set; }
        public string AliquotaSat { get; set; }
    }
}
