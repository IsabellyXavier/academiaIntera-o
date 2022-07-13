using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace academiaInteracao
{
    public partial class Form1 : Form
    {

        public string email;
        public string senha;

        public Form1()
        {
            InitializeComponent();
        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string conexao = "server=localhost;DataBase=academiaInteracao;Uid=root;password=";
                var connection = new MySqlConnection(conexao);
                var comand = connection.CreateCommand();

                MySqlCommand query = new MySqlCommand("select*from Login where email = '" + textBox1.Text + "' and senha = '" + textBox2.Text + "'", connection);

                connection.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dataTable);

                email = "@senac.com";
                senha = "12345";
                

                if ((textBox1.Text == email ) && (textBox2.Text == senha))
                {
                    this.Visible = false;
                    Form2 login = new Form2();
                    login.ShowDialog();
                    

                }
                else
                {
                    MessageBox.Show("Login ou senha invalido");

                }//
                
            }// fim do try

            catch (Exception erro)
            {
                MessageBox.Show("erro" + erro);

            }// fim do catch
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
