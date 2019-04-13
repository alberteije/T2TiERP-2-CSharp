using BalcaoPAF.ServidorReference;
using BalcaoPAF.View;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SpedClient.View.Sped
{
    /// <summary>
    /// Interaction logic for SpedPrincipal.xaml
    /// </summary>
    public partial class SpedContabilPrincipal : UserControl
    {
        byte[] ArquivoGerado;
        public static string CaminhoArquivo;
        public static Window JanelaPreview;

        public SpedContabilPrincipal()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            BalcaoPAFMenu.JanelaSpedContabil.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceServidor Service = new ServiceServidor();
                ArquivoGerado = Service.GerarSpedContabil(
                    dpDataInicio.Text,
                    dpDataFim.Text,
                    cbFormaEscrituracao.SelectedIndex.ToString(),
                    cbVersaoLayout.SelectedIndex.ToString(),
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
                string CaminhoTemp = System.IO.Path.GetTempPath() + "SpedContabil.txt";
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
