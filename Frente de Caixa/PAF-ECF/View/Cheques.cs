 

using System;
using System.Windows.Forms;

namespace PafEcf.View
{
	
	  
	public partial class Cheques : Form
	{
		
		public Cheques()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
		}

        public void bFrenteClick(object Sender )
        {
            /*
          pVerso.Visible = false;
          pFrente.Visible = true;
             * */
        }
		
        public void bImprimirClick(object Sender )
        {
            /*
          System.DateTime Data;
          if( cbMes.Items.IndexOf(cbMes.Text) < 0 )
          {
            MessageBox.Show("Mês invalido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbMes.Focus();
            return;
          }
		
          if( Convert.ToDecimal(edValor.Text) == 0 )
          {
            MessageBox.Show("Valor invalido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            edValor.Focus();
            return;
          }
		
          Data = DateTime.Now;
		
          if( (! ACBrCHQ1.ChequePronto) )
          {
            MessageBox.Show("Cheque não está posicionado na Impressora!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bImprimir.Focus();
            return;
          }
		
          ACBrCHQ1.Banco = edBanco.Text;
          ACBrCHQ1.Valor = Convert.ToDouble(edValor.Text);
          ACBrCHQ1.Data = Data;
          ACBrCHQ1.Favorecido = edFavorecido.Text;
          ACBrCHQ1.Cidade = edCidade.Text;
		
          ACBrCHQ1.ImprimirCheque;
             * */
        }
		
        public void bImpVersoClick(object Sender )
        {
          //ACBrCHQ1.ImprimirVerso(mVerso.Lines);
        }
		
        public void botaoConfirmaClick(object Sender )
        {
            /*
          List<ChequeClienteVO> ListaCheques = new List<ChequeClienteVO>();
          if( VendaCabecalho.IdCliente < 1 )
          {
            MessageBox.Show("Escolha um cliente para Parcelar!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
          }
		
          CDSCheque.MoveFirst();
          while( ! CDSCheque.Eof )
          {
            Cheque = new TChequeClienteVO();
		
            Cheque.IdEcfMovimento = FCaixa.VendaCabecalho.IdMovimento;
            Cheque.IdCliente = FCaixa.VendaCabecalho.IdCliente;
            Cheque.DataCheque = CDSChequeData.AsDatetime.ToString("yyyy-mm-dd");
            Cheque.NumeroCheque = CDSChequeCheque.Asint;
            Cheque.ValorCheque = CDSChequeValor.AsFloat;
            Cheque.Agencia = CDSChequeAgencia.AsString;
            Cheque.Conta = CDSChequeConta.AsString;
            Cheque.IdBanco = CDSChequeIDBANCO.Asint;
            Cheque.Observacoes = CDSChequeObs.AsString;
            Cheque.TipoCheque = CDSChequeTipo.AsString;
		
            ListaCheques.AppendText(Cheque);
            CDSCheque.MoveNext();
             
          }
		
          if(ChequeController.IncluirCheque(ListaCheques))
          {
            confirmou = true;
            this.Close();
          }
             * * */
        }

        public void btnAdicionarClick(object Sender )
        {/*
          System.DateTime Data;
          if( cbMes.Items.IndexOf(cbMes.Text) < 0 )
          {
            MessageBox.Show("Mês invalido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbMes.Focus();
            return;
          }
		
          if( StrToFloatDef(edValor.Text, 0) == 0 )
          {
            MessageBox.Show("Valor invalido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            edValor.Focus();
            return;
          }
		
          if( edBanco.Text.Trim() == "" )
          {
            MessageBox.Show("Banco invalido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            edBanco.Focus();
            return;
          }
		
          if( edAgencia.Text.Trim() == "" )
          {
            MessageBox.Show("Agencia invalida!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            edAgencia.Focus();
            return;
          }
		
          if( edConta.Text.Trim() == "" )
          {
            MessageBox.Show("Conta invalida!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            edConta.Focus();
            return;
          }
		
          if( edNumero.Text.Trim() == "" )
          {
            MessageBox.Show("Cheque invalido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            edNumero.Focus();
            return;
          }
		
          try {
            Data = EncodeDate(Convert.ToInt32(edAno.Text), cbMes.Items.IndexOf(cbMes.Text) + 1, Convert.ToInt32(edDia.Text));
          }
          catch(Exception)
          {
            MessageBox.Show("Data Invalida!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            edDia.Text;
            return;
          }
		
          CDSCheque.Append;
          CDSChequeIDBANCO.Asint = Banco.Id;
          CDSChequeBanco.AsString = edBanco.Text;
          CDSChequeAgencia.AsString = edAgencia.Text;
          CDSChequeConta.AsString = edConta.Text;
          CDSChequeCheque.AsString = edNumero.Text;
          CDSChequeObs.AsString = MemObs.Text;
          CDSChequeData.AsDatetime = Data;
          CDSChequeTipo.AsString = cmbTipo.Text.Substring( 1, 1);
          CDSChequeValor.AsFloat = Convert.ToDouble(edValor.Text);
          CDSCheque.EndEdit();
          Banco.Id = 0;
        */}
		
        public void btnRemoverClick(object Sender )
        {
            /*
          if( ! CDSCheque.IsEmpty )
            CDSCheque.Delete;
             * */
        }
        
        public void btObterChequeClick(object Sender )
        {/*
         string sDado, sBanco, sAgencia, sCheque, sContacc;
          if( !(InputDialog id = new InputDialog("Leitura Otica do Cheque",  "Passe o Cheque no Leitor",  sDado);) )
            return;
		
          if( sDado != "" )
          {
            sDado = DevolveInteiro(sDado);
            sBanco = sDado.Substring( 3, 1);
            sAgencia = sDado.Substring( 4, 4);
            sCheque = sDado.Substring( 6, 12);
            sContacc = sDado.Substring( 7, 22) + "-" + sDado.Substring( 1, 29);
          }
        */}
		
		
        public void bVersoClick(object Sender )
        {/*
          pFrente.Visible = false;
          pVerso.Visible = true;
        */}
		
		
        public void edBancoExit(object Sender )
        {/*
          edBanco.Text = IntToStrZero(Convert.ToInt32(edBanco.Text, 0), 3);
          Banco.Id = BancoController.ConsultaIDBanco(Convert.ToInt32(edBanco.Text));
          if( Banco.Id == 0 )
          {
            MessageBox.Show("Banco invalido!!!", "Informação do Sistema", MB_OK);
            edBanco.Focus();
          }
        */}
		
		
        public void edValorExit(object Sender )
        {/*
         string Texto, Tracos;
           int Pos, Tamanho;
          ACBrExtenso1.Valor = StrToFloatDef(edValor.Text, 0);
		
          //  Verificando se o extenso cabe na linha de cima 
          Tracos = "";
          Texto = "(" + ACBrExtenso1.Texto.Trim() + ")"; = Texto.Length;
          using(FCheques.Canvas){ lExtenso1.
            Tamanho = TextWidth(Texto);
		
            while( (Tamanho > lExtenso1.Width) )
            {
              //  Acha um espa?o 
              while( (Texto[] != " ") && ( > 0) ) = - 1; = - 1;
              Tamanho = TextWidth(Texto.Substring( , 1));
            }
		
            //  Inserindo tra?os no inicio 
            if( < Texto.Length )
            {
              while( (Tamanho < lExtenso1.Width) )
              {
                Tracos = Tracos + "-";
                Tamanho = TextWidth(Tracos + Texto.Substring( , 1));
              }
              Tracos = Tracos.Substring( Tracos.Length - 1, 1);
            }
          }
		
          lExtenso1.Text = Tracos + Texto.Substring( , 1);
          lExtenso2.Text = Texto.Substring( Texto.Length , + 2);
        */}
		
		
        public void edValorKeyPress(object sender, KeyPressEventArgs e)
        {/*
          if( CharInSet(e.KeyValue, [",", "."]) )
            e.KeyValue = DecimalSeparator;
        */}
		
		
        public void FormClose(object sender, EventArgs e)
        {/*
          if( confirmou )
            DialogResult = DialogResult.OK;
          Banco.Dispose();
        */}
		
		
        public void FormCreate(object Sender )
        {/*
          Banco = new TBancoVO();
          confirmou = false;
          pFrente.Visible = true;
          pVerso.Visible = false;
		
          edDia.Text = Convert.ToString( DayOf(DateTime.Now) );
          cbMes.Text = cbMes.Items[MonthOf(DateTime.Now) - 1];
          edAno.Text = Convert.ToString( YearOf(DateTime.Now) );
		
          //  TALVEZ SEJA O CASO DE MAIS UM PARAMETRO PARA DETERMINAR SE O COMPONENTE
          //  ACBrCHQ VAI IMPRIMIR EM UMA IMPRESSORA COMUM OU NA PROPRIA IMPRESSORA FISCAL
          //  SE FOR O CASO DA PROPRIA IMPRESSORA FISCA (PARA OS MODELOS QUE TEM ESTA FUNCAO NATURALMENTE)
          //  FAZER O DEVIDO LINK ENTRE ESTE COMPONETE E O ACBRECF.
		
          if( CDSCheque )
            CDSCheque.EmptyDataSet;
          else
            CDSCheque.CreateDataSet;
        */}
		
		
        public void FormKeyDown(object sender, KeyEventArgs e)
        {/*
          if( e.KeyValue == 27 )
            botaoCancela.PerformClick();
        */}
		
		
        public void FormShow(object Sender )
        {/*
          edBanco.Focus();
          edBanco.SelectAll;
        */}
		
		
        public void SpeedButton1Click(object Sender )
        {/*
		
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
        */}
		

    }
		
}
