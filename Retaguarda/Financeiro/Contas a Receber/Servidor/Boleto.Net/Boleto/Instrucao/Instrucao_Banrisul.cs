using System;
using System.Collections;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumInstrucoes_Banrisul
    {
        Protestar = 9,                      // Emite aviso ao sacado após N dias do vencto, e envia ao cartório após 5 dias úteis
        NaoProtestar = 10,                  // Inibe protesto, quando houver instrução permanente na conta corrente
        ImportanciaporDiaDesconto = 30,
        ProtestoFinsFalimentares = 42,
        ProtestarAposNDiasCorridos = 81,
        ProtestarAposNDiasUteis = 82,
        NaoReceberAposNDias = 91,
        DevolverAposNDias = 92,
        JurosdeMora = 998,
        DescontoporDia = 999,
    }

    #endregion 

    public class Instrucao_Banrisul: AbstractInstrucao, IInstrucao
    {

        #region Construtores 

		public Instrucao_Banrisul()
		{
			try
			{
                this.Banco = new Banco(41);
			}
			catch (Exception ex)
			{
                throw new Exception("Erro ao carregar objeto", ex);
			}
		}

        public Instrucao_Banrisul(int codigo)
        {
            this.carregar(codigo, 0);
        }

        public Instrucao_Banrisul(int codigo, int nrDias)
        {
            this.carregar(codigo, nrDias);
        }

		#endregion 

        #region Metodos Privados

        private void carregar(int idInstrucao, int nrDias)
        {
            try
            {
                this.Banco = new Banco_Banrisul();
                this.Valida();

                switch ((EnumInstrucoes_Banrisul)idInstrucao)
                {
                    case EnumInstrucoes_Banrisul.Protestar:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.Protestar;
                        this.Descricao = "Protestar após " + nrDias + " dias úteis.";
                        break;
                    case EnumInstrucoes_Banrisul.NaoProtestar:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.NaoProtestar;
                        this.Descricao = "Não protestar";
                        break;
                    case EnumInstrucoes_Banrisul.ImportanciaporDiaDesconto:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.ImportanciaporDiaDesconto;
                        this.Descricao = "Importância por dia de desconto.";
                        break;
                    case EnumInstrucoes_Banrisul.ProtestoFinsFalimentares:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.ProtestoFinsFalimentares;
                        this.Descricao = "Protesto para fins falimentares";
                        break;
                    case EnumInstrucoes_Banrisul.ProtestarAposNDiasCorridos:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.ProtestarAposNDiasCorridos;
                        this.Descricao = "Protestar após " + nrDias + " dias corridos do vencimento";
                        break;
                    case EnumInstrucoes_Banrisul.ProtestarAposNDiasUteis:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.ProtestarAposNDiasUteis;
                        this.Descricao = "Protestar após " + nrDias + " dias úteis do vencimento";
                        break;
                    case EnumInstrucoes_Banrisul.NaoReceberAposNDias:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.NaoReceberAposNDias;
                        this.Descricao = "Não receber após " + nrDias + " dias do vencimento";
                        break;
                    case EnumInstrucoes_Banrisul.DevolverAposNDias:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.DevolverAposNDias;
                        this.Descricao = "Devolver após " + nrDias + " dias do vencimento";
                        break;
                    case EnumInstrucoes_Banrisul.JurosdeMora:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.JurosdeMora;
                        this.Descricao = "Após vencimento cobrar R$ "; // por dia de atraso
                        break;
                    case EnumInstrucoes_Banrisul.DescontoporDia:
                        this.Codigo = (int)EnumInstrucoes_Banrisul.DescontoporDia;
                        this.Descricao = "Conceder desconto de R$ "; // por dia de antecipação
                        break;
                    default:
                        this.Codigo = 0;
                        this.Descricao = "( Selecione )";
                        break;
                }

                this.QuantidadeDias = nrDias;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public override void Valida()
        {
            //base.Valida();
        }

        #endregion

    }
}
