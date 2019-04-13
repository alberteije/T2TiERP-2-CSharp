namespace NFCe.View
{
    partial class SubMenuSupervisor
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
            this.listaSupervisor = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listaSupervisor
            // 
            this.listaSupervisor.BackColor = System.Drawing.Color.White;
            this.listaSupervisor.Font = new System.Drawing.Font("Tahoma", 13F);
            this.listaSupervisor.ForeColor = System.Drawing.Color.Maroon;
            this.listaSupervisor.ItemHeight = 21;
            this.listaSupervisor.Items.AddRange(new object[] {
            "Iniciar Movimento",
            "Encerrar Movimento",
            "",
            "Suprimento",
            "Sangria"});
            this.listaSupervisor.Location = new System.Drawing.Point(8, 27);
            this.listaSupervisor.Name = "listaSupervisor";
            this.listaSupervisor.Size = new System.Drawing.Size(450, 172);
            this.listaSupervisor.TabIndex = 19;
            this.listaSupervisor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listaSupervisor_KeyDown);
            // 
            // SubMenuSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NFCe.Properties.Resources.SubMenu;
            this.ClientSize = new System.Drawing.Size(467, 212);
            this.Controls.Add(this.listaSupervisor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "SubMenuSupervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SubMenu Supervisor";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox listaSupervisor;
    }
}