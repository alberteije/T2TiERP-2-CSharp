using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    public class CodigoTarifas : AbstractCodigoTarifas, ICodigoTarifas
    {

        #region Variaveis

        private ICodigoTarifas _ICodigoTarifas;

        #endregion

        #region Propriedades da interface

        public override IBanco Banco
        {
            get { return _ICodigoTarifas.Banco; }
        }

        public override int Codigo
        {
            get { return _ICodigoTarifas.Codigo; }
        }

        public override string Descricao
        {
            get { return _ICodigoTarifas.Descricao; }
        }

        #endregion

    }
}
