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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        // Evento de clique do botão ENTRADA
        private void btnEntrada_Click(object sender, EventArgs e)
        {
            // Exibe uma caixa de mensagem com o texto
            // CaixaDeMensagem.Exibir("VOCE CLICOU EM ENTRADA");
            //MessageBox.Show("VOCE CLICOU EM ENTRADA"); 

            // criar um formulario de entrada
            // e armazena na variavel formEntrada
            var formEntrada = new FormEntrada();

            // exibe a tela de entrada
            formEntrada.ShowDialog();
        }

        // Evento de clique do botão SAIDA
        private void btnSaida_Click(object sender, EventArgs e)
        {
            // Exibe uma caixa de mensagem com o texto 
            // CaixaDeMensagem.Exibir("VOCE CLICOU EM SAIDA");
            //MessageBox.Show("VOCE CLICOU EM SAIDA");
            new FormSaida().ShowDialog();

        }
    }
}
