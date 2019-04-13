/* *******************************************************************************
Title: T2TiNFCe
Description: Gera Parcelas para o Contas a Receber.

The MIT License

Copyright: Copyright (C) 2015 T2Ti.COM

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

The author may be contacted at:
t2ti.com@gmail.com

@author T2Ti.COM
@version 1.0
******************************************************************************* */


using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NFCe.View
{
	
	public partial class Parcelamento : Form
	{
		
		public Parcelamento()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
		}

        /*
		
        public void botaoConfirmaClick(object Sender )
        {
          decimal Total, ValoraParcelar;
          string Identificacao;
		   
          List<FinParcelaReceberDTO> ListaParcelaDetalhe = new List<FinParcelaReceberDTO>;
          if( VendaCabecalho.IdCliente < 1 )
          {
            MessageBox.Show("Escolha um cliente para Parcelar!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
          }
          Identificacao = "E" + Convert.ToString( Configuracao.IdEmpresa ) + "X" + Convert.ToString( Configuracao.IdCaixa ) + "V" + DevolveInteiro(FCaixa.edtNVenda.Text) + "C" + DevolveInteiro(FCaixa.edtNumeroNota.Text);
         * 
         * 25 365
         * E1X2V25C365
		
          Total = 0;
          ValoraParcelar = Convert.ToDouble(editValorParcelar.Text);
		
          CDSParcela.MoveFirst();
          while( ! CDSParcela.Eof )
          {
            Total = Total + CDSParcelaValor.AsFloat;
            CDSParcela.MoveNext();
          }
		
          if( (Total == ValoraParcelar) )
          {
            try {
                ParcelaCabecalho.IdFinDocumentoOrigem = 1;
                ParcelaCabecalho.IdCliente = 1;
                ParcelaCabecalho.QuantidadeParcela = qtdParcelas.AsInteger;
                ParcelaCabecalho.ValorTotal = Total;
                ParcelaCabecalho.ValorAReceber = Total;
                ParcelaCabecalho.DataLancamento = Date;
                ParcelaCabecalho.NumeroDocumento = Identificacao + 'Q' + qtdParcelas.Text;
                ParcelaCabecalho.PrimeiroVencimento = editVencimento.Date;
                ParcelaCabecalho.CodigoModuloLcto = 'NFC';

              CDSParcela.MoveFirst();
              while( ! CDSParcela.Eof )
              {
                ParcelaDetalhe = new TFinParcelaReceberDTO();
                ParcelaDetalhe.IdContaCaixa = 1;
                ParcelaDetalhe.IdFinStatusParcela = 1;
                ParcelaDetalhe.NumeroParcela = Convert.ToInt32(CDSParcelaParcela.Text);
                ParcelaDetalhe.DataEmissao = Date;
                ParcelaDetalhe.DataVencimento = CDSParcelaVencimento.AsDateTime;
                ParcelaDetalhe.Valor = Convert.ToDouble(CDSParcelaValor.Text);                
                ListaParcelaDetalhe.Add(ParcelaDetalhe);
                CDSParcela.MoveNext();
              }
		
              ParcelaController.InserirDetalhe(ListaParcelaDetalhe);
              confirmou = true;
            } 
            finally 
            {
            }
            this.Close();
          }
          else
            MessageBox.Show("A soma das Parcelas difere do valor a parcelar!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
		
        
        public void CalculaParcelas()
        {
           int x, QtdPar;
           System.DateTime Vencimento;
           double ValorTotal, ValorParcela, Resto;
          
         if( CDSParcela )
            CDSParcela.EmptyDataSet;
          else
            CDSParcela.CreateDataSet;
		
          QtdPar = Convert.ToInt32(qtdParcelas.Text);
          ValorTotal = Convert.ToDouble(editValorParcelar.Text);
          ValorParcela = System.Math.Round(ValorTotal / QtdPar);
          Resto = (ValorTotal - (ValorParcela * QtdPar));
		
          Vencimento = editVencimento.DateTime.Now;
		
          for( x = 1;x <= QtdPar;x++)
          {
            CDSParcela.Append;
            CDSParcelaParcela.Asint = x;
            CDSParcelaVencimento.AsDateTime = Vencimento;
            if( x == 1 )
              CDSParcelaValor.AsFloat = ValorParcela + Resto;
            else
              CDSParcelaValor.AsFloat = ValorParcela;
            CDSParcela.EndEdit();
            Vencimento = IncMonth(Vencimento);
          }
          CDSParcela.Edit;
        }
		
		
        public void editVencimentoChange(object Sender )
        {
          CalculaParcelas();
        }
		
		
        public void FormActivate(object Sender )
        {
          editVencimento.DateTime.Now = DateTime.Now + 30;
          qtdParcelas.Focus();
        }
		
		
        public void FormClose(object sender, EventArgs e)
        {
          if( confirmou )
            DialogResult = DialogResult.OK;
        }
		
		
        public void FormCreate(object Sender )
        {
          confirmou = false;
          qtdParcelas.MaxValue = Configuracao.QtdeMaximaParcelas;
        }
		
		
        public void FormKeyDown(object sender, KeyEventArgs e)
        {
          if( e.KeyValue == 27 )
            botaoCancela.Click;
          if( (e.KeyValue == 112) )
            botaoLocalizaCliente.Click;
        }
		
*/
    }
		
}
