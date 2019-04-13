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

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for SpedPrincipal.xaml
    /// </summary>
    public partial class EdiPrincipal : UserControl
    {
        public EdiPrincipal()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            ERPClient.JanelaEDI.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO: implemente a leitura do arquivo de retorno de acordo com o padrão FEBRABAN    
        }
        
    }
}
