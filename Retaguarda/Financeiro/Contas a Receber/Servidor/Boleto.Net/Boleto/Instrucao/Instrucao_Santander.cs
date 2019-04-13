using System;
using System.Collections;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumInstrucoes_Santander
    {
    }

    #endregion

    public class Instrucao_Santander : AbstractInstrucao, IInstrucao
    {

        #region Construtores
        public Instrucao_Santander()
        {
            try
            {
                this.Banco = new Banco(33);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }
        public Instrucao_Santander(Banco Banco, int Codigo)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public Instrucao_Santander(int codigo)
        {
            this.carregar(codigo, 0);
        }

        public Instrucao_Santander(EnumInstrucoes_Santander codigo)
        {
            this.carregar((int)codigo, 0);
        }

        public Instrucao_Santander(int codigo, int nrDias)
        {
            this.carregar(codigo, nrDias);
        }
        #endregion

        #region Metodos Privados

        private void carregar(int idInstrucao, int nrDias)
        {
            try
            {
                this.Banco = new Banco_Santander();
                this.Valida();

                switch ((EnumInstrucoes_Santander)idInstrucao)
                {
                    //case EnumInstrucoes_Bradesco.Protestar:
                    //    this.Codigo = (int)EnumInstrucoes_Bradesco.Protestar;
                    //    this.Descricao = "Protestar";
                    //    break;
                    default:
                        this.Codigo = 0;
                        this.Descricao = "";
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
