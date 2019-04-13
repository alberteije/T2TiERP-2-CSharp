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
using PatrimonioClient.ViewModel.Patrimonio;

namespace PatrimonioClient.View.Patrimonio
{
    /// <summary>
    /// Interaction logic for PatrimGrupoBem.xaml
    /// </summary>
    public partial class PatrimGrupoBem : UserControl
    {
        public PatrimGrupoBem()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimGrupoBemViewModel)this.DataContext).IsEditar= false;
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
                ((PatrimGrupoBemViewModel)this.DataContext).salvarAtualizarPatrimGrupoBem();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PatrimGrupoBemViewModel)this.DataContext).atualizarListaPatrimGrupoBem(0);
                ((PatrimGrupoBemViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

	}
}
