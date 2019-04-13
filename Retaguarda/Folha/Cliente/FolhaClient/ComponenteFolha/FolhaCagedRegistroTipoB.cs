using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponenteFolha
{
    public class FolhaCagedRegistroTipoB
    {
        public string TipoRegistro { get; set; } // 1 A. Define o registro a ser informado. Obrigatoriamente o conteúdo é B.
        public string TipoIdentificador { get; set; } // 1 N. Define o tipo de identificador do estabelecimento a informar. 1. CNPJ - 2. CEI
        public string NumeroIdentificadorDoEstabelecimento { get; set; } /* 14 N. Número identificador do estabelecimento. Não havendo inscrição
														do estabelecimento no Cadastro Nacional de Pessoa Jurídica (CNPJ), informar o número de registro no CEI (Código Específico do INSS).
														O número do CEI tem 12 posições, preencher este campo com 00 zeros à esquerda. */
        public string Sequencia { get; set; } // 5 N. Número seqüencial no arquivo.
        public string PrimeiraDeclaracao { get; set; } /*  1 N. Define se é ou não a primeira declaração do estabelecimento ao Cadastro
														Geral de Empregados e Desempregados-CAGED-Lei nº 4.923/65. 1. primeira declaração 2. já informou ao CAGED anteriormente.*/
        public string Alteracao { get; set; }  /* 1 N. Define se os dados cadastrais informados irão ou não atualizar o Cadastro de
														Autorizados do CAGED Informatizado.
														 1. Nada a atualizar
														 2. Alterar dados cadastrais do estabelecimento (Razão Social, Endereço, CEP, Bairro, UF, ou Atividade Econômica).
														 3. Encerramento de Atividades (Fechamento do estabelecimento);*/
        public string Cep { get; set; } /* 8  N. Informar o Código de Endereçamento Postal do estabelecimento conforme a tabela da
														Empresa de Correios e Telégrafos-ECT. Informar sem  máscara (/.\-,).*/
        // FFiller1, 5 A. Deixar em branco. Tratar na geração do arquivo. Obrigatorio
        public string NomeRazaoSocialDoEstabelecimento { get; set; } // 40 A.Nome/Razão Social do estabelecimento.
        public string Endereco { get; set; } // 40 A.Informar o Endereço do estabelecimento / autorizado (Rua, Av, Trav, Pç) com número e complemento.
        public string Bairro { get; set; } // 20 A.Informar o bairro correspondente.
        public string UF { get; set; } // 2 A. Informar a Unidade de Federação.
        public string TotalDeEmpregadosExistentesNoPrimeiroDia { get; set; } // 5 N. Total de empregados existentes na empresa no início do primeiro dia do mês de referência (competência).
        public string PorteDoEstabelecimento { get; set; } /*  1 N.Informe se o estabelecimento se enquadra como microempresa, empresa de pequeno porte,
														 empresa/órgão não classificados ou microempreendedor individual, de acordo com a lei Complementar nº . 123, de 14 de dezembro de 2006,
														 alterada pela lei Complementar nº. 128, de 19 de dezembro de 2008, utilizando:
														 1. Microempresa para a pessoa jurídica, ou a ela equiparada, que auferir, em cada ano-calendário, receita bruta igual ou inferior a
															R$240.000,00 (duzentos e quarenta mil reais).
														 2. Empresa de Pequeno Porte para a pessoa jurídica, ou a ela equiparada, que auferir, em cada ano-calendário, receita bruta
															superior a R$240.000,00 (duzentos e quarenta mil reais) e igual ou inferior a R$ 2.400.000,00 (dois milhões e quatrocentos mil
															reais).
														 3. Empresa/Órgão não classificados este campo só deve ser selecionado se o estabelecimento não se enquadrar como microempreendedor
														   individual, microempresa ou empresa de pequeno porte.
														 4. Microempreendedor Individual para o empresário individual que tenha auferido receita bruta, no ano-calendário anterior, de até
															R$36.000,00 (trinta e seis mil reais).*/
        public string Cnae2ComSubClasse { get; set; } /* 7 N. Informar os primeiros 7algarísmos do CNAE 2.0 conforme exemplo:
													 01 - Divisão
													 011 - Grupo
													 01113 - Classe
													 01113xx - Subclasse.*/
        public string DDD { get; set; } // 4 N. Informar DDD do telefone para contato para contato com o Ministério do Trabalho e Emprego.
        public string Telefone { get; set; } // 8 N. Informar o número do telefone para contato com o responsável pelas informações contidas no arquivo CAGED.
        public string Email { get; set; } /* 50 A. Endereço eletrônico do estabelecimento ou do responsável, utilizado para
														eventuais contatos, todos os caracteres serão transformados em minúsculos.*/
        // Filler2                         { get; set; } // 27 A. Deixar em branco. Tratar na geração do arquivo. Obrigatorio

        public FolhaCagedRegistroTipoB()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponenteFolha.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("B");
            retorno += Funcoes.LFill(TipoIdentificador == null ? "" : TipoIdentificador, 1);
            retorno += Funcoes.LFill(NumeroIdentificadorDoEstabelecimento == null ? "" : NumeroIdentificadorDoEstabelecimento, 14);
            retorno += Funcoes.LFill(ComponenteFolha.NSR, 5);
            retorno += Funcoes.LFill(PrimeiraDeclaracao == null ? "" : PrimeiraDeclaracao, 1);
            retorno += Funcoes.LFill(Alteracao == null ? "" : Alteracao, 1);
            retorno += Funcoes.LFill(Cep == null ? "" : Cep, 8);
            retorno += Funcoes.LFill(NomeRazaoSocialDoEstabelecimento == null ? "" : NomeRazaoSocialDoEstabelecimento, 40);
            retorno += Funcoes.LFill(Endereco == null ? "" : Endereco, 40);
            retorno += Funcoes.LFill(Bairro == null ? "" : Bairro, 20);
            retorno += Funcoes.LFill(UF == null ? "" : UF, 2);
            retorno += Funcoes.LFill(TotalDeEmpregadosExistentesNoPrimeiroDia == null ? "" : TotalDeEmpregadosExistentesNoPrimeiroDia, 5);
            retorno += Funcoes.LFill(PorteDoEstabelecimento == null ? "" : PorteDoEstabelecimento, 1);
            retorno += Funcoes.LFill(Cnae2ComSubClasse == null ? "" : Cnae2ComSubClasse, 7);
            retorno += Funcoes.LFill(DDD == null ? "" : DDD, 4);
            retorno += Funcoes.LFill(Telefone == null ? "" : Telefone, 8);
            retorno += Funcoes.LFill(Email == null ? "" : Email, 50);

            return retorno;
        }

    }
}
