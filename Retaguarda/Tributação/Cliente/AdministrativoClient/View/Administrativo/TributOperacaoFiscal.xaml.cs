using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdministrativoClient.ViewModel.Administrativo;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for TributOperacaoFiscal.xaml
    /// </summary>
    public partial class TributOperacaoFiscal : UserControl
    {
        public TributOperacaoFiscal()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TributOperacaoFiscalViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TributOperacaoFiscalViewModel)this.DataContext).salvarAtualizarTributOperacaoFiscal();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((TributOperacaoFiscalViewModel)this.DataContext).atualizarListaTributOperacaoFiscal(0);
                ((TributOperacaoFiscalViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
