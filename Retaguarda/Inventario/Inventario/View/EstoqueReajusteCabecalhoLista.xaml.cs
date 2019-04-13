using System;
using System.Windows;
using System.Windows.Controls;
using ExportarParaArquivo.Control;
using Cadastros.ViewModel;

namespace EstoqueClient.View.Estoque
{
    
    public partial class EstoqueReajusteCabecalhoLista : UserControl
    {
        public EstoqueReajusteCabecalhoLista()
        {
            InitializeComponent();
            ViewModelBase.DataGridExportacao = this.dataGrid;
        }

    }
}
