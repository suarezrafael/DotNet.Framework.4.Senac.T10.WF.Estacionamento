using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Estacinamento
{
    public partial class FormRelatorios : Form
    {
        public FormRelatorios()
        {
            InitializeComponent();
        }

        // evento de clique do botão lista veiculos
        private void btnRelListaVeiculosEstacionados_Click(object sender, EventArgs e)
        {
            new FormRelatorioVeiculosEstacionados().ShowDialog();
        }

        // evento de clique do botão valor arrecadado
        private void btnValorArrecadadoDia_Click(object sender, EventArgs e)
        {
            // exibe mensagem com título, Botão e ícone
            DialogResult resultado = MessageBox.Show("Valor Total R$ 0,00",
                "Mensagem",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // se resultado do clique da caixa de mensagem foi SIM
            if(resultado == DialogResult.Yes) 
            {
                // imprime fechamento do caixa
                // imprime na saída do console a msg IMPRIMINDO
                Console.WriteLine(".....IMPRIMINDO FECHAMENTO.........");

            }

            if(resultado == DialogResult.No)
            {
                // não imprime o relatório
                Console.WriteLine(".....CLICOU em NÃO...................");
            }
        }

    }
}
