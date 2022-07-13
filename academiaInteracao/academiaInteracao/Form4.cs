using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace academiaInteracao
{
    public partial class Form4 : Form
    {
        DAOFuncionario func;
        public Form4()
        {
            InitializeComponent();
            func = new DAOFuncionario();//Abrindo a conexão com o Banco de Dados
            textBox1.Text = Convert.ToString(func.ConsultarCodigo() + 1);//mostra o proximo codigo na tela depois do ultimo codigo cadastrado, por isso o +1
            textBox1.ReadOnly = true;//bloqueando o codigo no primeiro acesso

        }

        public void Limpar()
        {
            textBox1.Text = "" + func.ConsultarCodigo();//codigo
            maskedTextBox1.Text = "";//cpf
            textBox3.Text = "";//nome
            maskedTextBox2.Text = "";//telefone
            textBox2.Text = "";//endereço

        }//fim do metodo Limpar tela

        public void AtivarCampos()
        {
            textBox1.ReadOnly = false;//codigo
            maskedTextBox1.ReadOnly = true;//cpf
            textBox3.ReadOnly = true;//nome
            maskedTextBox2.ReadOnly = true;//telefone
            textBox2.ReadOnly = true;//endereço
        }//fim do metodo ativar campos

        public void InativarCampos()
        {
            textBox1.ReadOnly = true;//codigo
            maskedTextBox1.ReadOnly = false;//cpf
            textBox3.ReadOnly = false;//nome
            maskedTextBox2.ReadOnly = false;//telefone
            textBox2.ReadOnly = false;//endreço
        }//fim do metodo inativar campos

        public long TratarCPF(string cpf)
        {
            string tratamento = cpf.Replace(",", "");
            tratamento = tratamento.Replace("-", "");
            return Convert.ToInt64(tratamento);
        }//fim do tratar cpf       


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }// textBox de codigo

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//maskedTextBox de CPF

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//textBox de nome

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//maskedTextBox de telefone

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//textBox de endereco

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.ReadOnly == false)
                {
                    Limpar();
                    InativarCampos();
                }
                else
                {
                    long cpf = TratarCPF(maskedTextBox1.Text);//Coletando o dado do campo CPF
                    string nome = textBox3.Text;//Coletando o dado do campo nome
                    string telefone = maskedTextBox2.Text;//Coletando o dado do campo telefone
                    string endereco = textBox2.Text;//Coletando o dado do campo Endereço
                                                    //Chamar o método inserir que foi criado na classe DAOPessoa
                    func.Inserir(cpf, nome, telefone, endereco);//Inserir no banco os dados do formulário
                    Limpar();//limpa os campos
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly == true)
            {
                AtivarCampos();
            }
            else
            {
                maskedTextBox1.Text = "" + func.ConsultarCPF(Convert.ToInt32(textBox1.Text));//preenchedo campo CPF
                textBox3.Text = func.ConsultarNome(Convert.ToInt32(textBox1.Text));//preenchedo campo NOME
                maskedTextBox2.Text = func.ConsultarTelefone(Convert.ToInt32(textBox1.Text));//preenchendo campo TELEFONE
                textBox2.Text = func.ConsultarEndereco(Convert.ToInt32(textBox1.Text));//preenchendo campo ENDEREÇO
            }
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")//se textBox.Text (nome, no caso) esta vazio, entao preenche com os dados do banco
            {

                maskedTextBox1.Text = "" + func.ConsultarCPF(Convert.ToInt32(textBox1.Text));//preenchedo campo CPF
                textBox3.Text = func.ConsultarNome(Convert.ToInt32(textBox1.Text));//preenchedo campo NOME
                maskedTextBox2.Text = func.ConsultarTelefone(Convert.ToInt32(textBox1.Text));//preenchendo campo TELEFONE
                textBox2.Text = func.ConsultarEndereco(Convert.ToInt32(textBox1.Text));//preenchendo campo ENDEREÇO
                InativarCampos();
            }
            else//se nao estiver vazio, atualizar com novos dados:
            {
                //apos repetir os metodos, atualiza-los:
                func.Atualizar(Convert.ToInt32(textBox1.Text), "CPF", TratarCPF(maskedTextBox1.Text));//atualizar cpf
                func.Atualizar(Convert.ToInt32(textBox1.Text), "nome", textBox3.Text); //atualizar nome
                func.Atualizar(Convert.ToInt32(textBox1.Text), "telefone", maskedTextBox2.Text);//atualizar telefone
                func.Atualizar(Convert.ToInt32(textBox1.Text), "endereco", textBox2.Text);//atualizar endereço
                Limpar();
            }
             }

        private void Excluir_Click(object sender, EventArgs e)
        {
                func.Deletar(Convert.ToInt32(textBox1.Text));
            }
    }
}
