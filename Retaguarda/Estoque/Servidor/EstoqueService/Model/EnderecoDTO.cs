using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueService.Model
{
    public class EnderecoDTO
    {
        public int? id { get; set; }
        public int? idEmpresa { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public int? municipioIbge { get; set; }
        public string uf { get; set; }
        public string fone { get; set; }
        public string principal { get; set; }
        public string entrega { get; set; }
        public string cobranca { get; set; }
        public string correspondencia { get; set; }
    }
}