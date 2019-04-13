namespace PafEcf.View
{
	partial class PenDrive
    {
		private System.Windows.Forms.PictureBox Image1;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.Button SpeedButton1;
		internal System.Windows.Forms.TextBox editPath;
		private System.Windows.Forms.Button botaoCancela;
		// Required designer variable.
		private System.ComponentModel.IContainer components = null;

		// Clean up any resources being used.
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.SpeedButton1 = new System.Windows.Forms.Button();
            this.editPath = new System.Windows.Forms.TextBox();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.SpeedButton1);
            this.GroupBox1.Controls.Add(this.editPath);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(111, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(402, 97);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Indique a localização do Pen-Drive";
            // 
            // SpeedButton1
            // 
            this.SpeedButton1.Location = new System.Drawing.Point(358, 51);
            this.SpeedButton1.Name = "SpeedButton1";
            this.SpeedButton1.Size = new System.Drawing.Size(30, 24);
            this.SpeedButton1.TabIndex = 0;
            this.SpeedButton1.Text = "...";
            this.SpeedButton1.Click += new System.EventHandler(this.SpeedButton1_Click);
            // 
            // editPath
            // 
            this.editPath.Location = new System.Drawing.Point(11, 51);
            this.editPath.Name = "editPath";
            this.editPath.Size = new System.Drawing.Size(341, 24);
            this.editPath.TabIndex = 0;
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(393, 125);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 2;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.PenDrive;
            this.Image1.Location = new System.Drawing.Point(10, 16);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(90, 89);
            this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // FPenDrive
            // 
            this.ClientSize = new System.Drawing.Size(525, 158);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.botaoCancela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(299, 411);
            this.Name = "FPenDrive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferência de Dados via Pen-Drive";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FPenDrive_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;

	}
}
