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
        // cria as variáveis da tela
        // criar uma conecao com o banco de dados
        public MySqlConnection con = new MySqlConnection("server=localhost;database=estacionamento_db;uid=root;pwd=;");
        // criar um comando que pode ser executado no bd
        public MySqlCommand cmd = new MySqlCommand();
        // armazena o resultado de consultas no banco de dados
        public MySqlDataReader rd;
        // variaveis simples para armazenar o id do veículo
        public int veiculoId = 0;

        // Contrutor
        public FormEntrada()
        {
            // Renderizando os componentes na tela
            InitializeComponent();
        }

        #region Eventos

        private void btnOk_Click(object sender, EventArgs e)
        {
            #region
            // Verificar se a placa informada no txtPlaca ja esta registrado
            // se o veiculo ja existe?
            //    carregar o modelo no campos txtModelo
            //    carregar o id(código) do veiculo na variável veiculoId
            // chamando o método
            #endregion
            VerificarVeiculo();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // inserir um novo veiculo se for a primeira entrada
            // insert na tabela veiculo
            // se veiculoId for igual a zero
            //    chama método InserirVeiculo
            if (veiculoId == 0)
                InserirVeiculo();

            // registrar o veículo
            // insert na tabela registro
            Registrar();

        }




        #endregion Eventos


        // Métodos

        // método privado, retorna nada(vazio) nome: LimparCampos
        private void LimparCampos()
        {
            // seta o texto vazio para o txtModelo
            txtModelo.Text = string.Empty;
            // seta o texto vazio  para txtPlaca
            txtPlaca.Text = string.Empty;
            // atribuindo o valor da variavel veiculoId a zero
            veiculoId = 0;
            // colocando o foco do cursor do teclado no txtPlaca
            txtPlaca.Focus();
        }

        // Responsavel Verificar se a placa informada no txtPlaca ja esta registrado
        // se o veiculo ja existe?
        //    carregar o modelo
        //    carregar o id(código) do veiculo
        private void VerificarVeiculo()
        {
            // corpo das ações do método

            // cria uma variavel chamada placa que receve o texto do componente txtPlaca
            var placa = txtPlaca.Text;

            // abre a conexão com o banco de dados
            con.Open();
            // cria um comando SQL através da minha conexao
            cmd = con.CreateCommand();
            // determinei o SELECT do meu comando
            cmd.CommandText = $" SELECT id, placa, modelo FROM veiculo WHERE placa = '{placa}'";

            // executando o selectn o banco de dados
            rd = cmd.ExecuteReader();

            var existeVeiculo = rd.Read();

            // se existe um veiculo com esta placa
            if (existeVeiculo)
            {
                // atribui a variavel veiculoId o resultado do select

                veiculoId = int.Parse(rd["id"].ToString());
            }
            else
            {
                veiculoId = 0;
                // coloca o foco do teclado no txtModelo
                txtModelo.Focus();
                // alterando a cor do texto do txtModelo para vermelho
                txtModelo.ForeColor = Color.Red;
                // limpar o texto do campo modelo
                txtModelo.Text = string.Empty;
            }
            // fechar o leitor
            rd.Close();
            // fechar a conexao com o bd
            con.Close();
        }

        private void InserirVeiculo()
        {

        }
        private void Registrar()
        {

        }
    }
}
