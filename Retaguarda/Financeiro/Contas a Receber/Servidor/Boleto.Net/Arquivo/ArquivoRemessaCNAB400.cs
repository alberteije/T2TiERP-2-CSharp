using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    internal class ArquivoRemessaCNAB400 : AbstractArquivoRemessa, IArquivoRemessa
    {

        #region Construtores

        public ArquivoRemessaCNAB400()
		{
            this.TipoArquivo = TipoArquivo.CNAB400;
        }

        #endregion

        #region Métodos de instância

        public override void GerarArquivoRemessa(string numeroConvenio, IBanco banco, Cedente cedente, Boletos boletos, Stream arquivo, int numeroArquivoRemessa)
        {
            try
            {
                int numeroRegistro = 2;
                string strline;

                StreamWriter incluiLinha = new StreamWriter(arquivo);
                strline = banco.GerarHeaderRemessa("0", cedente, TipoArquivo.CNAB400);
                incluiLinha.WriteLine(strline);

                foreach (Boleto boleto in boletos)
                {
                    boleto.Banco = banco;
                    strline = boleto.Banco.GerarDetalheRemessa(boleto, numeroRegistro, TipoArquivo.CNAB400);
                    incluiLinha.WriteLine(strline);
                    numeroRegistro++;
                }

                strline = banco.GerarTrailerRemessa(numeroRegistro, TipoArquivo.CNAB400);
                incluiLinha.WriteLine(strline);

                incluiLinha.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar arquivo remessa.", ex);
            }
        }

        #endregion

    }
}
