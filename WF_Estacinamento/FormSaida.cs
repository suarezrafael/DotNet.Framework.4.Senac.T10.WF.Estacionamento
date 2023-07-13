using MySql.Data.MySqlClient;
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
    public partial class FormSaida : Form
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;database=estacionamento;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;
        public int registroId = 0;

        public FormSaida()
        {
            InitializeComponent();
        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            // Salva a posição do cursor
            int cursorPosition = txtPlaca.SelectionStart;
            txtPlaca.Text = txtPlaca.Text.ToUpper();
            // Define a posição do cursor no final do texto
            txtPlaca.SelectionStart = cursorPosition;
            txtPlaca.SelectionLength = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            registroId = BuscarRegistroPelaPlaca(txtPlaca.Text);
            if (registroId == 0)
                MessageBox.Show("Veiculo não encontrado.");
        }

        private int BuscarRegistroPelaPlaca(string placa)
        {
            var valorTotal = 0.00;

            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = $@"select r.id , v.modelo, 
                                  TIMESTAMPDIFF(DAY, horaentrada, NOW())   AS dias,
                                  HOUR(TIMEDIFF(NOW(), horaentrada))       AS horas,
                                  MINUTE(TIMEDIFF(NOW(), horaentrada))     AS minutos
                                 from registro r , veiculo v 
                                 where v.id = r.veiculoid 
                                 and v.placa = '{placa}'
                                 and r.horasaida is null";
            rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                var horas = Convert.ToInt32(rd["horas"].ToString());
                var minutos = Convert.ToInt32(rd["minutos"].ToString());

                if (horas >= 2)
                {
                    if (horas == 2 && minutos > 0)
                    {
                        valorTotal = 5.00;
                    }
                    else
                    {
                        valorTotal = (horas - 2) * 5.00;
                        if (minutos > 0)
                            valorTotal += 5.00;

                    }
                }

                lblValorPagar.Text = "R$ " + valorTotal.ToString("F2");
                var id = Convert.ToInt32(rd["id"].ToString());
                con.Close();
                return id;
            }
            con.Close();
            return 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            RegistrarSaida();
        }

        private void RegistrarSaida()
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = $@"update registro set horasaida = NOW() where id = {registroId}";
            var resultUpdate = cmd.ExecuteNonQuery();

            if(resultUpdate > 0)
            {
                MessageBox.Show("Saída registrada");
                LimparCampos();
            }
            con.Close();
        }

        private void LimparCampos()
        {
            txtPlaca.Text = string.Empty;
            registroId = 0;
            lblValorPagar.Text = "R$ 0,00";
        }
    }
}
