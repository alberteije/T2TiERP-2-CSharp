using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Cadastros.ViewModel;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueContagemCabecalhoPrincipal.xaml
    /// </summary>
    public partial class EstoqueContagemCabecalhoPrincipal : UserControl
    {
        private InventarioContagemCabViewModel viewModel;
        public EstoqueContagemCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new InventarioContagemCabViewModel();
            this.DataContext = viewModel;
        }

    }
}
