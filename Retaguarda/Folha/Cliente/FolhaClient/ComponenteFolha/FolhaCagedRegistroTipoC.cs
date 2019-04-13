using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponenteFolha
{
    public class FolhaCagedRegistroTipoC
    {
        public string TipoRegistro { get; set; } // 1 A. Define o registro a ser informado. Obrigatoriamente o conteúdo é X.
        public string TipoIdentificador { get; set; } // 1 N. Define o tipo de identificador do estabelecimento a informar. 1. CNPJ - 2. CEI
        public string NumeroIdentificadorDoEstabelecimento { get; set; } /* 14 N. Número identificador do estabelecimento. Não havendo inscrição
													 do estabelecimento no Cadastro Nacional de Pessoa Jurídica (CNPJ), informar o número de registro no CEI (Código Específico do INSS).
													 O número do CEI tem 12 posições, preencher este campo com 00 zeros à esquerda.*/
        public string Sequencia { get; set; } // 5 N. Número seqüencial no arquivo.
        public string PisPasep { get; set; }  //{11 N. Número do PIS/PASEP do empregado movimentado. Informar sem máscara (/.\-,).}
        public string Sexo { get; set; } //{ 1  N. Define o sexo do empregado. 1 - Masculino 2 - Feminino.}
        public DateTime Nascimento { get; set; } // 8 N. Dia, mês e ano de nascimento do empregado. Informar a data do nascimento sem máscara (/.\-,).
        public string GrauInstrucao { get; set; } /* 2 N. Define o grau de instrução do empregado.
													 1. Analfabeto inclusive o que, embora tenha recebido instrução, não se alfabetizou.
													 2. Até o 5º ano incompleto do Ensino Fundamental (antigo 1º grau ou primário) que se tenha alfabetizado sem ter freqüentado escola
													 regular.
													 3. 5º ano completo do Ensino Fundamental (antigo 1º grau ou primário).
													 4. Do 6º ao 9º ano de Ensino Fundamental (antigo 1º grau ou ginásio).
													 5. Ensino Fundamental completo (antigo 1º grau ou primário e ginasial).
													 6. Ensino Médio incompleto (antigo 2º grau, secundário ou colegial).
													 7. Ensino Médio completo (antigo 2º grau, secundário ou colegial).
													 8. Educação Superior incompleta.
													 9. Educação Superior completa.
													 10.Mestrado
													 11.Doutorado.*/
        // FILLER, caracter, 4 posições. Deixar em branco. Obrigatório. Tratar quando gerar o arquivo.
        public string SalarioMensal { get; set; } /* 8 N.Informar o salário recebido, ou a receber. Informar com centavos sem
														pontos e sem vírgulas. Ex R$ 134,60 informar 13460.*/
        public string HorasTrabalhadas { get; set; } // 2 N. Informar a quantidade de horas trabalhadas por semana (de 1 até 44 horas).
        public DateTime Admissao { get; set; } // 8 N. Dia, mês e ano de admissão do empregado. Informar a data de admissão sem máscara (/.\-,).
        public string TipoMovimento { get; set; } /*  2 N.Define o tipo de movimento.
														 ADMISSÃO
														   10 - Primeiro emprego
														   20 - Reemprego
														   25 - Contrato por prazo determinado
														   35 - Reintegração
														   70 - Transferência de entrada
														 DESLIGAMENTO
														   31 - Dispensa sem justa causa
														   32 - Dispensa por justa causa
														   40 - A pedido (espontâneo)
														   43 - Término de contrato por prazo determinado
														   45 - Término de contrato
														   50 - Aposentado
														   60 - Morte
														   80 - Transferência de saída.*/
        public string DiaDeDesligamento { get; set; } //{ 2 N. Se o tipo de movimento for desligamento, informar o dia da saída do empregado se for admissão deixar em branco.}
        public string NomeDoEmpregado { get; set; } // 40 A. Informar o nome do empregado movimentado.
        public string NumeroCarteiraTrabalho { get; set; } // 8 N. Informar o número da carteira de trabalho e previdência social do empregado.
        public string SerieCarteiraTrabalho { get; set; } // 4 N. Informar o número de série da carteira de trabalho e previdência social do empregado.
        public string RacaCor { get; set; } /* 1 N. Informe a raça ou cor do empregado, utilizando o código:
														 1 - Indígena
														 2 - Branca
														 4 - Preta
														 6 - Amarela
														 8 - Parda
														 9 - Não informado*/
        public string PessaoComDeficiencia { get; set; } /* 1 N. Informe se o empregado é portador de deficiência, utilizando:
														 1. Para indicar SIM
														 2. Para indicar NÃO.*/
        public string CBO2000 { get; set; } /* 6 N. Informe o código de ocupação conforme a Classificação Brasileira de
														Ocupação - CBO. Informar sem máscara (/.\-,). Veja o site da CBO.*/
        public string Aprendiz { get; set; } // 1 N. Informar se o empregado é Aprendiz ou não. 1. SIM 2. NÃO.
        public string UFCarteiraDeTrabalho { get; set; } /* 2 A. Informar a Unidade de Federação da carteira de trabalho e previdência
														 social do empregado. OBS Quando se tratar de carteira de trabalho, novo modelo, para o campo série deve ser utilizado uma
														 posição do campo uf, ficando obrigatoriamente a última em branco.*/
        public string TipoDeficienciaBeneficiarioReabilitado { get; set; } /*1 A. Informe o tipo de deficiência do empregado, conforme as categorias abaixo,
														 ou se o mesmo é beneficiário reabilitado da Previdência Social.
														 1. Física
														 2. Auditiva
														 3. Visual
														 4. Mental
														 5. Múltipla
														 6. Reabilitado.*/
        public string Cpf { get; set; } //11 N, obrigatório. Código Pessoa Física da Receita Federal.
        public string Cep { get; set; } /*8  N. Informar o Código de Endereçamento Postal do estabelecimento conforme a tabela da
														Empresa de Correios e Telégrafos-ECT. Informar sem  máscara (/.\-,).*/
        // Filler2                         { get; set; } // 81 A. Deixar em branco. Tratar na geração do arquivo. Obrigatorio

        public FolhaCagedRegistroTipoC()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponenteFolha.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("C");
            retorno += Funcoes.LFill(TipoIdentificador == null ? "" : TipoIdentificador, 1);
            retorno += Funcoes.LFill(NumeroIdentificadorDoEstabelecimento == null ? "" : NumeroIdentificadorDoEstabelecimento, 14);
            retorno += Funcoes.LFill(ComponenteFolha.NSR, 5);
            retorno += Funcoes.LFill(PisPasep == null ? "" : PisPasep, 11);
            retorno += Funcoes.LFill(Sexo == null ? "" : Sexo, 1);
            retorno += Funcoes.LFill(Nascimento == null ? "" : Nascimento.ToString("ddMMyyyy"), 8);
            retorno += Funcoes.RFill(GrauInstrucao == null ? "" : GrauInstrucao, 2);
            retorno += Funcoes.LFill(SalarioMensal == null ? "" : SalarioMensal, 8);
            retorno += Funcoes.LFill(HorasTrabalhadas == null ? "" : HorasTrabalhadas, 2);
            retorno += Funcoes.LFill(Admissao == null ? "" : Admissao.ToString("ddMMyyyy"), 8);
            retorno += Funcoes.LFill(TipoMovimento == null ? "" : TipoMovimento, 2);
            retorno += Funcoes.LFill(DiaDeDesligamento == null ? "" : DiaDeDesligamento, 2);
            retorno += Funcoes.LFill(NomeDoEmpregado == null ? "" : NomeDoEmpregado, 40);
            retorno += Funcoes.LFill(NumeroCarteiraTrabalho == null ? "" : NumeroCarteiraTrabalho, 8);
            retorno += Funcoes.LFill(SerieCarteiraTrabalho == null ? "" : SerieCarteiraTrabalho, 4);
            retorno += Funcoes.LFill(RacaCor == null ? "" : RacaCor, 1);
            retorno += Funcoes.LFill(PessaoComDeficiencia == null ? "" : PessaoComDeficiencia, 1);
            retorno += Funcoes.LFill(CBO2000 == null ? "" : CBO2000, 6);
            retorno += Funcoes.LFill(Aprendiz == null ? "" : Aprendiz, 1);
            retorno += Funcoes.LFill(UFCarteiraDeTrabalho == null ? "" : UFCarteiraDeTrabalho, 8);
            retorno += Funcoes.LFill(TipoDeficienciaBeneficiarioReabilitado == null ? "" : TipoDeficienciaBeneficiarioReabilitado, 1);
            retorno += Funcoes.LFill(Cpf == null ? "" : Cpf, 11);
            retorno += Funcoes.LFill(Cep == null ? "" : Cep, 8);

            return retorno;
        }

    }
}
