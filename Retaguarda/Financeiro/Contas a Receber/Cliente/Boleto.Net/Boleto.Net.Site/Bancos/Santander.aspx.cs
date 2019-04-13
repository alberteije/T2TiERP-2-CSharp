using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BoletoNet;


public partial class Bancos_Santander : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime vencimento = new DateTime(2003, 5, 15);

        Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "2269", "130000946");
        c.Codigo = 1795082;

        Boleto b = new Boleto(vencimento, 0.20m, "101", "566612457800", c);

        //NOSSO NÚMERO
        //############################################################################################################################
        //Número adotado e controlado pelo Cliente, para identificar o título de cobrança.
        //Informação utilizada pelos Bancos para referenciar a identificação do documento objeto de cobrança.
        //Poderá conter número da duplicata, no caso de cobrança de duplicatas, número de apólice, no caso de cobrança de seguros, etc.
        //Esse campo é devolvido no arquivo retorno.
        b.NumeroDocumento = "0282033";

        b.Sacado = new Sacado("000.000.000-00", "Fulano de Silva");
        b.Sacado.Endereco.End = "SSS 154 Bloco J Casa 23";
        b.Sacado.Endereco.Bairro = "Testando";
        b.Sacado.Endereco.Cidade = "Testelândia";
        b.Sacado.Endereco.CEP = "70000000";
        b.Sacado.Endereco.UF = "DF";

        //Espécie Documento - [R] Recibo
        b.EspecieDocumento = new EspecieDocumento_Santander(17);

        boletoBancario.Boleto = b;
        boletoBancario.MostrarCodigoCarteira = true;
        boletoBancario.Boleto.Valida();

        boletoBancario.MostrarComprovanteEntrega = (Request.Url.Query == "?show");      
        
    }

    
}
