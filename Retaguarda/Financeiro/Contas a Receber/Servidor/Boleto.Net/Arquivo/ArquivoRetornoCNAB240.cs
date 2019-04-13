using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    public class ArquivoRetornoCNAB240 : AbstractArquivoRetorno, IArquivoRetorno
    {
        private Stream _streamArquivo;
        private string _caminhoArquivo;
        private List<DetalheRetornoCNAB240> _listaDetalhes = new List<DetalheRetornoCNAB240>();



        #region Propriedades
        public string CaminhoArquivo
        {
            get { return _caminhoArquivo; }
        }
        public Stream StreamArquivo
        {
            get { return _streamArquivo; }
        }
        public List<DetalheRetornoCNAB240> ListaDetalhes
        {
            get { return _listaDetalhes; }
            set { _listaDetalhes = value; }
        }
        #endregion Propriedades


        #region Construtores

        public ArquivoRetornoCNAB240()
		{
            this.TipoArquivo = TipoArquivo.CNAB240;
        }

        public ArquivoRetornoCNAB240(Stream streamArquivo)
        {
            this.TipoArquivo = TipoArquivo.CNAB240;
            _streamArquivo = streamArquivo;
        }

        public ArquivoRetornoCNAB240(string caminhoArquivo)
        {
            this.TipoArquivo = TipoArquivo.CNAB240;

            _streamArquivo = new StreamReader(caminhoArquivo).BaseStream;
        }
        #endregion

        #region Métodos de instância
        public void LerArquivoRetorno(IBanco banco)
        {
            LerArquivoRetorno(banco, StreamArquivo);
        }

        public override void LerArquivoRetorno(IBanco banco, Stream arquivo)
        {
            try
            {
                StreamReader stream = new StreamReader(arquivo, System.Text.Encoding.UTF8);
                string linha = "";
                DetalheRetornoCNAB240 detalheRetorno = new DetalheRetornoCNAB240();

                // Lendo o arquivo
                linha = stream.ReadLine();
                OnLinhaLida(null, linha, EnumTipodeLinhaLida.HeaderDeArquivo);
                detalheRetorno.HeaderArquivo.LerHeaderDeArquivoCNAB240(linha);

                // Próxima linha (DETALHE)
                linha = stream.ReadLine();
                OnLinhaLida(null, linha, EnumTipodeLinhaLida.HeaderDeLote);
                linha = stream.ReadLine();

                while (linha.Substring(7, 1) == "3")
                {
                    if (linha.Substring(13, 1) == "W")
                    {
                        OnLinhaLida(detalheRetorno, linha, EnumTipodeLinhaLida.DetalheSegmentoW);
                        detalheRetorno.SegmentoW.LerDetalheSegmentoWRetornoCNAB240(linha);
                    }
                    else
                    {
                        OnLinhaLida(detalheRetorno, linha, EnumTipodeLinhaLida.DetalheSegmentoT);
                        detalheRetorno.SegmentoT.LerDetalheSegmentoTRetornoCNAB240(linha);

                        linha = stream.ReadLine();

                        OnLinhaLida(detalheRetorno, linha, EnumTipodeLinhaLida.DetalheSegmentoU);
                        detalheRetorno.SegmentoU.LerDetalheSegmentoURetornoCNAB240(linha);
                    }
                    ListaDetalhes.Add(detalheRetorno);
                    linha = stream.ReadLine();
                }
                OnLinhaLida(null, linha, EnumTipodeLinhaLida.TraillerDeLote);
                linha = stream.ReadLine();
                OnLinhaLida(null, linha, EnumTipodeLinhaLida.TraillerDeArquivo);


                stream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler arquivo.", ex);
            }
        }
        #endregion
    }
}
