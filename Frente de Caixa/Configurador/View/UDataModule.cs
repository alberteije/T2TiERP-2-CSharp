using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConfiguraPAFECF.View
{
    public partial class FDataModule : UserControl
    {
        public static ACBrFramework.ECF.ACBrECF ACBrECF { get; set; }

        public FDataModule()
        {
            InitializeComponent();
            //
            ACBrECF = this.acBrECF;
        }
    }
}
