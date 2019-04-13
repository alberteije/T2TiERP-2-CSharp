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
using AdministrativoClient.ServicoAdministrativoReference;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for TributConfiguraOfGtPrincipal.xaml
    /// </summary>
    public partial class TributConfiguraOfGtPrincipal : UserControl
    {
        private TributConfiguraOfGtViewModel viewModel;
        public TributConfiguraOfGtPrincipal()
        {
            InitializeComponent();
            viewModel = new TributConfiguraOfGtViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.TributConfiguraOfGtSelected != null)
                {
                    this.criarListas(viewModel.TributConfiguraOfGtSelected);
                    viewModel.IsEditar = true;
                }
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TributConfiguraOfGtDTO TributConfiguraOfGt = new TributConfiguraOfGtDTO();
                this.criarListas(TributConfiguraOfGt);
                viewModel.TributConfiguraOfGtSelected = TributConfiguraOfGt;
                viewModel.IsEditar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.TributConfiguraOfGtSelected != null)
                {
                    viewModel.excluirTributConfiguraOfGt();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaTributConfiguraOfGt(0);
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void criarListas(TributConfiguraOfGtDTO configuracao)
        {
            try
            {
                if (configuracao.ListaTributIpiDipi == null)
                    configuracao.ListaTributIpiDipi = new List<TributIpiDipiDTO>();
                if (configuracao.ListaTributIcmsUf == null)
                    configuracao.ListaTributIcmsUf = new List<TributIcmsUfDTO>();
                if (configuracao.ListaTributPisCodApuracao == null)
                    configuracao.ListaTributPisCodApuracao = new List<TributPisCodApuracaoDTO>();
                if (configuracao.ListaTributCofinsCodApuracao == null)
                    configuracao.ListaTributCofinsCodApuracao = new List<TributCofinsCodApuracaoDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
