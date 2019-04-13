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
    /// Interaction logic for TributGrupoTributario.xaml
    /// </summary>
    public partial class TributGrupoTributario : UserControl
    {
        public TributGrupoTributario()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TributGrupoTributarioViewModel)this.DataContext).IsEditar= false;
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
                ((TributGrupoTributarioViewModel)this.DataContext).salvarAtualizarTributGrupoTributario();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((TributGrupoTributarioViewModel)this.DataContext).atualizarListaTributGrupoTributario(0);
                ((TributGrupoTributarioViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
