using BalcaoPAF.ServidorReference;
using BalcaoPAF.View;
using ContratosClient.Model;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SpedClient.View.Sped
{
    /// <summary>
    /// Interaction logic for SpedPrincipal.xaml
    /// </summary>
    public partial class eSocialPrincipal : UserControl
    {
        byte[] ArquivoGerado;
        public static string CaminhoArquivo;
        public static Window JanelaPreview;

        public eSocialPrincipal()
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
                GeraESocial eSocial = new GeraESocial();
                eSocial.gerarESocial1000("2016-01", "2016-12");
                eSocial.gerarESocial1010("2016-01", "2016-12");

                CaminhoArquivo = "C:\\T2Ti\\Arquivos\\eSocial_info_empregador.xml";

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
