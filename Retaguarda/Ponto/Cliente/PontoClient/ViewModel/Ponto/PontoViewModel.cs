using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using PontoClient.View.Ponto;
using CloseableTabItemDemo;

namespace PontoClient.ViewModel.Ponto
{
    public class PontoViewModel
    {
        private int _indexTab { get; set; }
        public ObservableCollection<TabItem> tabs { get; set; }

        public PontoViewModel()
        {
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in PontoPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                PontoPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }
    }
}
