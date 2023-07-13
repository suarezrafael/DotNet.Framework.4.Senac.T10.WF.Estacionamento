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
    public partial class FormRelatorios : Form
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;database=estacionamento;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;

        public FormRelatorios()
        {
            InitializeComponent();
        }

        private void btlListaVeiculosEstacionados_Click(object sender, EventArgs e)
        {
            new FormRelListaVeiculosEstacionados().ShowDialog();
        }

        private void btnValorTotalArrecadadoDia_Click(object sender, EventArgs e)
        {
            BuscarTotalArrecadadoDia();
        }

        private void BuscarTotalArrecadadoDia()
        {

            cmd.CommandText = @"SELECT v.placa, v.modelo, 
                                TIMESTAMPDIFF(DAY, horaentrada, horasaida)   AS dias,
                                LPAD(HOUR(TIMEDIFF(horasaida, horaentrada)), 2, '0')   AS horas,
                                LPAD(MINUTE(TIMEDIFF(horasaida, horaentrada)), 2, '0') AS minutos
                                    FROM registro r, veiculo v 
                                WHERE r.veiculoid = v.id AND r.horasaida is not null 
                                AND  DATE(horasaida) = CURDATE() ORDER BY horasaida ";

            con.Open();
            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            var valorTotal = 0.00M;
            while (rd.Read())
            {
                var placa = rd["placa"].ToString();
                var modelo = rd["modelo"].ToString();
                var dias = rd["dias"].ToString();
                var horas = Convert.ToInt32(rd["horas"].ToString());
                var minutos = Convert.ToInt32(rd["minutos"].ToString());

                
                if(horas >= 2 )
                {
                    if(horas == 2 && minutos > 0)
                    {
                        valorTotal += 5.00M;
                    }
                    else
                    {
                        valorTotal += (horas - 2) * 5.00M;
                        if (minutos > 0)
                            valorTotal += 5.00M;

                    }
                }
                

              }
            MessageBox.Show("Valor Total dia: R$ " + valorTotal.ToString("F2"));

            rd.Close();
            con.Close();
        }
    }
}
