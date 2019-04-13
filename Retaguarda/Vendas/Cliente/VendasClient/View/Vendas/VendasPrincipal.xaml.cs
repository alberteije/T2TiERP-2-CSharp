using System.Windows;
using System.Windows.Controls;
using CloseableTabItemDemo;

namespace VendasClient.View.Vendas
{
    /// <summary>
    /// Interaction logic for VendasPrincipal.xaml
    /// </summary>
    public partial class VendasPrincipal : UserControl
    {
        public static TabControl TabPrincipal;
        public VendasPrincipal()
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
