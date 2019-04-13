using BalcaoPAF.ServidorReference;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BalcaoPAF.View
{
    /// <summary>
    /// Interaction logic for SpedPrincipal.xaml
    /// </summary>
    public partial class SpedFiscalPrincipal : UserControl
    {
        byte[] ArquivoGerado;
        public static string CaminhoArquivo;
        public static Window JanelaPreview;

        public SpedFiscalPrincipal()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            BalcaoPAFMenu.JanelaSpedFiscal.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceServidor Service = new ServiceServidor();
                ArquivoGerado = Service.GerarSped(
                    dpDataInicio.Text,
                    dpDataFim.Text,
                    cbVersaoLayout.SelectedIndex.ToString(),
                    cbFinalidadeArquivo.SelectedIndex.ToString(),
                    cbPerfilApresentacao.SelectedIndex.ToString(),
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
                string CaminhoTemp = System.IO.Path.GetTempPath() + "SpedFiscal.txt";
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
