using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConfiguraPAFECF.View
{
    public partial class FPropriedades : Form
    {
        public static PropertyGrid GridPropriedades;

        public FPropriedades()
        {
            InitializeComponent();
            //
            GridPropriedades = this.PropertyGrid;
        }

        private void FPropriedades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
