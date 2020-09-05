using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using SearchWindow.Attributes;
using System.Windows.Media;

namespace SearchWindow.ViewModel
{
    public class SearchWindowMainViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<string> listaAtributos { get; set; }
        public ObservableCollection<Object> listaItens { get; set; }
        public DataGrid dataGrid { get; set; }
        public string atributoSelected { get; set; }

        public string textoPesquisa { get;  set;  }
        private object ItemSelected;
        private Type classeDTO;
        private Type classeService;

        public SearchWindowMainViewModel(Type dto, Type servico)
        {
            try
            {
                this.classeDTO = dto;
                this.classeService = servico;

                listaAtributos = new ObservableCollection<string>();
                listaItens = new ObservableCollection<object>();

                dataGrid = new DataGrid();

                Binding listaI = new Binding
                {
                    Path = new PropertyPath("listaItens"),
                    Mode = BindingMode.TwoWay,
                };
                dataGrid.SetBinding(DataGrid.ItemsSourceProperty, listaI);

                Binding itemSel = new Binding
                {
                    Path = new PropertyPath("itemSelected"),
                    Mode = BindingMode.TwoWay,
                };
                dataGrid.SetBinding(DataGrid.SelectedItemProperty, itemSel);
                dataGrid.AutoGenerateColumns = false;
                dataGrid.IsReadOnly = true;
                dataGrid.Background = new SolidColorBrush(Colors.White);
                dataGrid.SelectionMode = DataGridSelectionMode.Single;

                Object objetoPesquisa = Activator.CreateInstance(classeDTO);
                PropertyInfo[] atributos = objetoPesquisa.GetType().GetProperties();
                IList<DataGridTextColumn> listaDataGrid = new List<DataGridTextColumn>();
                bool colunasDefault = true;

                foreach (PropertyInfo pi in atributos)
                {
                    string nomeAtributo = pi.Name;
                    object[] listaAtrib = pi.GetCustomAttributes(false);

                    foreach (object atributo in listaAtrib)
                    {
                        if (atributo is ColunaDataGrid)
                        {
                            ColunaDataGrid colunaAtributo = (ColunaDataGrid)atributo;

                            if (colunasDefault)
                            {
                                colunasDefault = false;
                                listaDataGrid.Clear();
                            }

                            if (colunaAtributo.visivel)
                            {
                                string nomeHeader = !string.IsNullOrEmpty(colunaAtributo.cabecalho) ?
                                 colunaAtributo.cabecalho : nomeAtributo;

                                listaDataGrid.Add(montarColuna(nomeHeader, nomeAtributo, colunaAtributo.indicePosicao));
                            }
                        }
                    }

                    if (colunasDefault && pi.PropertyType.Equals(typeof(string)))
                    {
                        listaDataGrid.Add(montarColuna(nomeAtributo, nomeAtributo));
                    }
                }

                foreach (DataGridTextColumn col in listaDataGrid)
                {
                    dataGrid.Columns.Add(col);
                    listaAtributos.Add(((Binding)col.Binding).Path.Path);
                }

                //Definicao das colunas 
                MethodInfo[] metodos = classeService.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                string[] listaProp = null;
                string[] listaCab = null;

                foreach (MethodInfo mi in metodos)
                {
                    object[] listaAnot = mi.GetCustomAttributes(false);
                    foreach (Object anot in listaAnot)
                    {
                        if (anot is SearchWindowDataSource &&
                            ((SearchWindowDataSource)anot).tipoDTO.Equals(classeDTO))
                        {
                            listaProp = ((SearchWindowDataSource)anot).listaPropriedades;
                            listaCab = ((SearchWindowDataSource)anot).listaCabecalhos;
                        }
                            
                    }
                }

                if (listaProp != null && listaProp.Length > 0)
                {
                    dataGrid.Columns.Clear();
                    for(int i =0; i < listaProp.Length;i++)
                    {
                        dataGrid.Columns.Add(montarColuna(listaCab[i], listaProp[i]));
                    }
                }
                atributoSelected = listaAtributos.First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void filtrar()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            collectionView.Filter = null;
            if (!String.IsNullOrEmpty(textoPesquisa))
            {
                collectionView.Filter = filtro;
            }
        }

        public bool filtro(Object item)
        {
            object valor = classeDTO.GetProperty(atributoSelected).GetValue(item, null);
            if (valor != null && valor.ToString().ToLower().Contains(textoPesquisa.ToLower()))
                return true;
            else
                return false;
        }
        private DataGridTextColumn montarColuna(string nomeColuna, string nomeProp, int ind)
        {
            DataGridTextColumn textColumn = this.montarColuna(nomeColuna, nomeProp);
            if(ind != 0)
                textColumn.DisplayIndex = ind;
            return textColumn;
        }
        private DataGridTextColumn montarColuna(string nomeColuna, string nomeProp)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = nomeColuna;
            textColumn.Binding = new Binding(nomeProp);
            textColumn.Width = DataGridLength.Auto;
            return textColumn;
        }
        public void definirDataGridColumns(String[] nomeColuna)
        {
            dataGrid.Columns.Clear();
            foreach (String nomeCol in nomeColuna)
            {
                dataGrid.Columns.Add(montarColuna(nomeCol, nomeCol)); 
            }
        }

        public object itemSelected
        {
            get { return ItemSelected; }
            set
            {
                ItemSelected = value;
                notifyPropertyChanged("isItemSelected");
            }
        }

        public bool isItemSelected
        {
            get 
            { 
                return itemSelected != null; 
            }
        }

        public void pesquisar()
        {
            try
            {
                //SearchWindowDataSource searchWindowDS = (SearchWindowDataSource) Attribute.GetCustomAttribute(

                Object objetoPesquisa = Activator.CreateInstance(classeDTO);
                MethodInfo[] metodos = classeService.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                MethodInfo methodInfo = null;

                foreach (MethodInfo mi in metodos)
                {
                    object[] listaAnot = mi.GetCustomAttributes(false);
                    foreach (Object anot in listaAnot)
                    {
                        if (anot is SearchWindowDataSource && 
                            ((SearchWindowDataSource)anot).tipoDTO.Equals(classeDTO))
                            methodInfo = mi;
                    }
                }

                Object servico = Activator.CreateInstance(classeService);

                if (!String.IsNullOrEmpty(atributoSelected) &&
                    !String.IsNullOrEmpty(textoPesquisa))
                {
                    Type tipoProp = classeDTO.GetProperty(atributoSelected).PropertyType;
                    object valor = tipoProp.IsGenericType ? 
                        Convert.ChangeType(textoPesquisa, Nullable.GetUnderlyingType(tipoProp)) :
                        Convert.ChangeType(textoPesquisa, tipoProp);
                    classeDTO.GetProperty(atributoSelected).SetValue(objetoPesquisa, valor, null);
                }

                IList resultado = null;
                if(methodInfo.GetParameters().Count() > 0)
                    resultado = (IList)methodInfo.Invoke(servico, new[] { objetoPesquisa });
                else
                    resultado = (IList)methodInfo.Invoke(servico, null);

                listaItens.Clear();
                foreach (Object obj in resultado)
                    listaItens.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void notifyPropertyChanged(String propertyName)
        {
            checkIfPropertyNameExists(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void checkIfPropertyNameExists(String propertyName)
        {
            Type type = this.GetType();
            Debug.Assert(
              type.GetProperty(propertyName) != null,
              propertyName + " propriedade não encontrada : " + type.FullName);
        }
    }
}
