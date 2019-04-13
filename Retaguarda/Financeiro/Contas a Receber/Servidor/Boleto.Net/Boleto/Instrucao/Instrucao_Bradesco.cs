using System;
using System.Collections;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumInstrucoes_Bradesco
    {
        Protestar = 9,
        NaoProtestar = 10,
        ProtestoFinsFalimentares = 42,
        ProtestarAposNDiasCorridos = 81,
        ProtestarAposNDiasUteis = 82,
        NaoReceberAposNDias = 91,
        DevolverAposNDias = 92,        
    }

    #endregion 

    public class Instrucao_Bradesco : AbstractInstrucao, IInstrucao
    {

        #region Construtores 

		public Instrucao_Bradesco()
		{
			try
			{
                this.Banco = new Banco(237);
			}
			catch (Exception ex)
			{
                throw new Exception("Erro ao carregar objeto", ex);
			}
		}

        public Instrucao_Bradesco(int codigo)
        {
            this.carregar(codigo, 0);
        }

        public Instrucao_Bradesco(int codigo, int nrDias)
        {
            this.carregar(codigo, nrDias);
        }
        #endregion Construtores

        #region Metodos Privados

        private void carregar(int idInstrucao, int nrDias)
        {
            try
            {
                this.Banco = new Banco_Bradesco();
                this.Valida();

                switch ((EnumInstrucoes_Bradesco)idInstrucao)
                {

                    case EnumInstrucoes_Bradesco.Protestar:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.Protestar;
                        this.Descricao = "Protestar";
                        break;
                    case EnumInstrucoes_Bradesco.NaoProtestar:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.NaoProtestar;
                        this.Descricao = "Não protestar";
                        break;
                    case EnumInstrucoes_Bradesco.ProtestoFinsFalimentares:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.ProtestoFinsFalimentares;
                        this.Descricao = "Protesto para fins falimentares";
                        break;
                    case EnumInstrucoes_Bradesco.ProtestarAposNDiasCorridos:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.ProtestarAposNDiasCorridos;
                        this.Descricao = "Protestar após N dias corridos do vencimento";
                        break;
                    case EnumInstrucoes_Bradesco.ProtestarAposNDiasUteis:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.ProtestarAposNDiasUteis;
                        this.Descricao = "Protestar após N dias úteis do vencimento";
                        break;
                    case EnumInstrucoes_Bradesco.NaoReceberAposNDias:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.NaoReceberAposNDias;
                        this.Descricao = "Não receber após N dias do vencimento";
                        break;
                    case EnumInstrucoes_Bradesco.DevolverAposNDias:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.DevolverAposNDias;
                        this.Descricao = "Devolver após N dias do vencimento";
                        break;
                    default:
                        this.Codigo = 0;
                        this.Descricao = " (Selecione) ";
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
