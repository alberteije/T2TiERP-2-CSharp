using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ComprasClient.View.Compras;
using CloseableTabItemDemo;

namespace ComprasClient.ViewModel.Compras
{
    public class ComprasViewModel : ERPViewModelBase
    {
        public ComprasViewModel()
        {
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in ComprasPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                ComprasPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }
        

    }
}
