namespace WF_Estacinamento
{
    partial class FormRelatorios
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
            this.btnRelListaVeiculosEstacionados = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValorArrecadadoDia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRelListaVeiculosEstacionados
            // 
            this.btnRelListaVeiculosEstacionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelListaVeiculosEstacionados.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnRelListaVeiculosEstacionados.Location = new System.Drawing.Point(43, 94);
            this.btnRelListaVeiculosEstacionados.Name = "btnRelListaVeiculosEstacionados";
            this.btnRelListaVeiculosEstacionados.Size = new System.Drawing.Size(703, 122);
            this.btnRelListaVeiculosEstacionados.TabIndex = 0;
            this.btnRelListaVeiculosEstacionados.Text = "Lista de veículos estacionados";
            this.btnRelListaVeiculosEstacionados.UseVisualStyleBackColor = true;
            this.btnRelListaVeiculosEstacionados.Click += new System.EventHandler(this.btnRelListaVeiculosEstacionados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "Relatórios Gerenciais";
            // 
            // btnValorArrecadadoDia
            // 
            this.btnValorArrecadadoDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValorArrecadadoDia.ForeColor = System.Drawing.Color.Blue;
            this.btnValorArrecadadoDia.Location = new System.Drawing.Point(43, 242);
            this.btnValorArrecadadoDia.Name = "btnValorArrecadadoDia";
            this.btnValorArrecadadoDia.Size = new System.Drawing.Size(703, 122);
            this.btnValorArrecadadoDia.TabIndex = 3;
            this.btnValorArrecadadoDia.Text = "Valor total arrecadado no dia";
            this.btnValorArrecadadoDia.UseVisualStyleBackColor = true;
            this.btnValorArrecadadoDia.Click += new System.EventHandler(this.btnValorArrecadadoDia_Click);
            // 
            // FormRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnValorArrecadadoDia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRelListaVeiculosEstacionados);
            this.Name = "FormRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RELATÓRIOS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRelListaVeiculosEstacionados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValorArrecadadoDia;
    }
}