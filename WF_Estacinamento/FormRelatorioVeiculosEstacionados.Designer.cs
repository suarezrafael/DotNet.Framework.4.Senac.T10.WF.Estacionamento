namespace WF_Estacinamento
{
    partial class FormRelatorioVeiculosEstacionados
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
            this.lstVeiculos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstVeiculos
            // 
            this.lstVeiculos.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVeiculos.FormattingEnabled = true;
            this.lstVeiculos.ItemHeight = 25;
            this.lstVeiculos.Items.AddRange(new object[] {
            "PLACA       |     MODELO     |     TEMPO",
            "IVM2C32        C4 LOUNGE          03:12:00",
            "BANANA         C3 BANANA          02:00:00"});
            this.lstVeiculos.Location = new System.Drawing.Point(25, 33);
            this.lstVeiculos.Name = "lstVeiculos";
            this.lstVeiculos.Size = new System.Drawing.Size(743, 254);
            this.lstVeiculos.TabIndex = 0;
            // 
            // FormRelatorioVeiculosEstacionados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstVeiculos);
            this.Name = "FormRelatorioVeiculosEstacionados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTA DE VEÍCULOS ESTACIONADOS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstVeiculos;
    }
}