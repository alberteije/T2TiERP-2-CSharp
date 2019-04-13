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
using BalcaoPAF.ViewModel;
using BalcaoPAF.ServidorReference;
using System.IO;

namespace BalcaoPAF.View
{
    /// <summary>
    /// Interaction logic for SintegraPrincipal.xaml
    /// </summary>
    public partial class SintegraPrincipal : UserControl
    {
        byte[] ArquivoGerado;
        public static string CaminhoArquivo;
        public static Window JanelaPreview;

        public SintegraPrincipal()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            BalcaoPAFMenu.JanelaSintegra.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceServidor Service = new ServiceServidor();
                ArquivoGerado = Service.GerarSintegra(
                    dpDataInicio.Text,
                    dpDataFim.Text,
                    cbCodigoConvenio.SelectedIndex.ToString(),
                    cbFinalidadeArquivo.SelectedIndex.ToString(),
                    cbNaturezaInformacoes.SelectedIndex.ToString(),
                    "1",
                    "0",
                    "1"
                     );

                CaminhoArquivo = salvaArquivoTempLocal();

                //System.Diagnostics.Process.Start(CaminhoArquivo); - se quiser abrir no editor padrão do windows

                PreviewPrincipal janela = new PreviewPrincipal();
                PreviewPrincipal.fileName = CaminhoArquivo;
                Window window = new Window()
                {
                    Title = "Preview",
                    ShowInTaskbar = false,
                    Topmost = false,
                    ResizeMode = ResizeMode.NoResize,
                    Width = 1010,
                    Height = 740,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
                };
                window.Content = janela;
                JanelaPreview = window;
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string salvaArquivoTempLocal()
        {
            try
            {
                string CaminhoTemp = System.IO.Path.GetTempPath() + "Sintegra.txt";
                var StreamRecebido = new System.IO.MemoryStream(ArquivoGerado);

                if (!File.Exists(CaminhoTemp))
                {
                    using (FileStream fs = new FileStream(CaminhoTemp, FileMode.Create, FileAccess.ReadWrite))
                    {
                        StreamRecebido.WriteTo(fs);
                        fs.Close();
                    }
                }
                return CaminhoTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
