using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PafEcf.View
{
    public partial class DataModule : UserControl
    {
        public static ACBrFramework.ECF.ACBrECF ACBrECF { get; set; }
        public static ACBrFramework.PAF.ACBrPAF ACBrPAF { get; set; }
        public static ACBrFramework.Sped.ACBrSpedFiscal ACBrSpedFiscal { get; set; }
        public static ACBrFramework.BAL.ACBrBAL ACBrBAL { get; set; }
        public static ACBrFramework.Sintegra.ACBrSintegra ACBrSintegra { get; set; }
        public static ACBrFramework.AAC.ACBrAAC ACBrAAC { get; set; }
        public static ACBrFramework.EAD.ACBrEAD ACBrEAD { get; set; }

        public DataModule()
        {
            InitializeComponent();
            //
            ACBrECF = this.aCBrECF;
            ACBrPAF = this.aCBrPAF;
            ACBrSpedFiscal = this.aCBrSpedFiscal;
            ACBrBAL = this.aCBrBAL;
            ACBrSintegra = this.aCBrSintegra;
            ACBrAAC = this.aCBrAAC;
            ACBrEAD = this.aCBrEAD;
        }
    }
}
