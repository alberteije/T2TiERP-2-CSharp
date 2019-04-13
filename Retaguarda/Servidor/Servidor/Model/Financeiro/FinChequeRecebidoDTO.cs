using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinChequeRecebidoDTO {
        public FinChequeRecebidoDTO() { }
        public int Id { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public string CodigoBanco { get; set; }
        public string CodigoAgencia { get; set; }
        public string Conta { get; set; }
        public System.Nullable<int> Numero { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public System.Nullable<System.DateTime> BomPara { get; set; }
        public System.Nullable<System.DateTime> DataCompensacao { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<System.DateTime> CustodiaData { get; set; }
        public System.Nullable<decimal> CustodiaTarifa { get; set; }
        public System.Nullable<decimal> CustodiaComissao { get; set; }
        public string DescontoCheque { get; set; }
        public System.Nullable<System.DateTime> DescontoData { get; set; }
        public System.Nullable<decimal> DescontoTarifa { get; set; }
        public System.Nullable<decimal> DescontoComissao { get; set; }
        public System.Nullable<decimal> ValorRecebido { get; set; }
    }
}
