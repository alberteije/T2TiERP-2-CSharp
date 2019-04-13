using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using ContabilidadeClient.View.Contabilidade;
using CloseableTabItemDemo;

namespace ContabilidadeClient.ViewModel.Contabilidade
{
    public class ContabilidadeViewModel
    {
     
        public ContabilidadeViewModel()
        {
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in ContabilidadePrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                ContabilidadePrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }
    }
}
