using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class AFDT_Registro2
    {
        public string Campo01 { get; set; } //  Seq?encial do registro no arquivo.
        public string Campo02 { get; set; } //  Tipo do registro, ?2?.
        public string Campo03 { get; set; } //  Data da marca??o do ponto, no formato ?ddmmaaaa?.
        public string Campo04 { get; set; } //  Hor?rio da marca??o do ponto, no formato ?hhmm?.
        public string Campo05 { get; set; } //  N?mero do PIS do empregado.
        public string Campo06 { get; set; } //  N?mero de fabrica??o do REP onde foi feito o registro.
        public string Campo07 { get; set; } //  Tipo de marca??o, ?E? para ENTRADA, ?S? para SA?DA ou ?D? para registro a ser DESCONSIDERADO.
        public string Campo08 { get; set; } //  N?mero seq?encial por empregado e jornada para o conjunto Entrada/Sa?da. Vide observa??o.
        public string Campo09 { get; set; } //  Tipo de registro: ?O? para registro eletr?nico ORIGINAL, ?I? para registro INCLU?DO por digita??o, ?P? para intervalo PR?-ASSINALADO.
        public string Campo10 { get; set; } //  Motivo: Campo a ser preenchido se o campo 7 for ?D? ou se o campo 9 for ?I?.

        public AFDT_Registro2()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill(ComponentePonto.NSR, 9);
            retorno += Funcoes.LFill("2");
            retorno += Funcoes.LFill(Campo03 == null ? "" : Campo03, 8);
            retorno += Funcoes.LFill(Campo04 == null ? "" : Campo04, 4);
            retorno += Funcoes.LFill(Campo05 == null ? "" : Campo05, 12);
            retorno += Funcoes.RFill(Campo06 == null ? "" : Campo06, 17);
            retorno += Funcoes.LFill(Campo07 == null ? "" : Campo07, 1);
            retorno += Funcoes.LFill(Campo08 == null ? "" : Campo08, 2);
            retorno += Funcoes.LFill(Campo09 == null ? "" : Campo09, 1);
            retorno += Funcoes.LFill(Campo10 == null ? "" : Campo10, 100);

            return retorno;
        }

    }
}
