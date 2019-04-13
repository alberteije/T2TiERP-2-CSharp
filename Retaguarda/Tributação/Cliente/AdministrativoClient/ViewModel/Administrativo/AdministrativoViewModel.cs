using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AdministrativoClient.View.Administrativo;
using CloseableTabItemDemo;

namespace AdministrativoClient.ViewModel.Administrativo
{
    public class AdministrativoViewModel
    {

        public AdministrativoViewModel()
        {
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in AdministrativoPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                AdministrativoPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }
    
    }
}
