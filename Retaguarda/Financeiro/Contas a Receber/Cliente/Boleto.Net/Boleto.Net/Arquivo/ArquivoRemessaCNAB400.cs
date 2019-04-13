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
                decimal vltitulostotal = 0;                 //Uso apenas no registro TRAILER do banco Santander - jsoda em 09/05/2012

                StreamWriter incluiLinha = new StreamWriter(arquivo);
                strline = banco.GerarHeaderRemessa(numeroConvenio, cedente, TipoArquivo.CNAB400, numeroArquivoRemessa);
                incluiLinha.WriteLine(strline);

                foreach (Boleto boleto in boletos)
                {
                    boleto.Banco = banco;
                    strline = boleto.Banco.GerarDetalheRemessa(boleto, numeroRegistro, TipoArquivo.CNAB400);
                    incluiLinha.WriteLine(strline);
                    vltitulostotal += boleto.ValorBoleto;   //Uso apenas no registro TRAILER do banco Santander - jsoda em 09/05/2012
                    numeroRegistro++;
                }

                strline = banco.GerarTrailerRemessa(numeroRegistro, TipoArquivo.CNAB400, vltitulostotal);

                incluiLinha.WriteLine(strline);

                incluiLinha.Close();
                incluiLinha.Dispose(); // Incluido por Luiz Ponce 07/07/2012.
                incluiLinha = null; // Incluido por Luiz Ponce 07/07/2012.
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar arquivo remessa.", ex);
            }
        }

        #endregion

    }
}
