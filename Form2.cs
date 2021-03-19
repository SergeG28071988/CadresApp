using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace CadresApp
{
    public partial class Form2 : Form
    {
        //Создаем подключение к базе данных
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cadres.mdb";
        // Задаем имя подключению
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Пишем код для поиска
            myConnection = new OleDbConnection(connectString); // создаем новый объект и выделяем память
            myConnection.Open(); // открываем соединение с БД

            string department = textBox1.Text;            

            string query = "Select Фамилия, Имя, Должность, Кабинет FROM Сотрудники WHERE Отдел  LIKE '%" + department + "%'";
            
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Пишем код для поиска
            myConnection = new OleDbConnection(connectString); // создаем новый объект и выделяем память
            myConnection.Open(); // открываем соединение с БД
            
            string cabinet = textBox2.Text;

            string query = "Select Фамилия, Имя, Должность, Отдел FROM Сотрудники WHERE Кабинет  LIKE '%" + cabinet  + "%'";

            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView2.DataSource = dt;
            myConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
