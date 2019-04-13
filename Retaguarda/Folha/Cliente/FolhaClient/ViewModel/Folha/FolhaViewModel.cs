using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FolhaClient.View.Folha;
using CloseableTabItemDemo;
using ComponenteFolha;
using FolhaClient.ServicoFolhaReference;
using Microsoft.Win32;

namespace FolhaClient.ViewModel.Folha
{
    public class FolhaViewModel : ERPViewModelBase
    {

        public FolhaViewModel()
        {
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in FolhaPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                FolhaPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

        public void gerarCaged(string pCompetencia, string pAlteracao)
        {
            using (ServicoFolhaClient serv = new ServicoFolhaClient())
            {
                Empresa = serv.selectEmpresaId(Empresa.Id);
            }

            ComponenteFolha.ComponenteFolha folha = new ComponenteFolha.ComponenteFolha();

            // REGISTRO A (AUTORIZADO)
            FolhaCagedRegistroTipoA RegistroTipoA = new FolhaCagedRegistroTipoA();
            RegistroTipoA.Competencia = pCompetencia;
            RegistroTipoA.Alteracao = pAlteracao;
            RegistroTipoA.TipoIdentificador = "1"; //CNPJ
            RegistroTipoA.NumeroIdentificadorDoAutorizado = Empresa.Cnpj;
            RegistroTipoA.NomeRazaoSocialDoAutorizado = Empresa.RazaoSocial;
            RegistroTipoA.Endereco = Empresa.endereco.logradouro + " " + Empresa.endereco.numero;
            RegistroTipoA.Cep = Empresa.endereco.cep;
            RegistroTipoA.UF = Empresa.endereco.uf;
            RegistroTipoA.Telefone = Empresa.endereco.fone;
            folha.CagedRegistroTipoA = RegistroTipoA;

            // REGISTRO B (ESTABELECIMENTO)
            FolhaCagedRegistroTipoB RegistroTipoB = new FolhaCagedRegistroTipoB();
            RegistroTipoB.TipoIdentificador = "1"; //CNPJ
            RegistroTipoB.NumeroIdentificadorDoEstabelecimento = Empresa.Cnpj;
            RegistroTipoB.PrimeiraDeclaracao = "1";
            RegistroTipoB.Alteracao = pAlteracao;
            RegistroTipoB.Cep = Empresa.endereco.cep;
            RegistroTipoB.NomeRazaoSocialDoEstabelecimento = Empresa.RazaoSocial;
            RegistroTipoB.Endereco = Empresa.endereco.logradouro + " " + Empresa.endereco.numero;
            RegistroTipoB.Bairro = Empresa.endereco.bairro;
            RegistroTipoB.UF = Empresa.endereco.uf;
            RegistroTipoB.TotalDeEmpregadosExistentesNoPrimeiroDia = "0";
            RegistroTipoB.PorteDoEstabelecimento = "1";
            RegistroTipoB.Cnae2ComSubClasse = "";
            RegistroTipoB.Telefone = Empresa.endereco.fone;
            RegistroTipoB.Email = Empresa.Email;
            folha.CagedRegistroTipoB = RegistroTipoB;

            //REGISTRO C (MOVIMENTAÇÃO)
            List<ColaboradorDTO> listaColaborador = new List<ColaboradorDTO>();
            try
            {
                using (ServicoFolhaClient serv = new ServicoFolhaClient())
                {
                    listaColaborador = serv.selectColaborador(new ColaboradorDTO());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (listaColaborador.Count > 0)
            {
                List<FolhaCagedRegistroTipoC> listaRegistroC = new List<FolhaCagedRegistroTipoC>();
                for (int i = 0; i < listaColaborador.Count; i++)
                {

                    FolhaCagedRegistroTipoC RegistroTipoC = new FolhaCagedRegistroTipoC();

                    RegistroTipoC.TipoIdentificador = "1";
                    RegistroTipoC.NumeroIdentificadorDoEstabelecimento = Empresa.Cnpj;
                    RegistroTipoC.PisPasep = listaColaborador[i].PisNumero;
                    RegistroTipoC.Admissao = listaColaborador[i].DataAdmissao.Value;

                    listaRegistroC.Add(RegistroTipoC);
                }
                folha.ListaCagedRegistroTipoC = listaRegistroC;
            }

            //REGISTRO X (ACERTO)
            // Implementado a critério do Participante do T2Ti ERP 

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Arquivo Caged (*.txt) | *.txt";
            dialog.Title = "Selecione o arquivo";
            dialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (dialog.ShowDialog() == true)
            {
                folha.gerarArquivoCaged(dialog.FileName);
            }

        }


        public void gerarSefip(string pCompetencia, string pCodigoRecohimento)
        {
            using (ServicoFolhaClient serv = new ServicoFolhaClient())
            {
                Empresa = serv.selectEmpresaId(Empresa.Id);
            }

            ComponenteFolha.ComponenteFolha folha = new ComponenteFolha.ComponenteFolha();

            // REGISTRO TIPO 00 – Informações do Responsável (Header do arquivo)
            FolhaSefipRegistroTipo00 RegistroTipo00 = new FolhaSefipRegistroTipo00();
            RegistroTipo00.TipoRemessa = "1"; //1=GFIP
            RegistroTipo00.TipoInscricaoResponsavel = "1"; //1=CNPJ
            RegistroTipo00.InscricaoResponsavel = Empresa.Cnpj;
            RegistroTipo00.NomeResponsavel = Empresa.RazaoSocial;
            RegistroTipo00.NomeContato = Empresa.RazaoSocial;
            RegistroTipo00.Logradouro = Empresa.endereco.logradouro;
            RegistroTipo00.Bairro = Empresa.endereco.bairro;
            RegistroTipo00.CEP = Empresa.endereco.cep;
            RegistroTipo00.Cidade = Empresa.endereco.cidade;
            RegistroTipo00.UnidadeFederacao = Empresa.endereco.uf;
            RegistroTipo00.TelefoneContato = Empresa.endereco.fone;
            RegistroTipo00.EnderecoInternetContato = Empresa.Email;
            RegistroTipo00.Competencia = pCompetencia;
            RegistroTipo00.CodigoRecolhimento = pCodigoRecohimento;
            RegistroTipo00.IndicadorRecolhimentoFGTS = "1"; //1 (GRF no prazo)
            RegistroTipo00.ModalidadeArquivo = "1"; //1 - Declaração ao FGTS e à Previdência
            RegistroTipo00.TipoInscricaoFornecedorFolhaPagamento = "1"; //1=CNPJ
            RegistroTipo00.DataRecolhimentoFGTS = DateTime.Now;
            RegistroTipo00.IndicadorRecolhimentoPrevidenciaSocial = "1"; //1 (no prazo)
            RegistroTipo00.DataRecolhimentoPrevidenciaSocial = DateTime.Now;
            RegistroTipo00.TipoInscricaoFornecedorFolhaPagamento = "1"; //1=CNPJ
            RegistroTipo00.InscricaoFornecedorFolhaPagamento = Empresa.Cnpj;
            folha.SefipRegistroTipo00 = RegistroTipo00;

            //REGISTRO TIPO 10 – Informações da Empresa (Header da empresa )
            FolhaSefipRegistroTipo10 RegistroTipo10 = new FolhaSefipRegistroTipo10();
            RegistroTipo10.TipoInscricaoEmpresa = "1"; //1=CNPJ
            RegistroTipo10.InscricaoEmpresa = Empresa.Cnpj;
            RegistroTipo10.NomeEmpresaRazaoSocial = Empresa.RazaoSocial;
            RegistroTipo10.Logradouro = Empresa.endereco.logradouro;
            RegistroTipo10.Bairro = Empresa.endereco.bairro;
            RegistroTipo10.Cep = Empresa.endereco.cep;
            RegistroTipo10.Cidade = Empresa.endereco.cidade;
            RegistroTipo10.UnidadeFederacao = Empresa.endereco.uf;
            RegistroTipo10.TelefoneContato = Empresa.endereco.fone;
            RegistroTipo10.IndicadorAlteracaoEndereco = "N";
            RegistroTipo10.CNAE = ""; //Empresa.CodigoCnaePrincipal;
            RegistroTipo10.IndicadorAlteracaoCNAE = "N";
            RegistroTipo10.AliquotaRAT = "00"; //Será zeros para FPAS 604, 647, 825, 833 e 868 (empregador doméstico) e para a empresa optante pelo SIMPLES.
            RegistroTipo10.CodigoCentralizacao = "1"; //1 (centralizadora)
            RegistroTipo10.SIMPLES = "2"; //2 – Optante;
            RegistroTipo10.FPAS = ""; //Empresa.DescricaoFpas;
            RegistroTipo10.CodigoOutrasEntidades = Empresa.CodigoTerceiros;
            RegistroTipo10.CodigoPagamentoGPS = Empresa.CodigoGps.ToString();
            folha.SefipRegistroTipo10 = RegistroTipo10;

            //REGISTRO TIPO 12 – Informações Adicionais do Recolhimento da Empresa (Opcional)
            //{ Implementado a critério do Participante do T2Ti ERP }

            //REGISTRO TIPO 13 – Alteração Cadastral Trabalhador (Opcional)
            //{ Implementado a critério do Participante do T2Ti ERP }

            //REGISTRO TIPO 14 – Inclusão/Alteração Endereço do Trabalhador (Opcional)
            //{ Implementado a critério do Participante do T2Ti ERP }

            //REGISTRO TIPO 20 – Registro do Tomador de Serviço/Obra de Construção Civil (Opcional)
            //{ Implementado a critério do Participante do T2Ti ERP }

            //REGISTRO TIPO 21 - Registro de informações adicionais do Tomador de Serviço/Obra de Const. Civil (Opcional)
            //{ Implementado a critério do Participante do T2Ti ERP }


            //REGISTRO TIPO 30 - Registro do Trabalhador
            List<ColaboradorDTO> listaColaborador = new List<ColaboradorDTO>();
            try
            {
                using (ServicoFolhaClient serv = new ServicoFolhaClient())
                {
                    listaColaborador = serv.selectColaborador(new ColaboradorDTO());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (listaColaborador.Count > 0)
            {
                List<FolhaSefipRegistroTipo30> listaRegistro30 = new List<FolhaSefipRegistroTipo30>();
                for (int i = 0; i < listaColaborador.Count; i++)
                {

                    FolhaSefipRegistroTipo30 RegistroTipo30 = new FolhaSefipRegistroTipo30();

                    RegistroTipo30.TipoInscricaoEmpresa = RegistroTipo10.TipoInscricaoEmpresa;
                    RegistroTipo30.InscricaoEmpresa = RegistroTipo10.InscricaoEmpresa;
                    RegistroTipo30.PISPASEPCI = listaColaborador[i].PisNumero;
                    RegistroTipo30.DataAdmissao = listaColaborador[i].DataAdmissao.Value;
                    RegistroTipo30.CategoriaTrabalhador = listaColaborador[i].CategoriaSefip;
                    RegistroTipo30.NomeTrabalhador = listaColaborador[i].Pessoa.Nome;
                    RegistroTipo30.MatriculaEmpregado = listaColaborador[i].Matricula;
                    RegistroTipo30.NumeroCTPS = listaColaborador[i].CtpsNumero;
                    RegistroTipo30.SerieCTPS = listaColaborador[i].CtpsSerie;
                    RegistroTipo30.DataOpcao = listaColaborador[i].FgtsDataOpcao.Value;

                    listaRegistro30.Add(RegistroTipo30);
                }
                folha.ListaSefipRegistroTipo30 = listaRegistro30;
            }

            //REGISTRO TIPO 32 – Movimentação do Trabalhador (Opcional)
            //{ Implementado a critério do Participante do T2Ti ERP }

            //REGISTRO TIPO 50– Empresa Com Recolhimento pelos códigos 027, 046, 604 e 736 (Header da empresa ) (PARA IMPLEMENTAÇÃO FUTURA)
            //{ Implementado a critério do Participante do T2Ti ERP }

            //REGISTRO TIPO 51 - Registro de Individualização de valores recolhidos pelos códigos 027, 046, 604 e 736 (PARA IMPLEMENTAÇÃO FUTURA)
            //{ Implementado a critério do Participante do T2Ti ERP }

            FolhaSefipRegistroTipo90 RegistroTipo90 = new FolhaSefipRegistroTipo90();
            folha.SefipRegistroTipo90 = RegistroTipo90;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Arquivo Sefip (*.txt) | *.txt";
            dialog.Title = "Selecione o arquivo";
            dialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (dialog.ShowDialog() == true)
            {
                folha.gerarArquivoSefip(dialog.FileName);
            }

        }
    }
}
