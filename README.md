# DotNet.Framework.4.Senac.T10.WF.Estacionamento

Sistema de Gerenciamento de EstacionamentoSistema de Gerenciamento de Estacionamento opções do item

## Atividade: Sistema de Gerenciamento de Estacionamento

## Descrição: 
Você foi contratado para desenvolver um sistema de gerenciamento de estacionamento para uma empresa. 
O sistema precisa ser capaz de registrar informações sobre os veículos que entram e saem do estacionamento, bem como calcular e cobrar as taxas de estacionamento.

## Requisitos:
O sistema deve permitir o registro de novos veículos que entram no estacionamento. 
Cada veículo deve ter as seguintes informações registradas:

- Placa do veículo (formato XXX-####, onde X é uma letra maiúscula e # é um dígito numérico de 0 a 9)
- Modelo do veículo
- Hora de entrada no estacionamento
- O sistema deve permitir registrar a saída de um veículo do estacionamento.
- Ao registrar a saída, o sistema deve calcular a duração da estadia do veículo e a taxa a ser cobrada com base nas seguintes regras:
- As primeiras 2 horas são gratuitas.
- Após 2 horas, a taxa é de R$ 5,00 por hora ou fração de hora adicional.
- O sistema deve ser capaz de exibir relatórios com as seguintes informações:
- Lista de veículos atualmente estacionados, incluindo placa, modelo e tempo de permanência.
- Valor total arrecadado no dia.
- O sistema deve ser capaz de lidar com casos em que um veículo é registrado como tendo entrado, mas ainda não saiu.

## Tarefas:
Modele o banco de dados para armazenar as informações necessárias para o sistema de gerenciamento de estacionamento.

- Escreva as consultas SQL para realizar as seguintes operações: 
   a) Registrar a entrada de um veículo no estacionamento. 
   b) Registrar a saída de um veículo do estacionamento. 
   c) Exibir a lista de veículos atualmente estacionados. 
   d) Calcular e exibir o valor total arrecadado no dia.

- Implemente um programa em sua linguagem de programação preferida que utilize o banco de dados e as consultas SQL para interagir com o sistema de gerenciamento de estacionamento. 

- O programa deve permitir ao usuário executar as operações mencionadas acima.

- Teste o programa, realizando diferentes operações no sistema de gerenciamento de estacionamento e verifique se os resultados estão corretos.
- Documente o seu código e forneça instruções sobre como executar o programa.

## Próxima aula
- Instalar no projeto pacote MySql.Data
- Criar 4 variáveis 
  - public MySqlConnection con = new MySqlConnection("server=localhost;database=estacionamento;uid=root;pwd=;sslmode=none");
  - public MySqlCommand cmd = new MySqlCommand();
  - public MySqlDataReader rd;
  - public int veiculoid = 0;
- Renomear labels, txts e botoes
- Adicioanar evento aos botões
  
        private void btnOk_Click(object sender, EventArgs e)
        {
            VerificarVeiculo();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
           if(veiculoid == 0)
                veiculoid = InserirVeiculo(txtPlaca.Text,txtModelo.Text);

            Registrar();
        }

- Criar evento de de ao digitar no txtPlaca para converter o texto pra maiusculo e manter o cursor do teclado no final

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            // Salva a posição do cursor
            int cursorPosition = txtPlaca.SelectionStart;
            txtPlaca.Text = txtPlaca.Text.ToUpper();
            // Define a posição do cursor no final do texto
            txtPlaca.SelectionStart = cursorPosition;
            txtPlaca.SelectionLength = 0;
        }
- Criar metodo que será chamado no clique do botao ok.

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
- criar metodo para verificar se ja existe um registro de entrada em aberto

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
                    MessageBox.Show("VEICULO" + placa + " já registrado!");
                    return false;
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
            return true;
        }
- criar método para inserir um novo veículo
-
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
- criar método para buscar o id do veículo pelo numero da placa
-

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
- criar método chamado no botão registrar/salvar

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
## Telas feitas até aula 16/06/2023:
Prototipo
![prototipo](https://github.com/suarezrafael/DotNet.Framework.4.Senac.T10.WF.Estacionamento/assets/29218714/6e1a8be7-95c6-4b79-9f68-abb548cf486d)

FormPrincipal
![formPrincipal](https://github.com/suarezrafael/DotNet.Framework.4.Senac.T10.WF.Estacionamento/assets/29218714/23b1b992-ba2d-45f5-878b-406a19b28194)

FormEntrada
![fromEntrada](https://github.com/suarezrafael/DotNet.Framework.4.Senac.T10.WF.Estacionamento/assets/29218714/e91811af-87b7-4f8d-a8ee-d702fb2c4fe6)

FormSaida
![fromSaida](https://github.com/suarezrafael/DotNet.Framework.4.Senac.T10.WF.Estacionamento/assets/29218714/6f51678b-3924-47b5-a347-14a9c1eba362)

