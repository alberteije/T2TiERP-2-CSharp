using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using EscritaFiscalClient.View.EscritaFiscal;
using CloseableTabItemDemo;

namespace EscritaFiscalClient.ViewModel.EscritaFiscal
{
    public class EscritaFiscalViewModel
    {

        public EscritaFiscalViewModel()
        {
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in EscritaFiscalPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                EscritaFiscalPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }


    }
}
