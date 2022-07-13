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
    public partial class Form2 : Form
    {
        Form4 func;
        Form1 cliente;
        public Form2()

        {
            InitializeComponent();
            func = new Form4();
            cliente = new Form1();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            func.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            cliente.ShowDialog();
            this.Visible = true;
        }

    }// fim da classe

}//fim do projeto
