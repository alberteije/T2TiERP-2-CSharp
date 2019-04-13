using System.Windows;
using System.Windows.Controls;
using CloseableTabItemDemo;

namespace TesourariaClient.View.Tesouraria
{
    /// <summary>
    /// Interaction logic for TesourariaPrincipal.xaml
    /// </summary>
    public partial class TesourariaPrincipal : UserControl
    {
        public static TabControl TabPrincipal;
        public TesourariaPrincipal()
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
