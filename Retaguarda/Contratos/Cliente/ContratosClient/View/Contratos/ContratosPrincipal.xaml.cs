using System.Windows;
using System.Windows.Controls;
using CloseableTabItemDemo;

namespace ContratosClient.View.Contratos
{
    /// <summary>
    /// Interaction logic for ContratosPrincipal.xaml
    /// </summary>
    public partial class ContratosPrincipal : UserControl
    {
        public static TabControl TabPrincipal;
        public ContratosPrincipal()
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
