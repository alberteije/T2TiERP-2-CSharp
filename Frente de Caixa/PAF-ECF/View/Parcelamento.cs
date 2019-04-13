/* *******************************************************************************
  Title: T2TiPDV
  Description: Gera Parcelas para o Contas a Receber.

  The MIT License

  Copyright: Copyright (C) 2014 T2Ti.COM

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
  alberteije@gmail.com

  @author T2Ti.COM
  @version 2.0
  ******************************************************************************* */


using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PafEcf.View
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
		   
          List<ContasParcelasVO> ListaParcelaDetalhe = new List<ContasParcelasVO>;
          if( VendaCabecalho.IdCliente < 1 )
          {
            MessageBox.Show("Escolha um cliente para Parcelar!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
          }
          Identificacao = "E" + Convert.ToString( Configuracao.IdEmpresa ) + "X" + Convert.ToString( Configuracao.IdCaixa ) + "V" + DevolveInteiro(FCaixa.edtNVenda.Text) + "C" + DevolveInteiro(FCaixa.edtCOO.Text);
		
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
              ParcelaCabecalho = new TContasPagarReceberVO();
              ParcelaCabecalho.IdEcfVendaCabecalho = UCaixa.VendaCabecalho.Id;
              ParcelaCabecalho.IdPlanoContas = 1;
              ParcelaCabecalho.IdTipoDocumento = 1;
              ParcelaCabecalho.IdPessoa = UCaixa.VendaCabecalho.IdCliente;
              ParcelaCabecalho.Tipo = "R";
              ParcelaCabecalho.NumeroDocumento = Identificacao + "Q" + qtdParcelas.Text;
              ParcelaCabecalho.Valor = Total;
              ParcelaCabecalho.DataLancamento = UCaixa.VendaCabecalho.DataVenda;
              ParcelaCabecalho.PrimeiroVencimento = DataParaTexto(editVencimento.DateTime.Now);
              ParcelaCabecalho.NaturezaLancamento = "S";
              ParcelaCabecalho.QuantidadeParcela = qtdParcelas.Asint;
              ParcelaCabecalho.IdEcfVendaCabecalho = UCaixa.VendaCabecalho.Id;
              ParcelaCabecalho.IdPessoa = UCaixa.VendaCabecalho.IdCliente;
              ParcelaCabecalho.DataLancamento = UCaixa.VendaCabecalho.DataVenda;
              ParcelaCabecalho.Tipo = "R";
              ParcelaCabecalho.Valor = Total;
              ParcelaCabecalho.NaturezaLancamento = "S";
              ParcelaCabecalho = TParcelaController.InserirCabecalho(ParcelaCabecalho);
              ListaParcelaDetalhe = TObjectList<TContasParcelasVOnew >();
		
              CDSParcela.MoveFirst();
              while( ! CDSParcela.Eof )
              {
                ParcelaDetalhe = new TContasParcelasVO();
                ParcelaDetalhe.IdContasPagarReceber = ParcelaCabecalho.Id;
                ParcelaDetalhe.DataEmissao = UCaixa.VendaCabecalho.DataVenda;
                ParcelaDetalhe.DataVencimento = DataParaTexto(CDSParcelaVencimento.AsDateTime);
                ParcelaDetalhe.NumeroParcela = Convert.ToInt32(CDSParcelaParcela.Text);
                ParcelaDetalhe.Valor = Convert.ToDouble(CDSParcelaValor.Text);
                ParcelaDetalhe.TaxaJuros = 0;
                ParcelaDetalhe.TaxaMulta = 0;
                ParcelaDetalhe.TaxaDesconto = 0;
                ParcelaDetalhe.ValorJuros = 0;
                ParcelaDetalhe.ValorMulta = 0;
                ParcelaDetalhe.ValorDesconto = 0;
                ParcelaDetalhe.TotalParcela = Convert.ToDouble(CDSParcelaValor.Text);
                ParcelaDetalhe.Historico = "";
                ParcelaDetalhe.Situacao = "A";
                ListaParcelaDetalhe.AppendText(ParcelaDetalhe);
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
		
		
        public void DBGrid1KeyDown(object sender, KeyEventArgs e)
        {
           double qt, Total, valorant, prest, Resto;

         if( (e.KeyValue == vk_return) )
          {
            Total = 0;
            prest = 0;
            qt = 0;
            valorant = 0;
		
            CDSParcela.EndEdit();
		
            //  quantas parcelas ainda faltam
            while( ! CDSParcela.Eof )
            {
              qt = qt + 1;
              CDSParcela.MoveNext();
            }
            qt = qt - 1;
		
            //  pega o saldo das parcelas anteriores
            while( ! CDSParcela.bof )
            {
              valorant = valorant + Convert.ToDouble( ((DataRowView)CDSParcela.Current).Row["Valor"]);
              CDSParcela.MovePrevious();
            }
		
            Total = editValorParcelar.Value - valorant;
		
            if( (Total >= 0) )
            {
              if( (Total > 0) && (qt > 0) )
              {
                prest = System.Math.Round(Total / qt);
                Resto = (Total - (prest * qt));
                // CDSParcela.Edit
                Convert.ToDouble( ((DataRowView)CDSParcela.Current).Row["VALOR"]) = Convert.ToDouble( ((DataRowView)CDSParcela.Current).Row["VALOR"]) + Resto;
                CDSParcela.EndEdit();
              }
		
              CDSParcela.MoveNext();
		
              while( ! CDSParcela.Eof )
              {
                // CDSParcela.Edit
                Convert.ToDouble( ((DataRowView)CDSParcela.Current).Row["VALOR"]) = prest;
                CDSParcela.EndEdit();
                CDSParcela.MoveNext();
              }
              CDSParcela.GotoBookmark(Bookmark);
            }
            else
            {
              MessageBox.Show("O Valor Informado ? Invalido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CDSParcela.Edit;
          }
        }
		
		
        public void GridKeyPress(object sender, KeyPressEventArgs e)
        {
          if( (e.KeyValue == Chr(9)) )
            return;
		
          if( (Grid.SelectedField.FieldName == "Vencimento") )
          {
            jvDBDateEdit1.Focus();
            SendMessage(jvDBDateEdit1.Handle, WM_Char, (short)(e.KeyValue), 0);
          }
        }
		
		
        public void qtdParcelasChange(object Sender )
        {
          CalculaParcelas();
        }
		
		
        public void botaoLocalizaClienteClick(object Sender )
        {
		
          FIdentificaCliente FIdentificaCliente = new FIdentificaCliente();
          FIdentificaCliente.ShowDialog();
          if( Cliente.Nome.Trim() != "" )
          {
            editNome.Text = Cliente.Nome;
            editCPF.Text = Cliente.CpfOuCnpj;
            TVendaController.AlteraClienteNaVenda(VendaCabecalho.Id, Cliente.Id, Cliente.CpfOuCnpj, Cliente.Nome);
            VendaCabecalho.IdCliente = Cliente.Id;
            VendaCabecalho.NomeCliente = Cliente.Nome;
            VendaCabecalho.CPFouCNPJCliente = Cliente.CpfOuCnpj;
          }
        }
		
*/
    }
		
}
