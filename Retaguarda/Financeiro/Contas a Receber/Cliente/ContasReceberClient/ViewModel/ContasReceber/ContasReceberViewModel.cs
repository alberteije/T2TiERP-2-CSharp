using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContasReceberClient.ContasReceberService;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using ContasReceberClient.View.ContasReceber;
using System.IO;
using BoletoNet;
using Microsoft.Win32;
using CloseableTabItemDemo;

namespace ContasReceberClient.ViewModel.ContasReceber
{
    public class ContasReceberViewModel : ERPViewModelBase
    {
     
        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in ContasReceberPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                ContasReceberPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

   
        public ContasReceberViewModel()
        {
        }
    }
}
