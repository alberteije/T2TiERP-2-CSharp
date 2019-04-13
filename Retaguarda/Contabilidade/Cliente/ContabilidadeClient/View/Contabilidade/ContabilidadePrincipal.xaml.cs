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
using ContabilidadeClient.View.Contabilidade;
using ContabilidadeClient.ViewModel.Contabilidade;
using CloseableTabItemDemo;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilidadePrincipal.xaml
    /// </summary>
    public partial class ContabilidadePrincipal : UserControl
    {
        public static TabControl TabPrincipal;
        public ContabilidadePrincipal()
        {
            InitializeComponent();
            TabPrincipal = TabControlPrincipal;
            TabPrincipal.AddHandler(CloseableTabItem.CloseTabEvent, new RoutedEventHandler(this.CloseTab));
        }

        private void CloseTab(object source, RoutedEventArgs args)
        {
            TabItem tabItem = args.Source as TabItem;
            if (tabItem != null)
            {
                TabControl tabControl = tabItem.Parent as TabControl;
                if (tabControl != null)
                    tabControl.Items.Remove(tabItem);
            }
        }

    }
}
