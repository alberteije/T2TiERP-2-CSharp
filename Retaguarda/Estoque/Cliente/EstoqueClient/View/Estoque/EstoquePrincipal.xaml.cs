using System.Windows;
using System.Windows.Controls;
using CloseableTabItemDemo;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for PontoPrincipal.xaml
    /// </summary>
    public partial class EstoquePrincipal : UserControl
    {
        public static TabControl TabPrincipal;
        public EstoquePrincipal()
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
