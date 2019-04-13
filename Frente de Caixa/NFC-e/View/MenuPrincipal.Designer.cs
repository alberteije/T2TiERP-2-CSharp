namespace NFCe.View
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaMenuPrincipal = new System.Windows.Forms.ListBox();
            this.labelMenuPrincipal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listaMenuPrincipal
            // 
            this.listaMenuPrincipal.BackColor = System.Drawing.Color.White;
            this.listaMenuPrincipal.Font = new System.Drawing.Font("Tahoma", 13F);
            this.listaMenuPrincipal.ForeColor = System.Drawing.Color.Maroon;
            this.listaMenuPrincipal.ItemHeight = 21;
            this.listaMenuPrincipal.Items.AddRange(new object[] {
            "Supervisor",
            "Gerente",
            "Saída Temporária"});
            this.listaMenuPrincipal.Location = new System.Drawing.Point(8, 36);
            this.listaMenuPrincipal.Name = "listaMenuPrincipal";
            this.listaMenuPrincipal.Size = new System.Drawing.Size(199, 151);
            this.listaMenuPrincipal.TabIndex = 14;
            this.listaMenuPrincipal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listaMenuPrincipal_KeyDown);
            // 
            // labelMenuPrincipal
            // 
            this.labelMenuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuPrincipal.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.labelMenuPrincipal.ForeColor = System.Drawing.Color.White;
            this.labelMenuPrincipal.Location = new System.Drawing.Point(7, 6);
            this.labelMenuPrincipal.Name = "labelMenuPrincipal";
            this.labelMenuPrincipal.Size = new System.Drawing.Size(195, 20);
            this.labelMenuPrincipal.TabIndex = 15;
            this.labelMenuPrincipal.Text = "Menu Principal";
            this.labelMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NFCe.Properties.Resources.Menu1;
            this.ClientSize = new System.Drawing.Size(213, 200);
            this.Controls.Add(this.labelMenuPrincipal);
            this.Controls.Add(this.listaMenuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menu Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FMenuPrincipal_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMenuPrincipal_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox listaMenuPrincipal;
        internal System.Windows.Forms.Label labelMenuPrincipal;
    }
}