using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponenteFolha
{
    public class FolhaSefipRegistroTipo30
    {
        public string TipoRegistro { get; set; } // 2 N -  Campo obrigatório. Sempre “30”.
        public string TipoInscricaoEmpresa { get; set; } // 1 N - Campo obrigatório. Só pode ser 1 (CNPJ) ou 2 (CEI).
        public string InscricaoEmpresa { get; set; } /* 14 N - Campo obrigatório. Se Tipo Inscrição = 1, então número esperado CNPJ válido.
										Se Tipo Inscrição = 2, então número esperado CEI válido. */
        public string TipoInscricaoTomadorObraConstCivil { get; set; } /* 1 N - Campo obrigatório. Só pode ser 1 (CNPJ) ou 2 (CEI). Obrigatório para os códigos de recolhimento 130, 135, 211, 150, 155, 317, 337 e 608.
														Sempre que não informado, campo deve ficar em branco. */
        public string InscricaoTomadorObraConstCivil { get; set; } /* 14 N - (Destinado à informação da inscrição da empresa tomadora de serviço nos recolhimentos de trabalhadores avulsos, prestação
													 de serviços, obra de construção civil e dirigente sindical). Campo obrigatório. Obrigatório para os códigos de recolhimento 130, 135, 150, 155, 211, 317, 337 e 608.
													 Se Tipo Inscrição = 1, então número esperado CNPJ válido. Se Tipo Inscrição = 2, então número esperado CEI válido.
													 Sempre que não informado, campo deve ficar em branco. */
        public string PISPASEPCI { get; set; } // 11 N - Campo obrigatório. O número informado deve ser válido.
        public DateTime DataAdmissao { get; set; } /* 8 D - Formato DDMMAAAA. Obrigatório para as categorias de trabalhadores 01, 03, 04, 05, 06, 07, 11, 12, 19, 20, 21 e 26.
								 Deve conter uma data válida. Não pode ser informado para as demais categorias. Deve ser menor ou igual a competência informada.
								 Deve ser maior ou igual a 22/01/1998 para a categoria de trabalhador 04. Deve ser maior ou igual a 20/12/2000 para a categoria de trabalhador 07.
								 Sempre que não informado o campo deve ficar em branco. */
        public string CategoriaTrabalhador { get; set; } // 2 N - Código deve estar na tabela categoria do trabalhador. Campo obrigatório.
        public string NomeTrabalhador { get; set; } /* 70 A - Campo obrigatório. Não pode conter número. Não pode conter caracteres especiais. Não pode haver caracteres acentuados.
									 Não é permitido mais de um espaço entre os nomes. Não é permitido três ou mais caracteres iguais consecutivos.
									 A primeira posição não pode ser branco. Pode conter apenas caracteres de A a Z. */
        public string MatriculaEmpregado { get; set; } /* 11 N - Número de matrícula atribuído pela empresa ao trabalhador, quando houver. Não pode ser informado para as categorias 06, 13, 14, 15, 16 , 17, 18, 22, 23, 24 ou 25.
										Sempre que não informado o campo deve ficar em branco. */
        public string NumeroCTPS { get; set; } /* 7 N - Obrigatório para as categorias de trabalhadores 01, 03 , 04, 06, 07 e 26. Opcional para a categoria de trabalhador 02.
									Não pode ser informado para as demais categorias. Sempre que não informado o campo deve ficar em branco. */
        public string SerieCTPS { get; set; } /* 5 N - Obrigatório para as categorias de trabalhadores 01, 03 , 04, 06, 07 e 26. Opcional para a categoria de trabalhador 02.
								Não pode ser informado para as demais categorias. Sempre que não informado o campo deve ficar em branco. */
        public DateTime DataOpcao { get; set; } /* 8 D - (Indicar a data em que o trabalhador optou pelo FGTS). Formato DDMMAAAA. Obrigatório para as
							 categorias de trabalhadores 01, 03, 04 , 05, 06 e 07 e deve conter uma data válida. Não pode ser informado para as demais categorias.
							 Deve ser maior ou igual a data de admissão e limitada a 05/10/1988 quando a data de admissão for menor que 05/10/1988, para as categorias 1 e 3.
							 Deve ser igual a data de admissão quando a mesma for maior ou igual a 05/10/1988, para as categorias 1 e 3.
							 Deve ser maior ou igual a 22/01/1998 para a categoria de trabalhador 04. Deve ser maior ou igual a 02/06/1981 para a categoria de trabalhador 05.
							 Deve ser maior ou igual a 01/03/2000 para a categoria de trabalhador 06. Deve ser maior ou igual a 20/12/2000 e igual a data de admissão para categoria de trabalhador 07.
							 Não pode ser informado para o código de recolhimento 640. Não pode ser menor que 01/01/1967. Sempre que não informado o campo deve ficar em branco. */
        public DateTime DataNascimento { get; set; } /* 8 D - Formato DDMMAAAA. Campo obrigatório para as categorias de trabalhadores 01, 02, 03, 04, 05, 06, 07, 12, 19, 20, 21 e 26
									 deve conter uma data válida. Não pode ser informado para as demais categorias. Deve ser menor que a data de admissão.
									 Deve ser maior a 01/01/1900. Sempre que não informado o campo deve ficar em branco. */
        public string CBO { get; set; } /* 5 AN - Código Brasileiro de Ocupação. Campo Obrigatório. Utilizar os quatro primeiros dígitos do grupo “Família” do novo CBO,
							 acrescentando zero a esquerda.(0 + XXXX onde XXXX é o código da família do novo CBO a qual pertence o trabalhador).
							 Deve ser igual a 05121 para empregado doméstico (categoria 06). Código “família” deve estar contido na tabela do novo CBO. */
        public decimal RemuneracaoSem13 { get; set; } /* 15 V - (Destinado à informação da remuneração paga, devida ou creditada ao trabalhador no mês, conforme base de incidência.
								 Excluir do valor da remuneração o 13º salário pago no mês). Campo obrigatório para as categorias 05, 11, 13, 14, 15, 16, 17, 18, 22, 23, 24 e 25.
								 Opcional para as categorias 01, 02, 03, 04, 06, 07, 12, 19, 20, 21 e 26. As remunerações pagas após rescisão do contrato de trabalho e
								 conforme determinação do Art. 466 da CLT, não devem vir acompanhadas das respectivas movimentações. Se informado deve ter 2 casas decimais válidas.
								 Não pode ser informado para a competência 13. Sempre que não informado preencher com zeros. */
        public decimal Remuneracao13 { get; set; } /* 15 V - (Destinado à informação da parcela de 13º salário pago no mês ao trabalhador). Não pode ser informado para a competência 13.
								 Campo obrigatório para categoria 02. Campo opcional para as categorias de trabalhadores 01, 03, 04, 06, 07, 12, 19, 20, 21 e 26.
								 As remunerações pagas após rescisão do contrato de trabalho e conforme determinação do Art. 466 da CLT, não devem vir acompanhadas
								 das respectivas movimentações. Sempre que não informado preencher com zeros. */
        public string ClasseContribuicao { get; set; } /* 2 N - (Indicar a classe de contribuição do autônomo, quando a empresa opta por contribuir sobre seu salário-base e os
										 classifica como categoria 14 ou 16. A classe deve estar compreendida em tabela fornecida pelo INSS).
										 Campo obrigatório para as categorias 14 e 16 (apenas em recolhimentos de competências anteriores a 03/2000). Não pode ser informado para as demais categorias.
										 Não pode ser informado para a competência 13. Sempre que não informado o campo deve ficar em branco. */
        public string Ocorrencia { get; set; } /* 2 N - (Destinado à informação de exposição do trabalhador a agente nocivo e/ou para indicação de multiplicidade de vínculos para
								 um mesmo trabalhador). Campo opcional para as categorias 01, 03, 04, 06, 07, 12, 19, 20 e 21.
								 Campo opcional para as categorias 05, 11, 13,15, 17, 18, 22, 23, 24 e 25 a partir da competência 04/2003.
								 Campo opcional para a categoria 02 a partir da competência 04/1999. Deve ficar em branco se trabalhador não esteve exposto a agente nocivo
								 e não possui mais de um vínculo empregatício. Para empregado doméstico (Cat 06) e diretor não empregado (Cat 05) permitido apenas branco ou 05.
								 Para as categorias 02, 22 e 23 permitido apenas branco, 01, 02, 03 e 04. Obrigatório para categoria 26, devendo ser informado 05, 06, 07 ou 08.
								 Não pode ser informado para as demais categorias. Deve ser uma ocorrência válida (ver tabela).
								 Sempre que não informado o campo deve ficar em branco. */
        public decimal ValorDescontadoSegurado { get; set; } /* 15 V - (Destinado à informação do valor da contribuição do trabalhador com mais de um vínculo empregatício;
										 ou quando tratarse de recolhimento de trabalhador avulso, dissídio coletivo ou reclamatória trabalhista, ou, ainda nos meses de afastamento e
										 retorno de licença maternidade) O valor informado será considerado como contribuição do segurado.
										 Campo opcional para as ocorrências 05, 06, 07 e 08.
										 Campo opcional para as categorias de trabalhadores igual a 01, 02, 04, 06, 07, 12, 19, 20, 21 e 26.
										 Campo opcional para as categorias de trabalhadores igual a 05, 11, 13, 15, 17, 18, 24 e 25 a partir da competência 04/2003.
										 Campo opcional para os códigos de recolhimento 130, 135 e 650.
										 Campo opcional para competência maior ou igual a 12/1999 para afastamentos por motivo de licença-maternidade
										 iniciada a partir de 01/12/1999 e com benefícios requeridos até 31/08/2003.
										 Não pode ser informado para competência anterior a outubro de 1998. Sempre que não informado preencher com zeros. */
        public decimal RemuneracaoBaseCalculoContribuicaoPrevidenciaria { get; set; } /* 15 V -  (Destinado à informação da parcela de remuneração sobre a qual incide
																 contribuição previdenciária, quando o trabalhador estiver afastado por motivo de acidente de trabalho e/ou prestação de serviço militar
																 obrigatório ou na informação de Recolhimento Complementar de FGTS). Campo obrigatório para as movimentações (registro 32) por O1, O2, R, Z2, Z3 e Z4.
																 Campo obrigatório quando o Indicativo “C” de Recolhimento Complementar de FGTS for informado (registro Tipo 32 – campo 12).
																 Campo opcional para as categorias 01, 02, 04, 05, 06, 07,11, 12, 19, 20, 21 e 26. Não pode ser informado na competência 13.
																 Não pode ser informado para competência anterior a outubro de 1998. Não pode ser informado para os códigos de recolhimento
																 145, 307, 317, 327, 337, 345, 640 e 660. Sempre que não informado preencher com zeros. */
        public decimal BaseCalculo13SalarioPrevidenciaSocialReferenteCompetenciaMovimento { get; set; } /*  15 V -  (Na competência em que ocorreu o afastamento definitivo –
																					 informar o valor total do 13º pago no ano ao trabalhador. Na competência 12 – Indicar eventuais diferenças de gratificação
																					 natalina de empregados que recebem remuneração variável – Art. 216, Parágrafo 25, Decreto 3.265 de 29.11.1999) Na competência 13,
																					 para a geração da GPS, indicar o valor total do 13º salário pago no ano ao trabalhador). Obrigatório para a competência 13.
																					 Obrigatório no mês de rescisão para quem trabalhou mais de 15 dias no ano e possui código de
																					 movimentação por motivo rescisão (exceto rescisão com justa causa), aposentadoria com quebra de vínculo ou falecimento.
																					 Obrigatório para os códigos de recolhimento 130 e 135. Obrigatório para os códigos de recolhimento 608 quando houver trabalhador
																					 da categoria 02 no arquivo. Opcional para os códigos de recolhimento 650.
																					 Só pode ser informado para as categorias 01, 02, 04 ,06 , 07, 12, 19, 20, 21 e 26. Campo opcional para as categorias 01, 04 , 06 , 07, 12, 19,
																					 20, 21 e 26 na competência 12. Sempre que não informado preencher com zeros. */
        public decimal BaseCalculo13SalarioPrevidenciaReferenteGPSCompetencia13 { get; set; } /* 15 V -  Deve ser utilizado apenas na competência 12, informando o valor
																			 da base de cálculo do 13º dos empregados que recebem remuneração variável, em relação a remuneração apurada até 20/12 sobre
																			 a qual já houve recolhimento em GPS). Campo opcional para a competência 12. Não pode ser informado nas demais competências.
																			 Campo opcional para as categorias 01, 04 , 06, 07, 12, 19, 20, 21 e 26. Se informado o campo 22 (registro 30) deve ser diferente de zeros.
																			 Sempre que não informado preencher com zeros. */
        // Brancos Campo obrigatório. Preencher com brancos.
        // Final de Linha. Campo obrigatório. Deve ser uma constante “*” para marcar fim de linha.

        public FolhaSefipRegistroTipo30()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponenteFolha.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("30");
            retorno += Funcoes.LFill(TipoInscricaoEmpresa == null ? "" : TipoInscricaoEmpresa, 1);
            retorno += Funcoes.LFill(InscricaoEmpresa == null ? "" : InscricaoEmpresa, 14);
            retorno += Funcoes.LFill(TipoInscricaoTomadorObraConstCivil == null ? "" : TipoInscricaoTomadorObraConstCivil,1);
            retorno += Funcoes.LFill(InscricaoTomadorObraConstCivil == null ? "" : InscricaoTomadorObraConstCivil, 14);
            retorno += Funcoes.RFill(PISPASEPCI == null ? "" : PISPASEPCI, 11);
            retorno += Funcoes.LFill(DataAdmissao == null ? "" : DataAdmissao.ToString("ddMMyyyy"), 8);
            retorno += Funcoes.LFill(CategoriaTrabalhador == null ? "" : CategoriaTrabalhador, 2);
            retorno += Funcoes.LFill(NomeTrabalhador == null ? "" : NomeTrabalhador, 70);
            retorno += Funcoes.LFill(MatriculaEmpregado == null ? "" : MatriculaEmpregado, 11);
            retorno += Funcoes.LFill(NumeroCTPS == null ? "" : NumeroCTPS, 7);
            retorno += Funcoes.LFill(SerieCTPS == null ? "" : SerieCTPS, 5);
            retorno += Funcoes.LFill(DataOpcao == null ? "" : DataOpcao.ToString("ddMMyyyy"), 8);
            retorno += Funcoes.LFill(DataNascimento == null ? "" : DataNascimento.ToString("ddMMyyyy"), 8);
            retorno += Funcoes.LFill(CBO == null ? "" : CBO, 5);
            retorno += Funcoes.LFill(RemuneracaoSem13 == null ? "" : RemuneracaoSem13.ToString(), 15);
            retorno += Funcoes.LFill(Remuneracao13 == null ? "" : Remuneracao13.ToString(), 15);
            retorno += Funcoes.LFill(ClasseContribuicao == null ? "" : ClasseContribuicao, 2);
            retorno += Funcoes.LFill(Ocorrencia == null ? "" : Ocorrencia, 2);
            retorno += Funcoes.LFill(ValorDescontadoSegurado == null ? "" : ValorDescontadoSegurado.ToString(), 15);
            retorno += Funcoes.LFill(RemuneracaoBaseCalculoContribuicaoPrevidenciaria == null ? "" : RemuneracaoBaseCalculoContribuicaoPrevidenciaria.ToString(), 15);
            retorno += Funcoes.LFill(BaseCalculo13SalarioPrevidenciaSocialReferenteCompetenciaMovimento == null ? "" : BaseCalculo13SalarioPrevidenciaSocialReferenteCompetenciaMovimento.ToString(), 15);
            retorno += Funcoes.LFill(BaseCalculo13SalarioPrevidenciaReferenteGPSCompetencia13 == null ? "" : BaseCalculo13SalarioPrevidenciaReferenteGPSCompetencia13.ToString(), 15);
            retorno += Funcoes.LFill(" ", 98);
            retorno += Funcoes.LFill("*");

            return retorno;
        }

    }
}
