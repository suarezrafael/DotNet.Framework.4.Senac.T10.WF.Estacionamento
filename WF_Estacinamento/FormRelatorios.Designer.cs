
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
            this.btlListaVeiculosEstacionados = new System.Windows.Forms.Button();
            this.btnValorTotalArrecadadoDia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btlListaVeiculosEstacionados
            // 
            this.btlListaVeiculosEstacionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlListaVeiculosEstacionados.Location = new System.Drawing.Point(12, 12);
            this.btlListaVeiculosEstacionados.Name = "btlListaVeiculosEstacionados";
            this.btlListaVeiculosEstacionados.Size = new System.Drawing.Size(776, 104);
            this.btlListaVeiculosEstacionados.TabIndex = 3;
            this.btlListaVeiculosEstacionados.Text = "LISTA VEÍCULOS ESTACIONADOS";
            this.btlListaVeiculosEstacionados.UseVisualStyleBackColor = true;
            this.btlListaVeiculosEstacionados.Click += new System.EventHandler(this.btlListaVeiculosEstacionados_Click);
            // 
            // btnValorTotalArrecadadoDia
            // 
            this.btnValorTotalArrecadadoDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValorTotalArrecadadoDia.Location = new System.Drawing.Point(12, 122);
            this.btnValorTotalArrecadadoDia.Name = "btnValorTotalArrecadadoDia";
            this.btnValorTotalArrecadadoDia.Size = new System.Drawing.Size(776, 104);
            this.btnValorTotalArrecadadoDia.TabIndex = 4;
            this.btnValorTotalArrecadadoDia.Text = "VALOR TOTAL ARRECADADO DIA";
            this.btnValorTotalArrecadadoDia.UseVisualStyleBackColor = true;
            this.btnValorTotalArrecadadoDia.Click += new System.EventHandler(this.btnValorTotalArrecadadoDia_Click);
            // 
            // FormRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnValorTotalArrecadadoDia);
            this.Controls.Add(this.btlListaVeiculosEstacionados);
            this.Name = "FormRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RELATÓRIOS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btlListaVeiculosEstacionados;
        private System.Windows.Forms.Button btnValorTotalArrecadadoDia;
    }
}