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
    public partial class FormRelListaVeiculosEstacionados : Form
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;database=estacionamento;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;
        public FormRelListaVeiculosEstacionados()
        {
            InitializeComponent();
        }

        private void BuscarListaVeiculosEstacionados()
        {
            lista.Items.Clear();
            lista.Items.Add("  PLACA  |   MODELO  |  TEMPO       ");

            cmd.CommandText = @"SELECT 
                                    v.placa, v.modelo, 
                                    TIMESTAMPDIFF(DAY, horaentrada, NOW()), ' d, 'AS dias,
                                    LPAD(HOUR(TIMEDIFF(NOW(), horaentrada)), 2, '0') AS horas,
                                    LPAD(MINUTE(TIMEDIFF(NOW(), horaentrada)), 2, '0') AS minutos
                                FROM registro r, veiculo v 
                                WHERE r.veiculoid = v.id AND r.horasaida is null ORDER BY horasaida ";

            con.Open();
            cmd.Connection = con;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                var placa = rd["placa"].ToString();
                var modelo = rd["modelo"].ToString();
                var dias = rd["dias"].ToString();
                var horas = rd["horas"].ToString();
                var minutos = rd["minutos"].ToString();

                lista.Items.Add( placa +" | "+ modelo + " | "+ horas +":"+ minutos );
            }
           
            rd.Close();
            con.Close();
        }

        private void FormRelListaVeiculosEstacionados_Load(object sender, EventArgs e)
        {
            BuscarListaVeiculosEstacionados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarListaVeiculosEstacionados();
        }
    }
}
