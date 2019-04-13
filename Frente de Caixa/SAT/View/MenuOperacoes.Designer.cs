namespace NFCe.View
{
    partial class MenuOperacoes
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
            this.listaMenuOperacoes = new System.Windows.Forms.ListBox();
            this.labelMenuOperacoes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listaMenuOperacoes
            // 
            this.listaMenuOperacoes.BackColor = System.Drawing.Color.White;
            this.listaMenuOperacoes.Font = new System.Drawing.Font("Tahoma", 13F);
            this.listaMenuOperacoes.ForeColor = System.Drawing.Color.Maroon;
            this.listaMenuOperacoes.ItemHeight = 21;
            this.listaMenuOperacoes.Items.AddRange(new object[] {
            "Consultar SAT",
            "Bloquear SAT",
            "Desbloquear SAT"});
            this.listaMenuOperacoes.Location = new System.Drawing.Point(7, 38);
            this.listaMenuOperacoes.Name = "listaMenuOperacoes";
            this.listaMenuOperacoes.Size = new System.Drawing.Size(199, 151);
            this.listaMenuOperacoes.TabIndex = 17;
            this.listaMenuOperacoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listaMenuOperacoes_KeyDown);
            // 
            // labelMenuOperacoes
            // 
            this.labelMenuOperacoes.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuOperacoes.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.labelMenuOperacoes.ForeColor = System.Drawing.Color.White;
            this.labelMenuOperacoes.Location = new System.Drawing.Point(9, 6);
            this.labelMenuOperacoes.Name = "labelMenuOperacoes";
            this.labelMenuOperacoes.Size = new System.Drawing.Size(195, 20);
            this.labelMenuOperacoes.TabIndex = 18;
            this.labelMenuOperacoes.Text = "Menu Operações";
            this.labelMenuOperacoes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuOperacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NFCe.Properties.Resources.Menu1;
            this.ClientSize = new System.Drawing.Size(213, 200);
            this.Controls.Add(this.labelMenuOperacoes);
            this.Controls.Add(this.listaMenuOperacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MenuOperacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menu Operações";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FMenuOperacoes_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMenuOperacoes_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox listaMenuOperacoes;
        internal System.Windows.Forms.Label labelMenuOperacoes;
    }
}