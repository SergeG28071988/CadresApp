using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadresApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            form1 = new Form1();
        }

        Form1 form1;
        string Login = "Admin";
        string Password = "Qwery122";

        private void button1_Click(object sender, EventArgs e)
        {
            string Log = textBox1.Text;
            string Pass = textBox2.Text;

            // Делаем проверку

            if (Log == Login && Pass == Password)
            {
                form1.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Ошибка в логине или пароле! Попробуйте ещё раз!");
            }

        }
    }
}
