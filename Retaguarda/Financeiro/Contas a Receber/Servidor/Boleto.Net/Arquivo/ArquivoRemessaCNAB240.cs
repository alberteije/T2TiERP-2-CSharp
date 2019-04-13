using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    internal class ArquivoRemessaCNAB240 : AbstractArquivoRemessa, IArquivoRemessa
    {

        #region Construtores

        public ArquivoRemessaCNAB240()
        {
            this.TipoArquivo = TipoArquivo.CNAB240;
        }

        #endregion

        #region Métodos de instância

        public override void GerarArquivoRemessa(string numeroConvenio, IBanco banco, Cedente cedente, Boletos boletos, Stream arquivo, int numeroArquivoRemessa)
        {
            try
            {
                int numeroRegistro = 3;
                int numeroRegistroDetalhe = 1;
                string strline;

                StreamWriter incluiLinha = new StreamWriter(arquivo);
                strline = banco.GerarHeaderRemessa(cedente, TipoArquivo.CNAB240);
                incluiLinha.WriteLine(strline);
                OnLinhaGerada(null, strline, EnumTipodeLinha.HeaderDeArquivo);

                strline = banco.GerarHeaderLoteRemessa(numeroConvenio, cedente, numeroArquivoRemessa, TipoArquivo.CNAB240);
                incluiLinha.WriteLine(strline);
                OnLinhaGerada(null, strline, EnumTipodeLinha.HeaderDeLote);

                if (banco.Codigo != 341)
                {
                    foreach (Boleto boleto in boletos)
                    {
                        boleto.Banco = banco;
                        strline = boleto.Banco.GerarDetalheSegmentoPRemessa(boleto, numeroRegistroDetalhe, numeroConvenio);
                        incluiLinha.WriteLine(strline);
                        OnLinhaGerada(boleto, strline, EnumTipodeLinha.DetalheSegmentoP);
                        numeroRegistro++;
                        numeroRegistroDetalhe++;

                        strline = boleto.Banco.GerarDetalheSegmentoQRemessa(boleto, numeroRegistroDetalhe, TipoArquivo.CNAB240);
                        incluiLinha.WriteLine(strline);
                        OnLinhaGerada(boleto, strline, EnumTipodeLinha.DetalheSegmentoQ);
                        numeroRegistro++;
                        numeroRegistroDetalhe++;

                        if (boleto.ValorMulta > 0)
                        {
                            strline = boleto.Banco.GerarDetalheSegmentoRRemessa(boleto, numeroRegistroDetalhe, TipoArquivo.CNAB240);
                            incluiLinha.WriteLine(strline);
                            OnLinhaGerada(boleto, strline, EnumTipodeLinha.DetalheSegmentoR);
                            numeroRegistro++;
                            numeroRegistroDetalhe++;
                        }
                    }

                    numeroRegistro--;
                    strline = banco.GerarTrailerLoteRemessa(numeroRegistro);
                    incluiLinha.WriteLine(strline);
                    OnLinhaGerada(null, strline, EnumTipodeLinha.TraillerDeLote);

                    numeroRegistro++;
                    numeroRegistro++;

                    strline = banco.GerarTrailerArquivoRemessa(numeroRegistro);
                    incluiLinha.WriteLine(strline);
                    OnLinhaGerada(null, strline, EnumTipodeLinha.TraillerDeArquivo);

                    incluiLinha.Close();
                }
                else
                {
                    foreach (Boleto boleto in boletos)
                    {
                        boleto.Banco = banco;
                        strline = boleto.Banco.GerarDetalheRemessa(boleto, numeroRegistroDetalhe, TipoArquivo.CNAB240);
                        incluiLinha.WriteLine(strline);
                        OnLinhaGerada(boleto, strline, EnumTipodeLinha.DetalheSegmentoP);
                        numeroRegistro++;
                        numeroRegistroDetalhe++;
                    }

                    numeroRegistro--;
                    strline = banco.GerarTrailerLoteRemessa(numeroRegistro);
                    incluiLinha.WriteLine(strline);
                    OnLinhaGerada(null, strline, EnumTipodeLinha.TraillerDeLote);

                    numeroRegistro++;
                    numeroRegistro++;

                    strline = banco.GerarTrailerArquivoRemessa(numeroRegistro);
                    incluiLinha.WriteLine(strline);
                    OnLinhaGerada(null, strline, EnumTipodeLinha.TraillerDeArquivo);

                    incluiLinha.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar arquivo remessa.", ex);
            }
        }

        #endregion

    }
}
