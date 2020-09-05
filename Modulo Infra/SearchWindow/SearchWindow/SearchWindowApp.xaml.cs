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
using System.Windows.Shapes;
using System.Reflection;
using System.Collections;
using SearchWindow.ViewModel;

namespace SearchWindow
{
    /// <summary>
    /// Interaction logic for SearchWindowApp.xaml
    /// </summary>
    public partial class SearchWindowApp : Window
    {
        public object itemSelecionado { get; set; }
        private Type classeDTO;
        private Type classeService;
        private SearchWindowMainViewModel searchViewModel;
        public SearchWindowApp(Type classeDTO, Type classeService)
        {
            InitializeComponent();
            this.classeDTO = classeDTO;
            this.classeService = classeService;

            searchViewModel = new SearchWindowMainViewModel(classeDTO, classeService);
            DataContext = searchViewModel;
        }

        public void definirColunas(String[] nomeColunas)
        {
            searchViewModel.definirDataGridColumns(nomeColunas);
        }

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            searchViewModel.pesquisar();
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            itemSelecionado = searchViewModel.itemSelected;
            DialogResult = true;
            this.Close();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            ((TextBox)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();
            searchViewModel.filtrar();
        }

    }
}
