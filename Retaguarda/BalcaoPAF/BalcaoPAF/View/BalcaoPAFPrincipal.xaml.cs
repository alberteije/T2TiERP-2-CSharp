using System.Windows;
using System.Windows.Controls;
using CloseableTabItemDemo;

namespace BalcaoPAF.View
{
    /// <summary>
    /// Interaction logic for BalcaoPAFPrincipal.xaml
    /// </summary>
    public partial class BalcaoPAFPrincipal : UserControl
    {
        public static TabControl TabPrincipal;
        public BalcaoPAFPrincipal()
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
