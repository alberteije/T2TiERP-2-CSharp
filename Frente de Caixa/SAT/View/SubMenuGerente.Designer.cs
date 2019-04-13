namespace NFCe.View
{
    partial class FSubMenuGerente
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
            this.listaGerente = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listaGerente
            // 
            this.listaGerente.BackColor = System.Drawing.Color.White;
            this.listaGerente.Font = new System.Drawing.Font("Tahoma", 13F);
            this.listaGerente.ForeColor = System.Drawing.Color.Maroon;
            this.listaGerente.ItemHeight = 21;
            this.listaGerente.Items.AddRange(new object[] {
            "Iniciar Movimento",
            "Encerrar Movimento",
            "",
            "Suprimento",
            "Sangria"});
            this.listaGerente.Location = new System.Drawing.Point(8, 27);
            this.listaGerente.Name = "listaGerente";
            this.listaGerente.Size = new System.Drawing.Size(450, 172);
            this.listaGerente.TabIndex = 20;
            this.listaGerente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listaGerente_KeyDown);
            // 
            // FSubMenuGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NFCe.Properties.Resources.SubMenu;
            this.ClientSize = new System.Drawing.Size(467, 212);
            this.Controls.Add(this.listaGerente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FSubMenuGerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SubMenu Gerente";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox listaGerente;
    }
}