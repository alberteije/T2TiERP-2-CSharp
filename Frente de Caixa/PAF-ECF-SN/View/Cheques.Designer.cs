namespace PafEcf.View
{
	partial class Cheques
    {
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
            this.SuspendLayout();
            // 
            // TFCheques
            // 
            this.ClientSize = new System.Drawing.Size(742, 168);
            this.Location = new System.Drawing.Point(64, 341);
            this.Name = "TFCheques";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cheques";
            this.ResumeLayout(false);

		}
		#endregion

	}
}
