using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Cadastros.ViewModel;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueReajusteCabecalhoPrincipal.xaml
    /// </summary>
    public partial class EstoqueReajusteCabecalhoPrincipal : UserControl
    {
        private EstoqueReajusteCabecalhoViewModel viewModel;
        public EstoqueReajusteCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new EstoqueReajusteCabecalhoViewModel();
            this.DataContext = viewModel;
        }

    }
}
