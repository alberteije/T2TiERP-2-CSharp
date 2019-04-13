using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using PatrimonioClient.View.Patrimonio;
using CloseableTabItemDemo;

namespace PatrimonioClient.ViewModel.Patrimonio
{
    public class PatrimonioViewModel
    {

        public PatrimonioViewModel()
        {
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in PatrimonioPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                PatrimonioPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

    }
}
