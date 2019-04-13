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
using System.IO;

namespace Wms.View
{
    /// <summary>
    /// Interaction logic for SpedPrincipal.xaml
    /// </summary>
    public partial class WmsColetaPrincipal : UserControl
    {
        byte[] ArquivoGerado;
        public static string CaminhoArquivo;

        public WmsColetaPrincipal()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            Cadastros.View.Menu.JanelaModal.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            ///  Leia o arquivo TXT vindo do coletor e carregue na Grid
            MessageBox.Show("Arquivo Importado com Sucesso!");
        }

        /// EXERCICIO
        ///  Alimente o estoque com base nos dados importados.

        /// EXERCICIO
        ///  Valide os dados. Verifique se o código e a quantidade estão
        ///  dentro do padrões esperado pela aplicação. Caso seu sistema
        ///  tenha mais campos, proceda com as devidas validações.

        /// EXERCICIO
        ///  Verifique se o seu coletor tem a opção de conexão com a rede.
        ///  Caso exista essa possibilidade, crie uma aplicação para coletar os
        ///  dados e sincronize diretamente com o banco usando o servidor.
        
    }
}
