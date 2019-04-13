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

namespace BalcaoPAF.View
{
    /// <summary>
    /// Interaction logic for SpedPrincipal.xaml
    /// </summary>
    public partial class PreviewPrincipal : UserControl
    {
        public static string fileName;

        public PreviewPrincipal()
        {
            InitializeComponent();
            CarregaArquivo();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
           //this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CarregaArquivo()
        {
            TextRange range;
            FileStream fStream;
            if (File.Exists(fileName))
            {
                range = new TextRange(richTextBoxArquivo.Document.ContentStart, richTextBoxArquivo.Document.ContentEnd);
                fStream = new FileStream(fileName, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Text);
                fStream.Close();
            }
        }

    }
}
