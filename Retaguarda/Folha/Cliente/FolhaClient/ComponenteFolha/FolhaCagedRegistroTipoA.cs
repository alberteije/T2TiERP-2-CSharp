using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponenteFolha
{
    public class FolhaCagedRegistroTipoA
    {

        public string TipoRegistro { get; set; } // 1 A. Define o registro a ser informado. Obrigatoriamente o conteúdo é A.
        public string TipoLayOut { get; set; } // 5 A. Informe qual o layout do arquivo CAGED. Obrigatoriamente o conteúdo é L2009.
        //public string  FFiller1                        { get; set; } // 2 A. Deixar em branco. Tratar na geração do arquivo
        public string Competencia { get; set; } // 6 N. Mês e ano de referência das informações do CAGED. Informar sem máscara(/.\-,).
        public string Alteracao { get; set; }  // 1 N. Define se os dados cadastrais informados irão ou não atualizar o Cadastro de Autorizados do CAGED Informatizado. 1. Nada a alterar - 2. Alterar dados cadastrais}
        public string Sequencia { get; set; } // 5 N. Número seqüencial no arquivo.
        public string TipoIdentificador { get; set; } // 1 N. Define o tipo de identificador do estabelecimento a informar. 1. CNPJ - 2. CEI
        public string NumeroIdentificadorDoAutorizado { get; set; } // 14 N. Número identificador do estabelecimento. Não havendo inscrição do estabelecimento no Cadastro Nacional de Pessoa Jurídica (CNPJ), informar o número de registro no CEI (Código Específico do INSS). O número do CEI tem 12 posições, preencher este campo com 00(zeros) à esquerda.}
        public string NomeRazaoSocialDoAutorizado { get; set; } // 35 A.Nome/Razão Social do estabelecimento autorizado.
        public string Endereco { get; set; } // 40 A.Informar o Endereço do estabelecimento / autorizado (Rua, Av, Trav, Pç) com número e complemento.
        public string Cep { get; set; } // 8  N. Informar o Código de Endereçamento Postal do estabelecimento conforme a tabela da Empresa de Correios e Telégrafos-ECT. Informar sem  máscara (/.\-,).}
        public string UF { get; set; } // 2 A. Informar a Unidade de Federação.
        public string DDD { get; set; } // 4 N. Informar DDD do telefone para contato para contato com o Ministério do Trabalho e Emprego.
        public string Telefone { get; set; } // 8 N. Informar o número do telefone para contato com o responsável pelas informações contidas no arquivo CAGED.
        public string Ramal { get; set; } // 5 N. Informar o ramal se houver complemento do telefone informado.
        public string TotalDeEstabelecimentosInformados { get; set; } // 5 N. Quantidade de registros tipo B (Estabelecimento) informados no arquivo.
        public string TotalDeMovimentacoesInformadas { get; set; } // 5 N. Quantidade de registros tipo C e/ou X (Empregado) informados no arquivo.
        //public string  Filler2                         { get; set; } // 92 A. Deixar em branco. Tratar na geração do arquivo.

        public FolhaCagedRegistroTipoA()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponenteFolha.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("A");
            retorno += Funcoes.LFill("L2009");
            retorno += Funcoes.LFill(" ");
            retorno += Funcoes.LFill(Competencia == null ? "" : Competencia, 6);
            retorno += Funcoes.LFill(Alteracao == null ? "" : Alteracao, 1);
            retorno += Funcoes.LFill(ComponenteFolha.NSR, 5);
            retorno += Funcoes.LFill(TipoIdentificador == null ? "" : TipoIdentificador, 1);
            retorno += Funcoes.LFill(NumeroIdentificadorDoAutorizado == null ? "" : NumeroIdentificadorDoAutorizado, 14);
            retorno += Funcoes.LFill(NomeRazaoSocialDoAutorizado == null ? "" : NomeRazaoSocialDoAutorizado, 35);
            retorno += Funcoes.LFill(Endereco == null ? "" : Endereco, 40);
            retorno += Funcoes.LFill(Cep == null ? "" : Endereco, 8);
            retorno += Funcoes.LFill(UF == null ? "" : UF, 2);
            retorno += Funcoes.LFill(DDD == null ? "" : DDD, 4);
            retorno += Funcoes.LFill(Telefone == null ? "" : Telefone, 8);
            retorno += Funcoes.LFill(Ramal == null ? "" : Ramal, 5);
            retorno += Funcoes.LFill(TotalDeEstabelecimentosInformados == null ? "" : TotalDeEstabelecimentosInformados, 5);
            retorno += Funcoes.LFill(TotalDeMovimentacoesInformadas == null ? "" : TotalDeMovimentacoesInformadas, 5);
            retorno += Funcoes.LFill(" ", 92);
            
            return retorno;
        }

    }
}
