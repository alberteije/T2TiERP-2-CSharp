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
    /// Interaction logic for TributConfiguraOfGt.xaml
    /// </summary>
    public partial class TributConfiguraOfGt : UserControl
    {
        public TributConfiguraOfGt()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TributConfiguraOfGtViewModel)this.DataContext).IsEditar= false;
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
                ((TributConfiguraOfGtViewModel)this.DataContext).salvarAtualizarTributConfiguraOfGt();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((TributConfiguraOfGtViewModel)this.DataContext).atualizarListaTributConfiguraOfGt(0);
                ((TributConfiguraOfGtViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarTributOperacaoFiscal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TributConfiguraOfGtViewModel)DataContext).pesquisarTributOperacaoFiscal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarTributGrupoTributario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TributConfiguraOfGtViewModel)DataContext).pesquisarTributGrupoTributario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
