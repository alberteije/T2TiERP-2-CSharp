using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponenteFolha
{
    public class FolhaSefipRegistroTipo00
    {
        public string TipoRegistro { get; set; } // N 2. Campo obrigatório. Sempre “00”.
        // Brancos. 51 AN - Campo obrigatório. Preencher com brancos Tratar dele no momento de gerar o registro.
        public string TipoRemessa { get; set; } /* (Para indicar se o arquivo referese a recolhimento mensal ou recolhimento específico do FGTS).
																 N 1. Campo obrigatório. Só pode ser 1 (GFIP), ou 3 (DERF).
																 A opção 3 será implementada futuramente e somente deverá ser utilizada quando autorizada pela CAIXA.*/
        public string TipoInscricaoResponsavel { get; set; } /*1 N. Campo obrigatório. Só pode ser 1 (CNPJ), 2 (CEI) ou 3 (CPF).
																Só pode ser igual a 3 (CPF), para o código de recolhimento 418.*/
        public string InscricaoResponsavel { get; set; } /*14 N. Campo obrigatório.
																 Deve ser informada a inscrição (CNPJ/CEI) do certificado responsável pela transmissão do arquivo pelo Conectividade.
																 Se Tipo Inscrição = 1, então número esperado CNPJ válido. Se Tipo Inscrição = 2, então número esperado CEI válido.
																 Se Tipo Inscrição = 3, então número esperado CPF válido.*/
        public string NomeResponsavel { get; set; } /*30 AN. Campo obrigatório. Não pode conter caracteres especiais.
																 Não pode haver caracteres acentuados.
																 Não é permitido mais de um espaço entre os nomes. Não é permitido três ou mais caracteres iguais consecutivos.
																 A primeira posição não pode ser branco. Pode conter apenas caracteres de A a Z e números de 0 a 9.*/
        public string NomeContato { get; set; } /*20 A. Campo obrigatório. Não pode conter número. Não pode conter caracteres especiais.
																 Não pode haver caracteres acentuados. Não é permitido mais de um espaço entre os nomes.
																 Não é permitido três ou mais caracteres iguais consecutivos. A primeira posição não pode ser branco.
																 Pode conter apenas caracteres de A a Z.*/
        public string Logradouro { get; set; } /*50 AN. Campo obrigatório. Não pode conter caracteres especiais.
																 Não pode haver caracteres acentuados. Não é permitido mais de um espaço entre os nomes.
																 Não é permitido três ou mais caracteres iguais consecutivos. A primeira posição não pode ser branco.
																 Permitido apenas caracteres de A a Z e números de 0 a 9.*/
        public string Bairro { get; set; } /*20 AN. Campo obrigatório. Não pode conter caracteres especiais. Não pode haver caracteres acentuados.
																 Não é permitido mais de um espaço entre os nomes. Não é permitido três ou mais caracteres iguais consecutivos.
																 A primeira posição não pode ser branco. Permitido apenas caracteres de A a Z e números de 0 a 9.*/
        public string CEP { get; set; } //{8 N. Campo obrigatório. Número de CEP válido. Permitido apenas, números diferentes de 20000000, 30000000, 70000000 ou 80000000.}
        public string Cidade { get; set; } /*20 AN. Campo obrigatório. Não pode conter caracteres especiais. Não pode haver caracteres acentuados.
																 Não é permitido mais de um espaço entre os nomes. Não é permitido três ou mais caracteres iguais consecutivos.
																 A primeira posição não pode ser branco. Permitido apenas caracteres de A a Z e números de 0 a 9.*/
        public string UnidadeFederacao { get; set; } // 2 A. Campo obrigatório. Deve constar da tabela de unidades da federação.}
        public string TelefoneContato { get; set; } // 12 N - Campo obrigatório. Deve conter no mínimo 02 dígitos válidos no DDD e 07 dígitos no telefone.
        public string EnderecoInternetContato { get; set; } // 60 AN - Campo opcional. Endereço INTERNET válido.
        public string Competencia { get; set; } /* 6 D -  Campo obrigatório. Formato AAAAMM, onde AAAA indica o ano e MM o mês da competência. O mês informado deve ser de 1 a 13
															 O ano informado deve maior ou igual a 1967. Acatar o mês de competência 13 para ano maior ou igual a 1999.
															 Não pode ser informado competência 13 para os códigos de recolhimento 130, 135, 145, 211, 307,317, 327, 337, 345, 640, 650 e 660.
															 Acatar apenas competência maior ou igual a 03/2000 para código de recolhimento 211.
															 Acatar apenas competência menor que 10/1988 para o código de recolhimento 640.
															 Acatar apenas competência maior ou igual a 03/2000 para empregador doméstico. */
        public string CodigoRecolhimento { get; set; } /* 3 N - Campo obrigatório. Os códigos de recolhimento 418 e 604 são utilizados exclusivamente na Entrada de Dados do SEFIP.
																Informação deve estar contida na tabela de Código de Recolhimento. */
        public string IndicadorRecolhimentoFGTS { get; set; } /* 1 N - (Para identificar se o recolhimento será realizado no prazo, em atraso,
																 se mediante ação fiscal ou ainda se refere-se à individualização de valores já recolhidos). Pode ser 1 (GRF no prazo),
																 2 (GRF em atraso), 3 (GRF em atraso – Ação Fiscal),5 (Individualização) 6 (Individualização – Ação Fiscal) ou branco.
																 Campo obrigatório para os códigos de recolhimento 115, 130, 135, 145, 150, 155, 307, 317, 327,337, 345, 608, 640, 650 e 660.
																 Os códigos de recolhimento 145, 307, 317, 327, 337, 345 e 640 não aceitam indicador igual a 1(GRF no prazo).
																 Não pode ser informado para o código de recolhimento 211. Não pode ser informado na competência 13.
																 Sempre que não informado o campo deve ficar em branco. */
        public string ModalidadeArquivo { get; set; } /* 1 N - (Para identificar a que tipo de modalidade o arquivo se refere)
																 Pode ser Branco – Recolhimento ao FGTS e Declaração à Previdência. 1 - Declaração ao FGTS e à Previdência
																 9 - Confirmação Informações anteriores – Rec/Decl ao FGTS e Decl à Previdência. Para competência anterior a 10/1998 deve ser igual a branco ou 1.
																 A modalidade 9 não pode ser informada para competências anteriores a 10/1998. Para os códigos 145, 307, 317, 327, 337, 345 e 640 deve ser igual a branco.
																 Para o código 211 deve ser igual a 1 ou 9. Para o FPAS 868 deve igual a branco ou 9. Para a competência 13, deve ser igual a 1 ou 9.
																 Serão acatadas até três cargas consecutivas de SEFIP.RE. Deverá existir apenas um arquivo SEFIP.RE para cada modalidade. */
        public DateTime DataRecolhimentoFGTS { get; set; } /* 8 D - (Indicar a data efetiva de recolhimento do FGTS, sempre que o
																 recolhimento for realizado em atraso (Indicador 2 e 3) e no caso de individualização (Indicador 5 e 6)) Obs.:
																 Os campos Código de Recolhimento e Indicador de Recolhimento FGTS determinam a obrigatoriedade desta data. Formato DDMMAAAA.
																 A tabela contendo o edital para recolhimento em atraso, é disponibilizada em arquivo, nas agências
																 da Caixa ou no site www.caixa.gov.br. Não pode ser informado quando o indicador de recolhimento do FGTS for igual a 1 (GRF no prazo).
																 Sempre que não informado o campo deve ficar em branco. */
        public string IndicadorRecolhimentoPrevidenciaSocial { get; set; } /* 1 N -(Para identificar se o recolhimento da Previdência Social será realizado no prazo ou em atraso)Campo obrigatório. Só pode ser 1 (no prazo), 2 (em atraso) ou 3 (não gera GPS).
																Deve ser igual a 3, para competência anterior a 10/1998 e para os códigos de recolhimento exclusivos do FGTS (145, 307, 317, 327, 337, 345, 640 e 660). */
        public DateTime DataRecolhimentoPrevidenciaSocial { get; set; } /* 8 D - (Indicar a data efetiva de recolhimento da Previdência Social, sempre que o recolhimento for realizado em atraso)
														 Obs. O Indicador de Recolhimento da Previdência Social determina a obrigatoriedade desta data. Formato DDMMAAAA.
														 Só pode ser informado se Indicador de Recolhimento Previdência Social for igual a 2 e a data informada for posterior ao dia 10 do mês seguinte ao da competência.
														 Para código de recolhimento 650 deve ser posterior ao dia 02 do mês seguinte ao da competência. Para competência 13, deve ser posterior a 20/12/AAAA, onde AAAA é o ano a que se refere a
														 competência. Sempre que não informado o campo deve ficar em branco. */
        public string IndiceRecolhimentoAtrasoPrevidenciaSocial { get; set; } /* 7 N - (Para recolhimentos efetuados a partir do 2º mês seguinte ao do vencimento.
															 Referente à taxa SELIC + 2%). Campo deve ficar em branco. A tabela para recolhimento de GPS em atraso (SELIC) será disponibilizada, mensalmente, no site
															 www.caixa.gov.br e www.previdenciasocial.gov.br. */
        public string TipoInscricaoFornecedorFolhaPagamento { get; set; } // 1 N - Campo obrigatório. Só pode ser 1 (CNPJ), 2 (CEI) ou 3 (CPF).
        public string InscricaoFornecedorFolhaPagamento { get; set; } /* 14 N - Campo obrigatório.
															 Se Tipo Inscrição = 1, então número esperado CNPJ válido. Se Tipo Inscrição = 2, então número esperado CEI válido.
															 Se Tipo Inscrição = 3, então número esperado CPF válido. */
        // Brancos. 18 AN - Campo obrigatório. Preencher com brancos Tratar dele no momento de gerar o registro.
        // Final de Linha 1 AN - Deve ser uma constante “*” para marcar fim de linha. Tratar dele no momento de gerar o registro.

        public FolhaSefipRegistroTipo00()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponenteFolha.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("00");
            retorno += Funcoes.LFill(" ", 51);
            retorno += Funcoes.LFill(TipoRemessa == null ? "" : TipoRemessa, 1);
            retorno += Funcoes.LFill(TipoInscricaoResponsavel == null ? "" : TipoInscricaoResponsavel, 1);
            retorno += Funcoes.LFill(InscricaoResponsavel == null ? "" : InscricaoResponsavel, 14);
            retorno += Funcoes.LFill(NomeResponsavel == null ? "" : NomeResponsavel, 30);
            retorno += Funcoes.LFill(NomeContato == null ? "" : NomeContato, 20);
            retorno += Funcoes.LFill(Logradouro == null ? "" : Logradouro, 50);
            retorno += Funcoes.LFill(Bairro == null ? "" : Bairro, 20);
            retorno += Funcoes.LFill(CEP == null ? "" : CEP, 8);
            retorno += Funcoes.LFill(Cidade == null ? "" : Cidade, 20);
            retorno += Funcoes.RFill(UnidadeFederacao == null ? "" : UnidadeFederacao, 2);
            retorno += Funcoes.LFill(TelefoneContato == null ? "" : TelefoneContato, 12);
            retorno += Funcoes.LFill(EnderecoInternetContato == null ? "" : EnderecoInternetContato, 60);
            retorno += Funcoes.LFill(Competencia == null ? "" : Competencia, 6);
            retorno += Funcoes.LFill(CodigoRecolhimento == null ? "" : CodigoRecolhimento, 3);
            retorno += Funcoes.LFill(IndicadorRecolhimentoFGTS == null ? "" : IndicadorRecolhimentoFGTS, 1);
            retorno += Funcoes.LFill(ModalidadeArquivo == null ? "" : ModalidadeArquivo, 1);
            retorno += Funcoes.LFill(DataRecolhimentoFGTS == null ? "" : DataRecolhimentoFGTS.ToString("ddMMyyyy"), 8);
            retorno += Funcoes.LFill(IndicadorRecolhimentoPrevidenciaSocial == null ? "" : IndicadorRecolhimentoPrevidenciaSocial, 1);
            retorno += Funcoes.LFill(DataRecolhimentoPrevidenciaSocial == null ? "" : DataRecolhimentoPrevidenciaSocial.ToString("ddMMyyyy"), 8);
            retorno += Funcoes.LFill(IndiceRecolhimentoAtrasoPrevidenciaSocial == null ? "" : IndiceRecolhimentoAtrasoPrevidenciaSocial, 7);
            retorno += Funcoes.LFill(TipoInscricaoFornecedorFolhaPagamento == null ? "" : TipoInscricaoFornecedorFolhaPagamento, 1);
            retorno += Funcoes.LFill(InscricaoFornecedorFolhaPagamento == null ? "" : InscricaoFornecedorFolhaPagamento, 14);
            retorno += Funcoes.LFill(" ", 18);
            retorno += Funcoes.LFill("*");

            return retorno;
        }

    }
}
