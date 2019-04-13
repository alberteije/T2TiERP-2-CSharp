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
using System.Diagnostics;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for SpedPrincipal.xaml
    /// </summary>
    public partial class AtualizaBanco : UserControl
    {
        public AtualizaBanco()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            ERPClient.JanelaAtualizaBanco.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "AtualizaBd.bat";
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();
            MessageBox.Show("Banco de Dados Atualizado com Sucesso.", "Informação do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
    }
}
