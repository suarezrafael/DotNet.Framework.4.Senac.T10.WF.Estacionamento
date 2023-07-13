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
    public partial class FormEntrada : Form
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;database=estacionamento;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;
        public int veiculoid = 0;

        public FormEntrada()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            txtModelo.Text = string.Empty;
            txtPlaca.Text = string.Empty;
            veiculoid = 0;
            txtPlaca.Focus();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            VerificarVeiculo();
        }

        private void VerificarVeiculo()
        {
            try
            {
                var txtplaca = txtPlaca.Text;

                con.Open();

                cmd = con.CreateCommand();

                cmd.CommandText = $"SELECT Id, placa, modelo FROM veiculo WHERE placa = '{txtplaca}'";

                rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    veiculoid = Convert.ToInt32(rd["id"].ToString());
                    var modelo = rd["modelo"].ToString();

                    rd.Close();
                    con.Close();

                    if (!VerificarEntrada(veiculoid, txtplaca))
                        return;

                    txtModelo.Text = modelo;
                }
                else
                {
                    veiculoid = 0;
                    lblModelo.Text = "DIGITE O MODELO";
                    lblModelo.ForeColor = Color.Red;
                    txtModelo.Text = string.Empty;
                    txtModelo.Focus();
                }

                rd.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema // " + ex.Message);
            }
            finally
            {
                con.Close();

            }

        }
        private bool VerificarEntrada(int id, string placa)
        {
            try
            {
                con.Open();

                cmd = con.CreateCommand();

                cmd.CommandText = $"SELECT id,horaentrada FROM registro WHERE veiculoid = '{id}' AND horasaida IS NULL";

                rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    MessageBox.Show("VEICULO " + placa + " já registrado!");
                    LimparCampos();
                    return false;
                }

                rd.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema // " + ex.Message);
            }
            finally { con.Close(); }
            
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(veiculoid == 0)
                veiculoid = InserirVeiculo(txtPlaca.Text,txtModelo.Text);

            Registrar();
        }

        private int InserirVeiculo(string placa, string modelo)
        {
            int veiculoId;
            try
            {
                con.Open();

                cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO veiculo (placa, modelo) " +
                        "VALUES (@placa, @modelo)";

                cmd.Parameters.AddWithValue("placa", placa);
                cmd.Parameters.AddWithValue("modelo", modelo);

                var retornoInsert = cmd.ExecuteNonQuery();

                con.Close();

                if (retornoInsert > 0)
                {
                    veiculoId = BuscarVeiculoIdPelaPlaca(placa);
                    return veiculoId;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema // " + ex.Message);
            }
            finally
            {
                con.Close();

            }
            return 0;
        }

        private int BuscarVeiculoIdPelaPlaca(string placa)
        {
            var veiculoId = 0;
            try
            {
                con.Open();

                cmd = con.CreateCommand();

                cmd.CommandText = $"SELECT id FROM veiculo WHERE placa = '{placa}'";

                rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                     veiculoId = Convert.ToInt32(rd["id"].ToString());

                }
                else
                {
                    MessageBox.Show("BuscarVeiculoIdPelaPlaca: Veiculo nao localizado // " );
                }

                rd.Close();
                con.Close();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema // " + ex.Message);
            }
            finally
            {
                con.Close();

            }
            return veiculoId;
        }

        private void Registrar()
        {
            try
            {
                con.Open();

                cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO registro (veiculoId, horaentrada) " +
                        "VALUES (@veiculoid, @horaentrada)";

                cmd.Parameters.AddWithValue("veiculoid", veiculoid);
                cmd.Parameters.AddWithValue("horaentrada", DateTime.Now);
                
                var retornoInsert = cmd.ExecuteNonQuery();

                if (retornoInsert > 0)
                {
                    LimparCampos();
                    MessageBox.Show("Registro realizado.");
      
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema // " + ex.Message);
            }
            finally
            {
                con.Close();

            }
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
    }
}
