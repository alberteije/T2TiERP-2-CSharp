using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponenteFolha
{
    public class FolhaSefipRegistroTipo10
    {
        public string TipoRegistro { get; set; } // 2 N - Campo obrigatório. Sempre “10”.
        public string TipoInscricaoEmpresa { get; set; } // 1 N - Campo obrigatório. Só pode ser 1 (CNPJ) ou 2 (CEI). Para empregador doméstico só pode ser 2(CEI).
        public string InscricaoEmpresa { get; set; } /* 14 N - Campo obrigatório. Se Tipo Inscrição = 1, então número esperado CNPJ válido.
																				Se Tipo Inscrição = 2, então número esperado CEI válido. Para empregador doméstico só pode acatar 2 (CEI). */
        // Zeros. 36 N - Campo obrigatório. Preencher com zeros. Tratar dele no momento de gerar o registro.
        public string NomeEmpresaRazaoSocial { get; set; } /* 40 AN - Campo obrigatório. Não pode conter caracteres especiais. Não pode haver caracteres acentuados.
																				 Não é permitido mais de um espaço entre os nomes. Não é permitido três ou mais caracteres iguais consecutivos.
																				 A primeira posição não pode ser branco. Permitido apenas caracteres de A a Z e números de 0 a 9. */
        public string Logradouro { get; set; } /* 50 AN - Rua, nº, andar,apartamento. Campo obrigatório. Não pode conter caracteres especiais. Não pode haver caracteres acentuados.
																				 Não é permitido mais de um espaço entre os nomes. Não é permitido três ou mais caracteres iguais consecutivos. A primeira posição não pode ser branco.
																				 Pode conter apenas caracteres de A a Z e números de 0 a 9. */
        public string Bairro { get; set; } /* 20 AN - Campo obrigatório. Não pode conter caracteres especiais. Não pode haver caracteres acentuados.
																				 Não é permitido mais de um espaço entre os nomes. Não é permitido três ou mais caracteres iguais consecutivos. A primeira posição não pode ser branco.
																				 Pode conter apenas caracteres de A a Z e números de 0 a 9. */
        public string Cep { get; set; } // 8 N - Campo obrigatório. Número de CEP válido. Permitido apenas, números diferentes de 20000000, 30000000, 70000000 ou 80000000.
        public string Cidade { get; set; } /* 20 AN - Campo obrigatório. Não pode conter caracteres especiais.
																				 Não pode haver caracteres acentuados. Não é permitido mais de um espaço entre os nomes. Não é permitido três ou mais caracteres
																				 iguais consecutivos. A primeira posição não pode ser branco. Pode conter apenas caracteres de A a Z e números de 0 a 9. */
        public string UnidadeFederacao { get; set; } // 2 A - Campo obrigatório. Deve constar da tabela de unidades da federação
        public string TelefoneContato { get; set; } // 12 N - Campo obrigatório. Deve conter no mínimo 02 dígitos válidos no DDD e 07 dígitos no telefone.
        public string IndicadorAlteracaoEndereco { get; set; } /* 1 A - Campo obrigatório. Só pode ser “S” ou “s” quando a empresa desejar
																				alterar o endereço e “N” ou “n” quando não desejar modificá-lo. Para a competência 13, preencher com “N” ou “n”. */
        public string CNAE { get; set; } /* 7 N - Campo obrigatório. Número válido de CNAE. Para empregador doméstico
																				utilizar o número 9700500.*/
        public string IndicadorAlteracaoCNAE { get; set; } /* 1 A - Campo obrigatório. Para os códigos 145, 307, 317, 327, 337, 345,
																				 e 660 e competências até 05/2008 pode ser 
																				 - “S” ou “s” se desejar alterar o CNAE - “N” ou “n” se não desejar alterar .
																				 · Para competências a partir de 06/2008 pode ser  - “S” ou “s” se desejar alterar o CNAE - “N” ou “n” se não desejar alterar .
																				 - “A” ou “a” se desejar alterar e for CNAE preponderante. - “P” ou “p” se não desejar alterar e for CNAE preponderante.
																				 Para a competência 13, preencher com “N” ou “n”. */
        public string AliquotaRAT { get; set; } /* 2 N - (Informar alíquota para o cálculo da contribuição destinada ao
																				 financiamento dos benefícios concedidos em razão de incidência de incapacidade laborativa decorrente dos riscos ambientais do
																				 trabalho – RAT). Campo obrigatório. Campo com uma posição inteira e uma decimal. Campo obrigatório para competência maior ou
																				 igual a 10/1998. Não pode ser informado para competências anteriores a 10/1998.
																				 Não pode ser informado para competências anteriores a 04/99 quando o FPAS for 639.
																				 Não pode ser informado para os códigos de recolhimento 145, 307, 317, 327, 337, 345, 640 e 660.
																				 Será zeros para FPAS 604, 647, 825, 833 e 868 (empregador doméstico) e para a empresa optante pelo SIMPLES.
																				 Não pode ser informado para FPAS 604 com recolhimento de código 150 em competências posteriores a 10/2001.
																				 Sempre que não informado o campo deve ficar em branco. */
        public string CodigoCentralizacao { get; set; } /* 1 N - (Para indicar as empresas que centralizam o recolhimento do FGTS ).
																				 Campo obrigatório. Só pode ser 0 (não centraliza), 1 (centralizadora) ou 2 (centralizada).
																				 Deve ser igual a zero (0), para os códigos de recolhimento 130, 135, 150, 155, 211, 317, 337, 608 e para empregador doméstico (FPAS 868).
																				 Quando existir empresa centralizadora deve existir, no mínimo, uma empresa centralizada e viceversa. Quando existir centralização,
																				 as oito primeiras posições do CNPJ da centralizadora e da centralizada devem ser iguais. Empresa com inscrição CEI não possui centralização. */
        public string SIMPLES { get; set; } /* 1 N -(Para indicar se a empresa é ou não optante pelo SIMPLES -
																				 Lei n° 9.317, de 05/12/96 e para determinar a isenção da Contribuição Social).
																				 Campo obrigatório. Só pode ser 1 - Não Optante; 2 – Optante; 3 – Optante - faturamento anual superior a R$1.200.000,00 ;
																				 4 – Não Optante - Produtor Rural Pessoa Física (CEI e FPAS 604 ) com faturamento anual superior a R$1.200.000,00.
																				 5 – Não Optante – Empresa com Liminar para não recolhimento da Contribuição Social – Lei Complementar 110/01, de 26/06/2001.
																				 6 – Optante - faturamento anual superior a R$1.200.000,00 - Empresa com Liminar para não recolhimento da Contribuição Social – Lei Complementar 110/01, de 26/06/2001.
																				 Deve sempre ser igual a 1ou 5 para FPAS 582, 639, 663, 671, 680 e 736. Deve sempre ser igual a 1 para o FPAS 868 (empregador doméstico).
																				 Não pode ser informado para o código de recolhimento 640. Não pode ser informado para competência anterior a 12/1996.
																				 Os códigos 3, 4, 5 e 6 não podem ser informados a partir da competência 01/2007. Sempre que não informado o campo deve ficar em branco. */
        public string FPAS { get; set; } /* 3 N - (Informar o código referente à atividade econômica principal do
																				 empregador/contribuinte que identifica as contribuições ao FPAS e a outras entidades e fundos - terceiros)
																				 Campo obrigatório. Deve ser um FPAS válido. Deve ser diferente de 744 e 779, pois as GPS desses códigos serão geradas automaticamente,
																				 sempre que forem informados os respectivos fatos geradores dessas contribuições. Deve ser diferente de 620, pois a informação das categorias 15, 16, 18, 23 e 25 indica os
																				 respectivos fatos geradores dessas contribuições. Deve ser diferente de 663 e 671 a partir da competência 04/2004. Deve ser igual a 868 para empregador doméstico. */
        public string CodigoOutrasEntidades { get; set; } /* 4 N - (Informar o código de outras entidades e fundos para as quais
																				 a empresa está obrigada a contribuir). Campo obrigatório para os códigos de recolhimento 115, 130, 135, 150, 155, 211, 608 e
																				 650, Não pode ser informado para os códigos de recolhimento 145, 307, 317, 327, 337, 345, 640 e 660.
																				 Não pode ser informado para competências anteriores a 10/1998. Não pode ser informado para competências anteriores a 04/99 para o código FPAS 639.
																				 Deve estar contido na tabela de terceiros, inclusive zeros se SIMPLES for igual a 1, 4 ou 5. Deve ficar em branco quando o SIMPLES for igual a 2 , 3 ou 6.
																				 Sempre que não informado o campo deve ficar em branco. */
        public string CodigoPagamentoGPS { get; set; } /* 4 N - (Informar o código de pagamento da GPS, conforme tabela divulgada
																				 pelo INSS). Campo obrigatório para competência maior ou igual a 10/1998.
																				 Acatar apenas para os códigos de recolhimento 115, 150, 211 e 650. Não pode ser informado para os códigos de recolhimento 145,
																				 307, 327, 345, 640 e 660. Para FPAS 868 (empregador doméstico) acatar apenas os códigos GPS 1600 e 1651.
																				 Sempre que não informado o campo deve ficar em branco. */
        public string PercentualIsencaoFilantropia { get; set; } /* 5 N - (Informar o percentual de isenção conforme Lei 9.732/98)
																				 Valor deve ser composto de três inteiros e duas decimais. Só pode ser informado quando o FPAS for igual a 639.
																				 Sempre que não informado o campo deve ficar em branco. */
        public decimal SalarioFamilia { get; set; } /* 15 V - (Informar o total pago pela empresa a título de saláriofamília.
																				 O valor informado será deduzido na GPS) Opcional para os códigos de recolhimento 115 e 211. Não pode ser informado para os
																				 códigos de recolhimento 145, 307, 327, 345, 640, 650, 660 e FPAS 868 (empregador doméstico). Não pode ser informado para a
																		 competência 13. Não pode ser informado para competências anteriores a 10/1998. Sempre que não informado preencher com zeros. */
        public decimal SalarioMaternidade { get; set; } /* 15 V - (Indicar o total pago pela empresa a título de salário-maternidade no mês em referência. O valor será deduzido na GPS).
																				 Opcional para o código de recolhimento 115. Opcional para os códigos de recolhimento 150, 155 e 608, quando o CNPJ da empresa for igual ao CNPJ do tomador.
																				 Não pode ser informado para os códigos de recolhimento 130, 135, 145, 211, 307, 317, 327, 337, 345, 640, 650, 660 e para empregador doméstico (FPAS 868).
																				 Não pode ser informado para competências anteriores a 10/1998. Não pode ser informado para as competências 06/2000 a 08/2003.
																				 Não pode ser informado para licença maternidade iniciada a partir de 01.12.1999 e com benefícios requeridos até 31/08/2003.
																				 Não pode ser informado para a competência 13. Sempre que não informado preencher com zeros. */
        public decimal ContribDescEmpregadoReferenteCompetencia13 { get; set; } /* 15 V - (Informar o valor total da contribuição descontada dos segurados na competência 13).
																				Não deverá ser informado Preencher com zeros. */
        public decimal IndicadorValorNegativoPositivo { get; set; } /* 1 V - (Para indicar se o valor devido à Previdência Social - campo 26 - é(0) positivo ou (1) negativo).
																				Não deverá ser informado. Preencher com zeros. */
        public decimal ValorDevidoPrevidenciaSocialReferenteComp13 { get; set; } /* 14 V - (Informar o valor total devido à Previdência Social, na competência 13).
																				Não deverá ser informado. Preencher com zeros. */
        public string Banco { get; set; } /* 3 N - “Para débito em conta corrente. Implementação futura”
																				Campo opcional. Se informado, deve ser válido. Sempre que não informado o campo deve ficar em branco.*/
        public string Agencia { get; set; } /* 4 N - “Para débito em conta corrente. Implementação futura” Campo opcional. Se informado, deve ser válido. Sempre que não informado o campo deve ficar em branco.*/
        public string ContaCorrente { get; set; } /* 9 AN - “Para débito em conta corrente. Implementação futura” Campo opcional. Se informado, deve ser válido. Sempre que não informado o campo deve ficar em branco.
																				Zeros 45 V - Para implementação futura. Tratar dele no momento de gerar o registro.
																				Brancos 4 AN -  Preencher com brancos. Tratar dele no momento de gerar o registro.
																				Final de Linha 1 AN Deve ser uma constante “*” para marcar fim de linha. Tratar dele no momento de gerar o registro.*/

        public FolhaSefipRegistroTipo10()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponenteFolha.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("10");
            retorno += Funcoes.LFill(TipoInscricaoEmpresa == null ? "" : TipoInscricaoEmpresa, 1);
            retorno += Funcoes.LFill(InscricaoEmpresa == null ? "" : InscricaoEmpresa, 14);
            retorno += Funcoes.LFill("0", 36);
            retorno += Funcoes.LFill(NomeEmpresaRazaoSocial == null ? "" : NomeEmpresaRazaoSocial, 40);
            retorno += Funcoes.LFill(Logradouro == null ? "" : Logradouro, 50);
            retorno += Funcoes.RFill(Bairro == null ? "" : Bairro, 20);
            retorno += Funcoes.LFill(Cep == null ? "" : Cep, 8);
            retorno += Funcoes.LFill(Cidade == null ? "" : Cidade, 20);
            retorno += Funcoes.LFill(UnidadeFederacao == null ? "" : UnidadeFederacao, 2);
            retorno += Funcoes.LFill(TelefoneContato == null ? "" : TelefoneContato, 12);
            retorno += Funcoes.LFill(IndicadorAlteracaoEndereco == null ? "" : IndicadorAlteracaoEndereco, 1);
            retorno += Funcoes.LFill(CNAE == null ? "" : CNAE, 7);
            retorno += Funcoes.LFill(IndicadorAlteracaoCNAE == null ? "" : IndicadorAlteracaoCNAE, 1);
            retorno += Funcoes.LFill(AliquotaRAT == null ? "" : AliquotaRAT, 2);
            retorno += Funcoes.LFill(CodigoCentralizacao == null ? "" : CodigoCentralizacao, 1);
            retorno += Funcoes.LFill(SIMPLES == null ? "" : SIMPLES, 1);
            retorno += Funcoes.LFill(FPAS == null ? "" : FPAS, 3);
            retorno += Funcoes.LFill(CodigoOutrasEntidades == null ? "" : CodigoOutrasEntidades, 4);
            retorno += Funcoes.LFill(CodigoPagamentoGPS == null ? "" : CodigoPagamentoGPS, 4);
            retorno += Funcoes.LFill(PercentualIsencaoFilantropia == null ? "" : PercentualIsencaoFilantropia, 5);
            retorno += Funcoes.LFill(SalarioFamilia == null ? "" : SalarioFamilia.ToString(), 15);
            retorno += Funcoes.LFill(SalarioMaternidade == null ? "" : SalarioMaternidade.ToString(), 15);
            retorno += Funcoes.LFill(ContribDescEmpregadoReferenteCompetencia13 == null ? "" : ContribDescEmpregadoReferenteCompetencia13.ToString(), 15);
            retorno += Funcoes.LFill(IndicadorValorNegativoPositivo == null ? "" : IndicadorValorNegativoPositivo.ToString(), 1);
            retorno += Funcoes.LFill(ValorDevidoPrevidenciaSocialReferenteComp13 == null ? "" : ValorDevidoPrevidenciaSocialReferenteComp13.ToString(), 14);
            retorno += Funcoes.LFill(Banco == null ? "" : Banco, 3);
            retorno += Funcoes.LFill(Agencia == null ? "" : Agencia, 4);
            retorno += Funcoes.LFill(ContaCorrente == null ? "" : ContaCorrente, 9);
            retorno += Funcoes.LFill("0", 45);
            retorno += Funcoes.LFill(" ", 4);
            retorno += Funcoes.LFill("*");

            return retorno;
        }

    }
}
