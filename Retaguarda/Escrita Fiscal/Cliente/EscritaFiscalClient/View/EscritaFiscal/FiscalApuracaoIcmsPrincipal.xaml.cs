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
using EscritaFiscalClient.ViewModel.EscritaFiscal;
using EscritaFiscalClient.ServicoEscritaFiscalReference;

namespace EscritaFiscalClient.View.EscritaFiscal
{
    /// <summary>
    /// Interaction logic for FiscalApuracaoIcmsPrincipal.xaml
    /// </summary>
    public partial class FiscalApuracaoIcmsPrincipal : UserControl
    {
        private FiscalApuracaoIcmsViewModel viewModel;
        public FiscalApuracaoIcmsPrincipal()
        {
            InitializeComponent();
            viewModel = new FiscalApuracaoIcmsViewModel();
            this.DataContext = viewModel;
        }

    }
}
