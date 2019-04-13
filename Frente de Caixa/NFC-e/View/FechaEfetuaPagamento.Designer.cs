namespace NFCe.View
{
	partial class FechaEfetuaPagamento
    {
		private System.Windows.Forms.Timer Timer1;
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
            this.components = new System.ComponentModel.Container();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Interval = 500;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FFechaEfetuaPagamento
            // 
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(663, 47);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(271, 383);
            this.Name = "FFechaEfetuaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FFechaEfetuaPagamento";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FFechaEfetuaPagamento_KeyDown);
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.Label label1;

	}
}
